using System;
using System.Net;

namespace common.bean
{
    [Serializable]
    public class UserCookieBean
    {
        public Int32? userId { get; set; }
        public String companyCode { get; set; }
        public String loginName { get; set; }
        public String userName { get; set; }
        public String cookie_session { get; set; }
        private CookieCollection cookies = new CookieCollection();

        public UserCookieBean() { }

        public CookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }
}
