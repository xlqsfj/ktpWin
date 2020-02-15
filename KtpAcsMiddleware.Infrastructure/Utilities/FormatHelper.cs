using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public static class FormatHelper
    {
        public static string GetString(string value)
        {
            return value ?? string.Empty;
        }
        /// <summary>
        /// ��ֹ�ַ���
        /// </summary>
        /// <param name="text">����</param>
        /// <param name="begin">������ȡ������</param>
        /// <param name="end">������ȡ������</param>
        /// <returns>����Ҫ������,��ƥ�䷵�ؿ�</returns>
        public static string GetStringIntercept(string text, string begin, string end)
        {

            Regex reg = new Regex(@"^.+?" + begin + "(.+?)" + end + "+?");

            string NameText = null;
            Match math = reg.Match(text);

            if (math.Success)
            {
                NameText = math.Groups[1].Value;
            }
            return NameText;
        }
        /// <summary>
        /// �û�תbase
        /// </summary>
        /// <param name="user">�û���</param>
        /// <param name="pwd">����</param>
        /// <returns></returns>
        public static string GetUserPwdToBase(string user, string pwd)
        {

            string usernamePassword = $"{user}:{pwd}";

            byte[] bytes = Encoding.Default.GetBytes(usernamePassword);
            return Convert.ToBase64String(bytes);
        }

        public static string GetLengthString(string value, int length = 50)
        {
            if (length < 8 || value.Length < length)
                return value;
            return $"{value.Substring(0, length - 7)}......";
        }

        public static string GetDecimalString(decimal? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString(CultureInfo.InvariantCulture);
        }
        public static string GetToString(dynamic value)
        {
            if (value == null)
                return string.Empty;

            return value.ToString();
        }
        /// <summary>
        /// תstring�����в���
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
        /// <returns></returns>
        public static string GetToString(dynamic value, dynamic defaultValue)
        {
            if (value == null)
            {
                if (defaultValue != null)
                {
                    return defaultValue;
                }
                return string.Empty;
            }


            return value.ToString();
        }

        public static int GetInt(int? value)
        {
            return value ?? 0;
        }

        public static decimal? GetDecimal(string value)
        {
            if (value == null)
                return null;
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     ��ȡ DateTime to "yyyy-MM-dd"��ʽ�ַ���
        /// </summary>
        public static string GetIsoDateString(DateTime? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     ��ȡ DateTime to "yyyy-MM-dd"��ʽ�ַ���
        /// </summary>
        public static string GetNonNullIsoDateString(DateTime value)
        {
            if (value == DateTime.MinValue)
                return string.Empty;
            return value.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     ��ȡ DateTime to "yyyy-MM-dd HH:mm:ss"��ʽ�ַ���
        /// </summary>
        public static string GetIsoDateTimeString(DateTime? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetIsoDateTimeTString(DateTime? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        public static string GetNonNullIntString(int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetIntString(int? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString(CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// ת��Ϊ����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringToInt(string str)
        {
            return StringToInt(str, 0);
        }
        /// <summary>
        /// ת��Ϊ����
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <param name="defaultvalue">����ʱ���ص�Ĭ��ֵ</param>
        /// <returns></returns>
        public static int StringToInt(dynamic str, dynamic defaultvalue)
        {
            if (str == null)
            {

                return defaultvalue;

            }

            if (ValidateHelper.IsNumberSign(str))
            {
                return int.Parse(str);
            }
            return 0;
        }
        /// <summary>
        /// ת��Ϊdouble����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double String2Double(string str)
        {
            if (ValidateHelper.IsDecimal(str))
            {
                return double.Parse(str);
            }
            return 0.0;
        }
        /// <summary>
        /// ת��Ϊʱ������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string str)
        {
            if (ValidateHelper.IsDateTime(str))
            {
                return DateTime.Parse(str);
            }
            return DateTime.Parse("1900-1-1");
        }
        public static string GetLongString(long? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetBooleanString(bool value)
        {
            if (value)
                return "��";

            return "��";
        }
        /// <summary>
        /// stringתboo1Ĭ��false
        /// </summary>
        /// <param name="value">string����</param>
        /// <returns></returns>
        public static bool GetStringToBoolean(string value)
        {
            if (value == null)
                return false;

            return Convert.ToBoolean(value);
        }
        /// <summary>
        ///     ����"yyyy/MM/dd"��ȡDateTime
        /// </summary>
        public static DateTime GetNonNullDateValueNoErro(string value)
        {
            if (value == null)
                return default(DateTime);
            try
            {
                return DateTime.ParseExact(value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return default(DateTime);
            }
        }

        /// <summary>
        ///     ����"yyyy/MM/dd"��ȡDateTime
        /// </summary>
        public static DateTime? GetDateValueNoErro(string value)
        {
            if (value == null)
                return null;
            try
            {
                return DateTime.ParseExact(value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     ����"yyyy-MM-dd HH:mm:ss"��ȡDateTime
        /// </summary>
        public static DateTime? GetIsoDateValue(string value)
        {
            try
            {
                if (value.Length == 10)
                {
                    return DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
                if (value.Length == 16)
                {
                    return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                }
                return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     ����"yyyy-MM-dd HH:mm:ss"��ȡDateTime
        /// </summary>
        public static DateTime GetNonNullIsoDateValue(string value)
        {
            if (value == null)
                return default(DateTime);

            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     ����"yyyyMMddHHmmss"��ȡDateTime
        /// </summary>
        public static DateTime GetNonNullNumDateValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DateTime.Now;
            if (value.Length == 6)
            {
                return DateTime.ParseExact(value, "yyyyMd", CultureInfo.InvariantCulture);
            }
            if (value.Length == 8)
            {
                return DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            if (value.Length == 12)
            {
                return DateTime.ParseExact(value, "yyyyMMddHHmm", CultureInfo.InvariantCulture);
            }
            if (value.Length == 14)
            {
                return DateTime.ParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            }

            return Convert.ToDateTime(value);
        }

        /// <summary>
        ///     ����"yyyyMMddHHmmss"��ȡDateTime
        /// </summary>
        public static DateTime GetNonNullNumDateValueNotErro(string value)
        {
            try
            {
                return GetNonNullNumDateValue(value);
            }
            catch
            {
                return default(DateTime);
            }
        }

        /// <summary>
        ///     ��ȡDateTime��ʱ�䲿��"HH:mm:ss"
        /// </summary>
        public static string GetTimeString(DateTime? value)
        {
            if (value == null)
                return string.Empty;

            return value.Value.ToString("HH:mm:ss");
        }

        /// <summary>
        ///     ��ȡ DateTime to ʱ���
        /// </summary>
        public static int GetDateTimeStamp(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        ///     ��ȡ ʱ��� to DateTime
        /// </summary>
        public static DateTime GetDateTimeFromStamp(string stamp)
        {
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var lTime = long.Parse(stamp + "0000000");
            var toNow = new TimeSpan(lTime);

            return dtStart.Add(toNow);
        }

        /// <summary>
        ///     ��ȡ ʱ��� to DateTime
        ///     �����쳣
        /// </summary>
        public static DateTime? GetDateTimeFromStampIgnoreEx(string stamp)
        {
            try
            {
                return GetDateTimeFromStamp(stamp);
            }
            catch
            {
                return null;
            }
        }
    }
}