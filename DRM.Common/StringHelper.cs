using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DRM.Common
{
    public static class StringHelper
    {
        /// <summary>
        ///　过滤Request.QueryString或Request.Form的有害性字符。
        /// </summary>
        /// <remarks>
        /// input: 要修改的字符串。
        /// index;数组索引
        /// </remarks>
        /// <returns>string</returns>
        public static string ReplaceBad(string input, int index)
        {
            string strreplaceArry = "";
            strreplaceArry = "'|\"|or|&|*|select|insert|delete|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec master|net localgroup administrators| and |net user| or ";
            string[] replacement = strreplaceArry.Split('|');

            try
            {
                for (int i = 0; i < replacement.Length; i++)
                {
                    input.Replace(replacement[i], "");
                }
            }
            catch
            {
                throw;
            }
            return input;
        }

        public static string SubString(string str,int num)
        {
            if (str.Length < num)
            { num = str.Length; }
            return str.Substring(0, num);
        }

        //字符串转换
        public static string StrToP(string mystr, int slength)
        {
            if (!string.IsNullOrEmpty(mystr))
            {
                string oldstr = mystr.Substring(0, slength);
                return oldstr + "**";
            }
            else
            {
                return "匿名**";
            }
        }
    }
}
