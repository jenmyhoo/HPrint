using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Print.bridge
{
    class TcpSocketServer
    {
        public delegate void DelegateUIMessage(string message);
        public DelegateUIMessage UIDelegateUIMessage;
        protected delegate string DelegateSocketMessage(SocketParameter socketParameter);
        private volatile bool running = true;
        private Socket _Watchsocket = null;
        private Thread _WatchThread = null;

        private static class SingletonTcpSocket
        {
            public readonly static TcpSocketServer INSTANCE = new TcpSocketServer();
        }

        public static TcpSocketServer getInstance()
        {
            return SingletonTcpSocket.INSTANCE;
        }

        private TcpSocketServer()
        {

        }

        public string start(SocketParameter socketParameter)
        {
            try
            {
                if (_Watchsocket != null)
                {
                    _Watchsocket.Close();
                    _Watchsocket.Dispose();
                }
                _Watchsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _Watchsocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(socketParameter.Host), socketParameter.Port);
                _Watchsocket.Bind(serverPoint);
                //挂起队列最大值
                _Watchsocket.Listen(20);
                //创建负责监听的线程
                _WatchThread = new Thread(new ParameterizedThreadStart(WatchConnecting));
                _WatchThread.IsBackground = true;
                _WatchThread.Start(socketParameter);

                return "SUCCESS";
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return e.Message;
            }
        }

        public void WatchConnecting(Object socketObject)
        {
            try
            {
                //Console.WriteLine("服务器正在监听...");
                SocketParameter socketParameter = socketObject as SocketParameter;
                while (running)
                {
                    // 开始监听客户端连接请求，Accept方法会阻断当前的线程；
                    // 一旦监听到一个客户端的请求，就返回一个与该客户端通信的套接字；
                    Socket socketClient = _Watchsocket.Accept();
                    CallServiceThread callServiceThread = new CallServiceThread(socketClient);
                    DelegateSocketMessage caller = new DelegateSocketMessage(callServiceThread.ReceiveMessage);
                    IAsyncResult result = caller.BeginInvoke(socketParameter, null, null);
                    string message = caller.EndInvoke(result);
                    UIDelegateUIMessage(message);
                    //Console.Write(message);
                }
                if (_Watchsocket != null)
                {
                    _Watchsocket.Close();
                    _Watchsocket.Dispose();
                }
            }
            catch
            {
                //Console.WriteLine(e.Message);
                if (_Watchsocket != null)
                {
                    _Watchsocket.Close();
                    _Watchsocket.Dispose();
                }
            }
        }

        public void terminate()
        {
            running = false;
        }
    }
}
