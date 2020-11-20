using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Print.bridge
{
    abstract class HttpSocketServer
    {
        public delegate void DelegateUIMessage(string message);
        public DelegateUIMessage UIDelegateUIMessage;
        public delegate string DelegateSocketMessage();

        private TcpListener listener = null;
        private string host;
        private int port;
        private string charset;
        private bool isActive = true;

        public HttpSocketServer(string host, int port, string charset)
        {
            this.host = host;
            this.port = port;
            this.charset = charset;
        }

        public void listen()
        {
            //创建负责监听的线程
            Thread _WatchThread = new Thread(new ThreadStart(WatchConnecting));
            _WatchThread.IsBackground = true;
            _WatchThread.Start();
        }

        public void WatchConnecting()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(Host), Port);
                listener.Start(20);
                // 开始监听客户端连接请求，Accept方法会阻断当前的线程；
                // 一旦监听到一个客户端的请求，就返回一个与该客户端通信的套接字；
                while (IsActive)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    HttpProcessor processor = new HttpProcessor(this, client);
                    DelegateSocketMessage caller = new DelegateSocketMessage(processor.Process);
                    IAsyncResult result = caller.BeginInvoke(null, null);
                    string message = caller.EndInvoke(result);
                    UIDelegateUIMessage(message);
                    //Console.Write(message);
                }
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            catch
            {
                if (listener != null)
                {
                    IsActive = false;
                    listener.Stop();
                }
            }
        }

        public abstract void HandleGETRequest(HttpProcessor processor);

        public abstract void HandlePOSTRequest(HttpProcessor processor, StreamReader inputData);

        public string Host
        {
            get
            {
                return host;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
        }

        public string Charset
        {
            get
            {
                return charset;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }
    }
}
