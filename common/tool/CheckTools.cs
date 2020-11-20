using System.Net;
using System.Text.RegularExpressions;

namespace common.tool
{
    public class CheckTools
    {
        private static Regex emailRegex = new Regex("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        private static Regex urlRegex = new Regex("^([a-z]+://)?((\\w+(-\\w+)*)\\.)+(\\w+)(:\\d{1,5})?(/\\w*\\.?\\w*)*(\\?\\S*)?$");
        private static Regex telRegex = new Regex("((\\+)?[0-9]{0,4}(\\-)?[0-9]{6,8}(\\-[0-9]{3,5})?(\\,)?)*");
        private static Regex mobileRegex = new Regex("1[3-9]\\d{9}");
        private static Regex zipRegex = new Regex("[0-9]{6}");
        private static Regex integerRegex = new Regex("[-|\\+]?\\d+");
        private static Regex pointRegex = new Regex("^[-|\\+]?\\d+(\\.\\d+)?$");
        private static Regex positiveRegex = new Regex("\\d+");
        private static Regex englishRegex = new Regex("[\\w]+");

        public static bool isNull(string s)
        {
            return (s == null) || ("" == s.Trim());
        }

        /**
         * 验证email
         *
         * @param s
         * @return
         */
        public static bool isEmail(string s)
        {
            if (isNull(s))
            {
                return false;
            }
            else
            {
                return emailRegex.IsMatch(s);
            }
        }

        /**
         * 验证url
         *
         * @param s
         * @return
         */
        public static bool isUrl(string s)
        {
            if (isNull(s))
            {
                return false;
            }
            //已转换小字无需比对大写
            s = s.ToLower();
            return urlRegex.IsMatch(s);
        }

        /**
         * 验证固定电话号码
         *
         * @param s
         * @return
         */
        public static bool isTelphone(string s)
        {
            if (isNull(s))
            {
                return false;
            }
            return telRegex.IsMatch(s);
        }

        /**
         * 验证是否是手机号格式
         * 该方法还不是很严谨,只是可以简单验证
         *
         * @param mobile 手机号码
         * @return true表示是正确的手机号格式, false表示不是正确的手机号格式
         */
        public static bool isMobile(string mobile)
        {
            //当前运营商号段分配
            //中国移动号段 1340-1348 135 136 137 138 139 150 151 152 157 158 159 187 188 147 198
            //中国联通号段 130 131 132 155 156 185 186 145 166
            //中国电信号段 133 1349 153 180 189 199
            //虚拟运营商号 170
            //新增16号段 新增19号段
            if (isNull(mobile))
            {
                return false;
            }
            else
            {
                return mobileRegex.IsMatch(mobile);
            }
        }

        /**
         * 验证邮政编码
         *
         * @param code
         * @return
         */
        public static bool isZipCode(string code)
        {
            if (isNull(code))
            {
                return false;
            }
            return zipRegex.IsMatch(code);
        }

        /**
         * 验证正负整数
         *
         * @param num
         * @return
         */
        public static bool isNumber(string num)
        {
            if (isNull(num))
            {
                return false;
            }
            else
            {
                return integerRegex.IsMatch(num);
            }
        }

        /**
         * 验证浮点数
         *
         * @param code
         * @return
         */
        public static bool isPoint(string code)
        {
            if (isNull(code))
            {
                return false;
            }
            return pointRegex.IsMatch(code);
        }

        /**
         * 验证正整数
         *
         * @param code
         * @return
         */
        public static bool isPositiveNumber(string code)
        {
            if (isNull(code))
            {
                return false;
            }
            else
            {
                return positiveRegex.IsMatch(code);
            }
        }

        /**
         * 判断是否是日期格式字符串
         *
         * @param dateStr
         * @return
         */
        public static bool isDate(string date)
        {
            if (isNull(date))
            {
                return false;
            }
            else
            {
                string dateRegex = "^(" +
                        "(\\d{2}(([02468][048])|([13579][26]))" +
                        "[\\-\\/\\s]?((((0?[13578])|(1[02]))[\\-\\/\\s]?((0?[1-9])|([1-2][0-9])|" +
                        "(3[01])))|(((0?[469])|(11))[\\-\\/\\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\\-\\/\\s]?" +
                        "((0?[1-9])|([1-2][0-9])))))" +
                        "|(\\d{2}(([02468][1235679])|([13579][01345789]))[\\-\\/\\s]?" +
                        "((((0?[13578])|(1[02]))[\\-\\/\\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\\-\\/\\s]?" +
                        "((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\\-\\/\\s]?((0?[1-9])|(1[0-9])|(2[0-8])))))" +
                        ")?" +
                        "(\\s?(((0?[0-9])|([1][0-9])|([2][0-4]))\\:?([0-5]?[0-9])((\\s)|(\\:?([0-5]?[0-9])))?(\\.[0-9]{1,9})?))?$";
                Regex regex = new Regex(dateRegex);
                return regex.IsMatch(date);
            }
        }

        /**
         * 判断是否英文字符
         *
         * @param s
         * @return
         */
        public static bool isEnglish(string s)
        {
            if (isNull(s))
            {
                return false;
            }
            return englishRegex.IsMatch(s);
        }

        public static bool isIp(string s)
        {
            if (isNull(s))
            {
                return false;
            }
            IPAddress address;
            return IPAddress.TryParse(s,out address);
        }
    }
}
