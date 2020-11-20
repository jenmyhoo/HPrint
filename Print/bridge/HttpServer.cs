using common.tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Print.bridge
{
    class HttpServer : HttpSocketServer
    {
        public HttpServer(string host, int port, string charset) : base(host, port, charset)
        {
        }

        public override void HandleGETRequest(HttpProcessor processor)
        {
            Handle(processor);
        }

        public override void HandlePOSTRequest(HttpProcessor processor, StreamReader inputData)
        {
            try
            {
                string data = inputData.ReadToEnd();
                inputData.Close();
                //Console.WriteLine("postData=>" + data);
                processor.QarseQueryString(data);
                Handle(processor);
            }
            catch (Exception e)
            {
                processor.Write(500, "text/plain;charset=" + this.Charset, e.Message);
            }

        }

        public void Handle(HttpProcessor processor)
        {
            if (processor.ParameterMap.Count == 0)
            {
                processor.Write(200, "text/plain;charset=" + this.Charset, "SUCCESS");
                return;
            }
            string command = null;
            if (processor.ParameterMap.ContainsKey("command"))
            {
                List<string> commandList = (List<string>)processor.ParameterMap["command"];
                command = commandList[0];
            }
            string result = null;
            if (string.Equals("print", command, StringComparison.CurrentCultureIgnoreCase))
            {
                result = Print(processor.QueryString);
            }
            else
            {
                result = processor.QueryString;
            }
            processor.Write(200, "text/plain;charset=" + this.Charset, result);
        }

        private string Print(string content)
        {
            CallServiceThread callService = new CallServiceThread();
            Task<string> task = Task.Factory.StartNew<string>(() => callService.print(content));//异步执行
            string result = task.Result;
            if ("ACK".Equals(result))
            {
                return "SUCCESS";
            }
            else
            {
                return result;
            }
        }
    }
}
