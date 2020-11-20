using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common.bean
{
    [Serializable]
    public class Result<T>
    {
        public Boolean success { get; set; }
        public String message { get; set; }
        public Int32? bizErrCode { get; set; }
        public String bizErrMsg { get; set; }
        public T data { get; set; }

        public string defaultRequestFailShow()
        {
            message = message == null ? "未知错误" : message;
            bizErrMsg = bizErrMsg == null ? "未获取到响应,请检查您的网络再重试" : bizErrMsg;
            return (success ? "" : message + ":") + bizErrMsg;
        }
    }
}
