using System.Text;

namespace Print.bridge
{
    class SocketParameter
    {
        private string host;
        private int port;
        private Encoding charset = Encoding.UTF8;
        private string message;

        public SocketParameter()
        {

        }

        public SocketParameter(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public Encoding Charset
        {
            get
            {
                return charset;
            }

            set
            {
                charset = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
    }
}
