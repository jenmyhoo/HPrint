using System.Collections.Generic;
using System.Net;

namespace common.bean
{
    public class RequestDataBean
    {
        private static string DEFAULT_USER_AGENT = StaticUtil.GetOSVersion() + " Print/" + StaticUtil.VERSION;
        //1POST 2GET
        private int method = 1;
        private string url;
        private string charset = StaticUtil.DEFAULT_CHARSET;
        private int timeout = 60000;
        private IDictionary<string, string> headers;
        private IDictionary<string, string> parameters;
        private CookieCollection cookies;

        public RequestDataBean()
        {
            headers = new Dictionary<string, string>();
            headers.Add("Accept", "*/*");
            //headers.Add("Accept", "application/json, text/plain, */*");
            headers.Add("Accept-Encoding", "gzip, deflate");
            headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            headers.Add("User-Agent", DEFAULT_USER_AGENT);
            //headers.Add("Connection", "keep-alive");//POST
            //headers.Add("Content-Type", "application/x-www-form-urlencoded");//POST
        }

        public string GetHeader(string key)
        {
            string value;
            try
            {
                headers.TryGetValue(key, out value);
            }
            catch
            {
                value = null;
            }

            return value;
        }

        public IDictionary<string, string> GetHeaders()
        {
            return headers;
        }

        public void AddHeaders(string key, string value)
        {
            headers.Add(key, value);
        }

        public int Method
        {
            get
            {
                return method;
            }

            set
            {
                method = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Charset
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

        public int Timeout
        {
            get
            {
                return timeout;
            }

            set
            {
                timeout = value;
            }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                return parameters;
            }

            set
            {
                parameters = value;
            }
        }

        public CookieCollection Cookies
        {
            get
            {
                return cookies;
            }

            set
            {
                cookies = value;
            }
        }
    }
}
