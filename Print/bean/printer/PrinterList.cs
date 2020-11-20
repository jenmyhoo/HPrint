using System;

namespace Print.bean.printer
{
    [Serializable]
    class PrinterList
    {
        public string command { get; set; }
        public long? listId { get; set; }

        public string templateFileName { get; set; }

        public string printerJson { get; set; }

        public string printerListJson { get; set; }

        public int? printerId { get; set; }

        public int? userId { get; set; }

        public string userName { get; set; }

        public string requestTime { get; set; }

        public int printResult { get; set; }

        public string errorMsg { get; set; }

        public PrinterList() { }

        public override string ToString()
        {

            return base.ToString();
        }
    }
}
