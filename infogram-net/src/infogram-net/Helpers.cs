using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace infogram_net
{
    internal static class Helpers
    {
    //    public static byte[] StringToByteArray(string hex)
    //    {
    //        int NumberChars = hex.Length;
    //        byte[] bytes = new byte[NumberChars / 2];
    //        for (int i = 0; i < NumberChars; i += 2)
    //            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
    //        return bytes;
    //    }

        public static string CalculateRFC2104HMAC(string data, string key)
        {
            byte[] keyData = Encoding.ASCII.GetBytes(key);
            HMACSHA1 hmac = new HMACSHA1(keyData);
            byte[] stringBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(hmac.ComputeHash(stringBytes));
        }

        public static string EncodedParameterStringFromList(IEnumerable<Parameter> parameters)
        {
            StringBuilder s = new StringBuilder();
            foreach (var p in parameters)
            {
                if (s.Length > 0)
                    s.Append("&");

                s.Append(WebUtility.UrlEncode(p.Key));
                s.Append("=");
                s.Append(WebUtility.UrlEncode(p.Value).Replace("+", "%20"));
            }

            return s.ToString();
        }

        public static string ComputeSignature(string baseUrl, string requestMethod, List<Parameter> parameters, string apiSecret)
        {
            string sigBase = string.Concat(WebUtility.UrlEncode(requestMethod), "&",
                    WebUtility.UrlEncode(baseUrl));

            parameters.Sort();

            string paramString = Helpers.EncodedParameterStringFromList(parameters);

            sigBase += "&" + WebUtility.UrlEncode(paramString);

            return Helpers.CalculateRFC2104HMAC(sigBase, apiSecret);
        }
    }
}
