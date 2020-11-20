using common;
using common.tool;
using Newtonsoft.Json;
using Print.bean.printer;
using Print.tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Print.bridge
{
    class CallServiceThread
    {
        private Socket socket;

        public CallServiceThread()
        {
        }

        /**
         * 本地TCP消息处理构造
         **/
        public CallServiceThread(Socket socket)
        {
            this.socket = socket;
        }

        /**
         * 本地TCP消息接收处理
         **/
        public string ReceiveMessage(SocketParameter socketParameter)
        {
            string message = null;
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                //_tcpClient = new TcpClient();
                //_tcpClient.Client = socket;
                //stream = _tcpClient.GetStream();
                stream = new NetworkStream(socket);
                reader = new StreamReader(stream, socketParameter.Charset);
                writer = new StreamWriter(stream, socketParameter.Charset);
                StringBuilder sb = new StringBuilder("接收来自" + socket.RemoteEndPoint.ToString() + "的消息：");
                StringBuilder sc = new StringBuilder();
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if ("EOF".Equals(line))
                    {
                        break;
                    }
                    //Console.WriteLine("接收来自" + socket.RemoteEndPoint.ToString() + "的消息：" + line);
                    sb.Append(line).Append("\r\n");
                    sc.Append(line);
                }
                string respone = "ACK";
                message = sb.ToString();
                respone = print(sc.ToString());
                sb.Clear();
                sc.Clear();
                writer.WriteLine(respone);
                //writer.Write("\r\n");
                //多输出一行终止标识符告诉客户端本次数据发送结束
                writer.WriteLine("EOF");
                //writer.Write("\r\n");
                writer.Flush();
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
                if (socket != null)
                {
                    socket.Close();
                    socket.Dispose();
                }
            }

            return message;
        }

        public string print(string printListJson)
        {
            string error = "NULL";
            if (CheckTools.isNull(printListJson))
            {
                return error;
            }
            PrinterList printerList = JsonConvert.DeserializeObject<PrinterList>(printListJson);
            if (printerList == null)
            {
                return error;
            }
            if (printerList.command == null)
            {
                printerList.command = "print";
            }
            if (string.Equals("print", printerList.command, StringComparison.CurrentCultureIgnoreCase))
            {
                print(true, printerList);
                error = printerList.errorMsg;
            }
            else
            {
                error = printListJson;
            }

            //StringBuilder sb = new StringBuilder(printerList.listId == null ? "" : printerList.listId.ToString()).Append("ACK".Equals(error) ? "打印成功!" : error);
            //error = sb.ToString();
            //sb.Clear();

            return error;
        }

        public PrinterList print(bool isPrint, PrinterList printerList)
        {
            string error = null;
            if (printerList == null)
            {
                error = "无可用打印数据";
                printerList.printResult = 2;
                printerList.errorMsg = error;
                return printerList;
            }
            if (CheckTools.isNull(printerList.templateFileName))
            {
                error = "打印模板名称不允许为空";
                printerList.printResult = 2;
                printerList.errorMsg = error;
                return printerList;
            }
            IDictionary<string, string> fixedField = null;
            if (!CheckTools.isNull(printerList.printerJson))
            {
                try
                {
                    fixedField = JsonConvert.DeserializeObject<IDictionary<string, string>>(printerList.printerJson);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("CallServiceThread序列化异常：" + e.Message);
                    error = e.Message;
                }
            }
            IDictionary<string, DataTable> listField = null;
            if (!CheckTools.isNull(printerList.printerListJson))
            {
                try
                {
                    listField = JsonConvert.DeserializeObject<IDictionary<string, DataTable>>(printerList.printerListJson);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("CallServiceThread序列化异常：" + e.Message);
                    error = e.Message;
                }
            }
            //序列化出错
            if (error != null)
            {
                printerList.printResult = 2;
                printerList.errorMsg = error;
                return printerList;
            }
            if ((fixedField == null || fixedField.Count == 0) && (listField == null || listField.Count == 0))
            {
                error = "打印模板内容参数printerJson或printerListJson不允许同时为空";
                printerList.printResult = 2;
                printerList.errorMsg = error;
                return printerList;
            }
            string filename;
            int dot = printerList.templateFileName.IndexOf(".");
            if (dot == -1)
            {
                filename = printerList.templateFileName;
                printerList.templateFileName += ".xlsx";
            }
            else
            {
                filename = printerList.templateFileName.Substring(0, dot);
            }
            string exportOutFileName = filename + "_";
            if (printerList.listId == null)
            {
                exportOutFileName += StaticUtil.ConvertDateTimeToTimestamp(printerList.requestTime);
            }
            else
            {
                exportOutFileName += printerList.listId;
            }
            try
            {
                string excelFileName = new ExcelUtil().TemplateExport(printerList.templateFileName, exportOutFileName, fixedField, listField);
                if (printerList.command == null)
                {
                    printerList.command = "print";

                }
                if (string.Equals("print", printerList.command, StringComparison.CurrentCultureIgnoreCase))
                {
                    StaticUtil.Print(excelFileName);
                }
                //打印结果0待打印1打印成功2打印失败
                printerList.printResult = 1;
                printerList.errorMsg = "ACK";
            }
            catch (Exception e)
            {
                Console.WriteLine("CallServiceThread.ExcelUtil.TemplateExport异常" + e);
                error = e.Message;
                printerList.printResult = 2;
                printerList.errorMsg = error;
            }

            return printerList;
        }
    }
}
