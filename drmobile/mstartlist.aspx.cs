using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using drmobile.master;

namespace drmobile
{
    public partial class mstartlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "明星见证";
            (Master as nSite).IsGray = false;
            this.Title = "CTloves名人推荐_CTloves官网";
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            rptlist.DataSource = new ProposeBLL().GetproList(t =>t.ProposeNewsClassId==50);
            rptlist.DataBind();
        }
        /// <summary>
        /// 截取指定字符串并添加省略号
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="l">长度</param>
        /// <param name="endStr">省略符</param>
        /// <returns></returns>
        public static string getStr2(string s, int l, string endStr)
        {
            s = System.Text.RegularExpressions.Regex.Replace(s, "<[^>]*>", "");
            s = s.ToLower().Replace("&nbsp;", "");
            s = s.ToLower().Replace("　", "");

            string temp = s.Substring(0, (s.Length < l + 1) ? s.Length : l + 1);
            byte[] encodedBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(temp);

            string outputStr = "";
            int count = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if ((int)encodedBytes[i] == 63)
                    count += 2;
                else
                    count += 1;

                if (count <= l - endStr.Length)
                    outputStr += temp.Substring(i, 1);
                else if (count > l)
                    break;
            }

            if (count <= l)
            {
                outputStr = temp;
                endStr = "";
            }

            outputStr += endStr;

            return outputStr;
        }

    }
}