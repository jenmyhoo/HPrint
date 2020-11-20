using common.bean;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace common.tool
{
    public class HttpRequestClientUtil
    {
        public static string doGet(string url, string charset, int timeout, IDictionary<string, string> headers, CookieCollection cookies)
        {
            RequestDataBean requestDataBean = new RequestDataBean();
            requestDataBean.Method = 1;
            requestDataBean.Url = url;
            if (!CheckTools.isNull(charset))
            {
                requestDataBean.Charset = charset;
            }
            if (timeout > 0)
            {
                requestDataBean.Timeout = timeout;
            }
            if (headers != null)
            {
                string key, value;
                foreach (KeyValuePair<string, string> kv in headers)
                {
                    key = kv.Key;
                    value = kv.Value;
                    if (CheckTools.isNull(key))
                    {
                        continue;
                    }
                    if (CheckTools.isNull(value))
                    {
                        continue;
                    }
                    if (requestDataBean.GetHeaders().ContainsKey(key))
                    {
                        requestDataBean.GetHeaders().Remove(key);
                    }
                    requestDataBean.GetHeaders().Add(key, value);
                }
            }

            requestDataBean.Cookies = cookies;


            return doRequest(requestDataBean);
        }

        public static string doPost(string url, string charset, int timeout,
            IDictionary<string, string> headers, IDictionary<string, string> parameters, CookieCollection cookies)
        {
            RequestDataBean requestDataBean = new RequestDataBean();
            requestDataBean.Method = 1;
            requestDataBean.Url = url;
            if (!CheckTools.isNull(charset))
            {
                requestDataBean.Charset = charset;
            }
            if (timeout > 0)
            {
                requestDataBean.Timeout = timeout;
            }
            if (!requestDataBean.GetHeaders().ContainsKey("Connection"))
            {
                requestDataBean.GetHeaders().Add("Connection", "keep-alive");
            }
            if (headers != null)
            {
                string key, value;
                foreach (KeyValuePair<string, string> kv in headers)
                {
                    key = kv.Key;
                    value = kv.Value;
                    if (CheckTools.isNull(key))
                    {
                        continue;
                    }
                    if (CheckTools.isNull(value))
                    {
                        continue;
                    }
                    if (requestDataBean.GetHeaders().ContainsKey(key))
                    {
                        requestDataBean.GetHeaders().Remove(key);
                    }
                    requestDataBean.GetHeaders().Add(key, value);
                }
            }

            requestDataBean.Parameters = parameters;
            requestDataBean.Cookies = cookies;


            return doRequest(requestDataBean);
        }

        private static string doRequest(RequestDataBean requestDataBean)
        {
            if (!CheckTools.isUrl(requestDataBean.Url))
            {
                throw new ArgumentException("URL is illegal!");
            }
            Encoding encoding = Encoding.GetEncoding(requestDataBean.Charset);
            HttpWebRequest httpWebRequest = CreateWebRequest(requestDataBean, encoding);
            if (httpWebRequest == null)
            {
                return null;
            }
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                return GetResponseBody(httpWebResponse, encoding);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                }
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
            }
        }

        public static string GetCookieValue(CookieCollection cookies, string cookieName)
        {
            string result = string.Empty;
            foreach (Cookie cookie in cookies)
            {
                if (cookie.Name == cookieName)
                {
                    result = cookie.Value;
                    break;
                }
            }
            return result;
        }

        private static HttpWebRequest CreateWebRequest(RequestDataBean requestDataBean, Encoding encoding)
        {
            try
            {
                //提升系统外联的最大并发web访问数
                ServicePointManager.DefaultConnectionLimit = 1024;
                ServicePointManager.Expect100Continue = false;
                Uri uri = new Uri(requestDataBean.Url);
                StringBuilder sb = new StringBuilder();
                string secheme = uri.Scheme;
                string host = sb.Append(uri.Host).Append(uri.IsDefaultPort ? "" : (":" + uri.Port)).ToString();
                sb.Clear();
                string origin = sb.Append(secheme).Append("://").Append(host).ToString();
                sb.Clear();
                HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
                httpWebRequest.Timeout = requestDataBean.Timeout;
                httpWebRequest.Host = host;
                string key, value;
                foreach (KeyValuePair<string, string> kv in requestDataBean.GetHeaders())
                {
                    key = kv.Key;
                    value = kv.Value;
                    if (CheckTools.isNull(key))
                    {
                        continue;
                    }
                    if (CheckTools.isNull(value))
                    {
                        continue;
                    }
                    if ("Accept".Equals(key))
                    {
                        httpWebRequest.Accept = value;
                    }
                    else if ("Connection".Equals(key))
                    {
                        if ("keep-alive".Equals(value))
                        {
                            httpWebRequest.KeepAlive = true;
                        }
                    }
                    else if ("Referer".Equals(key))
                    {
                        if (CheckTools.isUrl(value))
                        {
                            httpWebRequest.Referer = value;
                        }
                    }
                    else if ("User-Agent".Equals(key))
                    {
                        httpWebRequest.UserAgent = value;
                    }
                    else
                    {
                        httpWebRequest.Headers.Set(key, value);
                    }
                }
                string headerReferer = requestDataBean.GetHeader("Referer");
                if (!CheckTools.isUrl(headerReferer))
                {
                    headerReferer = sb.Append(origin).Append("/").ToString();
                    sb.Clear();
                    httpWebRequest.Referer = headerReferer;
                }
                string headerOrigin = requestDataBean.GetHeader("Origin");
                if (!CheckTools.isUrl(headerOrigin))
                {
                    httpWebRequest.Headers.Set("Origin", origin);
                }
                if (requestDataBean.Method == 1)
                {
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                }
                else
                {
                    httpWebRequest.Method = "GET";
                }
                CookieCollection cookies = requestDataBean.Cookies;
                if (cookies != null && cookies.Count > 0)
                {
                    if (httpWebRequest.CookieContainer == null)
                    {
                        httpWebRequest.CookieContainer = new CookieContainer();
                    }
                    foreach (Cookie cookie in cookies)
                    {
                        httpWebRequest.CookieContainer.Add(cookie);
                    }
                }
                if (CheckTools.isNull(requestDataBean.Charset))
                {
                    requestDataBean.Charset = "utf-8";
                }
                string postData = null;
                if (requestDataBean.Parameters != null)
                {
                    foreach (KeyValuePair<string, string> kv in requestDataBean.Parameters)
                    {
                        key = kv.Key;
                        value = kv.Value;
                        if (CheckTools.isNull(key))
                        {
                            continue;
                        }
                        if (CheckTools.isNull(value))
                        {
                            continue;
                        }
                        sb.Append("&").Append(key).Append("=").Append(value);
                    }
                    if (sb.Length > 0)
                    {
                        sb.Remove(0, 1);
                        postData = sb.ToString();
                        sb.Clear();
                    }
                }
                if (postData != null && postData.Length > 0)
                {
                    byte[] bytes = encoding.GetBytes(postData);
                    int length = bytes.Length;
                    httpWebRequest.ContentLength = length;
                    using (Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        try
                        {
                            requestStream.Write(bytes, 0, length);
                            requestStream.Flush();

                        }
                        finally
                        {
                            requestStream.Close();
                        }
                    }
                }
                return httpWebRequest;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        private static string GetResponseBody(HttpWebResponse response, Encoding encoding)
        {
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            string text = null;
            Stream responseStream = null;
            try
            {
                responseStream = response.GetResponseStream();
                if (responseStream == null)
                {
                    return null;
                }
                string contentEncoding = response.ContentEncoding.ToLower();
                if (contentEncoding.Contains("gzip"))
                {
                    using (GZipStream gZipStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    {
                        using (StreamReader streamReader = new StreamReader(gZipStream, encoding))
                        {
                            text = streamReader.ReadToEnd();
                            responseStream.Flush();
                            streamReader.Close();
                        }
                        gZipStream.Close();
                    }
                }
                else if (contentEncoding.Contains("deflate"))
                {
                    using (DeflateStream deflateStream = new DeflateStream(responseStream, CompressionMode.Decompress))
                    {
                        using (StreamReader streamReader = new StreamReader(deflateStream, encoding))
                        {
                            text = streamReader.ReadToEnd();
                            responseStream.Flush();
                            streamReader.Close();
                        }
                        deflateStream.Close();
                    }
                }
                else
                {
                    using (StreamReader streamReader = new StreamReader(responseStream, encoding))
                    {
                        text = streamReader.ReadToEnd();
                        responseStream.Flush();
                        streamReader.Close();
                    }
                }
                //Console.WriteLine("================================================");
                //Console.WriteLine(text);
                //Console.WriteLine("================================================");
                text = text.Replace('\0', ' ');
                return text;
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                }
            }
        }
    }
}
