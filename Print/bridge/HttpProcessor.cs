using Print.bean;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace Print.bridge
{
    class HttpProcessor
    {
        private const int TIMEOUT = 60 * 1000;
        private const int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB
        private const int BUF_SIZE = 4096;
        private HttpSocketServer server;
        private TcpClient client;
        private BinaryReader inputStream = null;
        private BinaryWriter outputStream = null;
        private Encoding encoding = null;
        private string method;
        private string uri;
        private string protocol;
        private string version;
        private Hashtable headers = new Hashtable();
        private string queryString = null;
        private Hashtable parameterMap = new Hashtable();

        public HttpProcessor(HttpSocketServer server, TcpClient client)
        {
            this.server = server;
            this.client = client;
            this.encoding = Encoding.GetEncoding(this.server.Charset);
        }

        public string Process()
        {
            client.ReceiveTimeout = TIMEOUT;
            client.SendTimeout = TIMEOUT;
            NetworkStream stream = client.GetStream();
            if (!stream.DataAvailable)
            {
                return null;
            }
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BinaryReader(stream, encoding);
            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new BinaryWriter(stream, encoding);
            try
            {
                ParseRequest();
                ReadHeaders();
                if ("GET".Equals(method))
                {
                    HandleGETRequest();
                }
                else if ("POST".Equals(method))
                {
                    HandlePOSTRequest();
                }
                string result = null;
                if (queryString != null)
                {
                    StringBuilder sb = new StringBuilder("接收来自")
                        .Append(this.client.Client.RemoteEndPoint.ToString())
                        .Append("的消息：").Append(queryString).Append("\r\n");
                    result = sb.ToString();
                }
                return result;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //Write(500, "text/plain", e.ToString());
                return e.ToString();
            }
            finally
            {
                if (inputStream != null)
                {
                    inputStream.Close();
                }
                if (outputStream != null)
                {
                    outputStream.Flush();
                    outputStream.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        private void ParseRequest()
        {
            string request = streamReadLine(inputStream);
            if (request == null)
            {
                throw new Exception("Invalid http request");
            }
            //Console.WriteLine("http status line: " + request);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("Invalid http request method");
            }
            method = tokens[0].ToUpper();

            if (tokens[1].Contains("?"))
            {
                string[] urlArray = tokens[1].Split('?');
                uri = urlArray[0];
                QarseQueryString(urlArray[1]);//接收请求参数
            }
            else
            {
                uri = tokens[1];
            }
            string[] protocols = tokens[2].Split('/');
            if (protocols.Length != 2)
            {
                throw new Exception("Invalid http request protocol");
            }
            protocol = protocols[0];
            version = protocols[1];
        }

        private void ReadHeaders()
        {
            string line;
            while ((line = streamReadLine(inputStream)) != null)
            {
                if ("".Equals(line))
                {
                    break;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("Invalid http header:" + line);
                }
                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }
                string value = line.Substring(pos, line.Length - pos);
                headers[name] = value;
                //Console.WriteLine("header: {0}:{1}", name, value);
            }
        }

        public void HandleGETRequest()
        {
            server.HandleGETRequest(this);
        }

        public void HandlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 
            int contentLenght = 0;
            MemoryStream ms = new MemoryStream();
            if (this.headers.ContainsKey("Content-Length"))
            {
                contentLenght = Convert.ToInt32(this.headers["Content-Length"]);
                if (contentLenght > MAX_POST_SIZE)
                {
                    throw new Exception(string.Format("POST Content-Length({0}) Beyond the Maximum {1} Length Limit", contentLenght, MAX_POST_SIZE));
                }
                byte[] buf = new byte[BUF_SIZE];
                int leaveReadingBytes = contentLenght;
                while (leaveReadingBytes > 0)
                {
                    //Console.WriteLine("starting Read, to_read={0}", to_read);
                    int readedBytes = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, leaveReadingBytes));
                    //Console.WriteLine("read finished, numread={0}", numread);
                    if (readedBytes == -1)
                    {
                        throw new Exception("Client Abort");
                    }
                    if (readedBytes == 0)
                    {
                        if (leaveReadingBytes == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("Client disconnected during post");
                        }
                    }
                    leaveReadingBytes -= readedBytes;
                    ms.Write(buf, 0, readedBytes);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            server.HandlePOSTRequest(this, new StreamReader(ms));
        }

        public void Write(int code, string contentType, string content)
        {
            DateTime now = DateTime.Now;
            content = content == null ? "" : content;
            byte[] contentBytes = encoding.GetBytes(content);//将字符串转化为字节数组
            //Console.WriteLine("version=>"+ version);
            StringBuilder sb = new StringBuilder("HTTP/" + version + " " + code + " " + Enum.GetName(typeof(HttpStatusCodeEnum), code)).Append("\r\n");
            sb.Append("Server:Atom").Append("\r\n");
            sb.Append("Date:" + now.ToString("r")).Append("\r\n");
            sb.Append("Content-Type:" + contentType).Append("\r\n");
            sb.Append("Content-Length:" + contentBytes.Length).Append("\r\n");
            sb.Append("Connection:" + ("1.1".Equals(version) ? "keep-alive" : "close")).Append("\r\n");
            //sb.Append("Access-Control-Allow-Methods:GET,POST").Append("\r\n");
            //sb.Append("Access-Control-Allow-Headers:X-Requested-With").Append("\r\n");
            //sb.Append("Access-Control-Allow-Origin:*").Append("\r\n");
            sb.Append("\r\n");//增加一行空行和实际返回数据分隔
            sb.Append(content);
            outputStream.Write(sb.ToString());
            outputStream.Flush();
        }

        private string streamReadLine(BinaryReader stream)
        {
            int next_char;
            StringBuilder line = new StringBuilder();
            try
            {
                while ((next_char = stream.ReadByte()) != -1)
                {
                    if (next_char == '\n')
                    {
                        break;
                    }
                    if (next_char == '\r')
                    {
                        continue;
                    }
                    line.Append(Convert.ToChar(next_char));
                }
            }
            catch
            {
                return null;
                //Console.WriteLine(e.ToString());
            }
            return line.ToString();
        }

        public void QarseQueryString(string queryString)
        {
            this.queryString = queryString;
            if (queryString == null)
            {
                return;
            }
            //分割将字符串转成数组
            string[] arrayParams = queryString.Split('&');
            if (arrayParams.Length == 1)
            {
                return;
            }
            for (int i = 0; i < arrayParams.Length; i++)
            {
                string keyValue = arrayParams[i];
                string[] keyValues = keyValue.Split('=');
                string key = keyValues[0].Trim();
                string value = null;
                if (keyValues.Length > 1)
                {
                    value = HttpUtility.UrlDecode(keyValues[1].Trim(), encoding);
                }
                if (!parameterMap.ContainsKey(key))
                {
                    parameterMap.Add(key, new List<string>(1));
                }
                List<string> values = (List<string>)parameterMap[key];
                values.Add(value);
            }
        }

        public string Method
        {
            get
            {
                return method;
            }
        }

        public string Uri
        {
            get
            {
                return uri;
            }
        }

        public string Protocol
        {
            get
            {
                return protocol;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }
        }

        public Hashtable Headers
        {
            get
            {
                return headers;
            }
        }

        public string QueryString
        {
            get
            {
                return queryString;
            }
        }

        public Hashtable ParameterMap
        {
            get
            {
                return parameterMap;
            }
        }
    }
}
