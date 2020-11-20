using common.bean;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace common.tool
{
    [Serializable]
    public class AutoVersionInfo
    {
        private int? softId;
        private string softName;
        private string version;
        private string description;
        private int? forced;
        private string url;
        private string md5;
        private int? size;
        private bool isUpdate;

        public int? SoftId
        {
            get
            {
                return softId;
            }

            set
            {
                softId = value;
            }
        }

        public string SoftName
        {
            get
            {
                return softName;
            }

            set
            {
                softName = value;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int? Forced
        {
            get
            {
                return forced;
            }

            set
            {
                forced = value;
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

        public string Md5
        {
            get
            {
                return md5;
            }

            set
            {
                md5 = value;
            }
        }

        public int? Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public bool IsUpdate
        {
            get
            {
                return isUpdate;
            }

            set
            {
                isUpdate = value;
            }
        }

        public AutoVersionInfo() { }

        public static AutoVersionInfo CheckIsUpdate(string version)
        {
            string url = "https://finance.8673h.com/finance/system/getSoftUpdateInfo?softId=1";
            //string url = "http://127.0.0.1:9999/finance/system/getSoftUpdateInfo?softId=1";
            string result = HttpRequestClientUtil.doGet(url, StaticUtil.DEFAULT_CHARSET, 60000, null, null);
            if (CheckTools.isNull(result))
            {
                throw new Exception("获取远程版本数据失败，可能连接已断开");
            }
            Result<AutoVersionInfo> data = JsonConvert.DeserializeObject<Result<AutoVersionInfo>>(result);
            if (data.success && data.bizErrCode == 20000)
            {
                if (data.data == null)
                {
                    throw new Exception("获取远程版本为空，可能后台未设置，请检查您的参数或者联系管理员");
                }
                else
                {
                    AutoVersionInfo app = data.data;
                    app.IsUpdate = compareVersion(version, app.Version);
                    return app;
                }
            }
            else
            {
                throw new Exception(data.defaultRequestFailShow());
            }
        }

        public static bool compareVersion(string localVersion, string remoteVersion)
        {
            if (localVersion == null || remoteVersion == null)
            {
                return true;
            }
            string[] locals = localVersion.Split('.');
            string[] remotes = remoteVersion.Split('.');
            int localLen = locals.Length;
            int remoteLen = remotes.Length;
            int minLen = Math.Min(localLen, remoteLen);
            for (int i = 0; i < minLen; i++)
            {
                //值条件小于零strA 小于 strB。零strA 等于 strB。大于零strA 大于 strB
                if (string.Compare(locals[i], remotes[i], StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
