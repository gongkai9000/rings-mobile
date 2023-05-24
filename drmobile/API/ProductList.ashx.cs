using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL.Order;
using DRM.BLL;
using DRM.Common;
using System.Web.SessionState;
using DRM.Entity;
using System.Transactions;
using System.Web.Script.Serialization;

namespace drmobile.API
{
    /// <summary>
    /// ProductList 的摘要说明
    /// </summary>
    public class ProductList : IHttpHandler
    {
        ProductBLL productbll = new ProductBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            string action = context.Request.QueryString["cmd"];

            switch (action)
            {
                case "ctloves":
                    this.GetProductByDarryRign(context);
                    break;
                case "jew":
                    this.GetProductByJew(context);
                    break;
                case "jew2":
                    this.GetProductByJew(context);
                    break;
            }
        }

        private void GetProductByJewbak(HttpContext context)
        {
            ProTypeBll ptbll = new ProTypeBll();
            List<view_product2> list = new List<view_product2>();
            int type = int.Parse(context.Request["type"] ?? "0");
            int top = Convert.ToInt32(context.Request.QueryString["top"]);
            if (type == 0)
            {
                List<int> ints = ptbll.GetChidlTypeList(36).Select(t => t.id).ToList();
                ints.Add(3);
                list = productbll.GetList(ints, top);
            }
            else
            {
                list = productbll.GetList(type, top);
            }

            string url = string.Empty;
            List<int> intlList = ptbll.GetChidlTypeList(36).Select(t => t.id).ToList();

            string pstr = "";
            if (list != null)
            {
                foreach (view_product2 p in list)
                {
                    if (p != null)
                    {

                        if (p.productTypeId == ProductBLL.ManJiezi)
                        {
                            url = "/manring_detail.aspx";
                        }
                        else if (p.productTypeId.ToString() == "3")
                        {
                            url = "/phonics_details.aspx";
                        }
                        else if (intlList.Contains(p.productTypeId))
                        {
                            url = "/jewellery_detail.aspx";
                        }

                        pstr +=
                            string.Format(
                                "<li> <div class='mbdr_cp-img'><a href='" + url + "?id={0}'><img alt='" + p.title + "' src='{1}' width='140px' height='140px'> </a> </div><div class='mbdr_cp-word'><p class='hsp-height'>{2}</p><p><span class='fl'>￥{3} </span></p>",
                                p.id, p.imgurl,
                              StringHelper.SubString(p.title,20), p.MemberPrice.Value.ToString("N0"), p.salecount);

                    }
                }

            }

            if (list.Count == 0)
            {
                context.Response.Write("s");
            }
            else
            {
                context.Response.Write(pstr);
            }
        }

        private void GetProductByDarryRignbak(HttpContext context)
        {
            List<view_product2> list = new List<view_product2>();
            int type = int.Parse(context.Request["type"] ?? "1");
            int top = Convert.ToInt32(context.Request.QueryString["top"]);
            list = productbll.GetList(type, top);
            string pstr = "";
            if (list != null)
            {
                foreach (view_product2 p in list)
                {
                    if (p != null)
                    {
                        pstr +=
                            string.Format(
                                "<li> <div class='mbdr_cp-img'><a href='dring_detail.aspx?id={0}'><img alt='" + p.title + "' src='{1}' width='140px' height='140px'> </a> </div><div class='mbdr_cp-word'><p class='hsp-height'>{2}</p><p><span class='fl'>￥{3}</span></p>",
                                p.id, p.imgurl,
                              StringHelper.SubString(p.title, 20) + " " + GetCtStr(p.zct) + " " +
                                GetClolor(p.zcolor), p.MemberPrice.Value.ToString("N0"), p.salecount);

                    }
                }

            }

            if (list.Count == 0)
            {
                context.Response.Write("s");
            }
            else
            {
                context.Response.Write(pstr);
            }
        }


        private void GetProductByJew(HttpContext context)
        {
            ProTypeBll proTypeBll = new ProTypeBll();
            List<view_product2> viewProduct2List = new List<view_product2>();
            int typeid = int.Parse(context.Request["type"] ?? "0");
            int int32 = Convert.ToInt32(context.Request.QueryString["top"]);
            List<view_product2> list1;
            if (typeid == 0)
            {
                List<int> list2 = proTypeBll.GetChidlTypeList(36).Select<ProductType, int>((Func<ProductType, int>)(t => t.id)).ToList<int>();
                list2.Add(3);
                list1 = this.productbll.GetList(list2, int32);
            }
            else
                list1 = this.productbll.GetList(typeid, int32);
            string str = string.Empty;
            List<int> list3 = proTypeBll.GetChidlTypeList(36).Select<ProductType, int>((Func<ProductType, int>)(t => t.id)).ToList<int>();
            string s = "";
            if (list1 != null)
            {
                foreach (view_product2 viewProduct2 in list1)
                {
                    if (viewProduct2 != null)
                    {
                        if (viewProduct2.productTypeId == ProductBLL.ManJiezi)
                            str = "/manring_detail.aspx";
                        else if (viewProduct2.productTypeId.ToString() == "3")
                            str = "/phonics_details.aspx";
                        else if (list3.Contains(viewProduct2.productTypeId))
                            str = "/jewellery_detail.aspx";
                        s += string.Format("<li> <div class='mbdr_cp-img'><a href='" + str + "?id={0}'><img alt='" + viewProduct2.title + "' src='{1}' width='140px' height='140px'> </a> </div><div class='mbdr_cp-word'><p class='hsp-height'>{2}</p><p><span class='fl'>￥{3} </span></p>", (object)viewProduct2.id, (object)viewProduct2.imgurl, (object)StringHelper.SubString(viewProduct2.title, 20), (object)viewProduct2.MemberPrice.Value.ToString("N0"), (object)viewProduct2.salecount);
                    }
                }
            }
            if (list1.Count == 0)
                context.Response.Write("s");
            else
                context.Response.Write(s);
        }

        private void GetProductByDarryRign(HttpContext context)
        {
            List<view_product2> viewProduct2List = new List<view_product2>();
            List<view_product2> list = this.productbll.GetList(int.Parse(context.Request["type"] ?? "1"), Convert.ToInt32(context.Request.QueryString["top"]));
            string s = "";
            if (list != null)
            {
                foreach (view_product2 viewProduct2 in list)
                {
                    if (viewProduct2 != null)
                        s += string.Format("<li> <div class='mbdr_cp-img'><a href='ctring_detail.aspx?id={0}'><img alt='" + viewProduct2.title + "' src='{1}' width='140px' height='140px'> </a> </div><div class='mbdr_cp-word'><p class='hsp-height'>{2}</p><p><span class='fl'>￥{3}</span></p>", (object)viewProduct2.id, (object)viewProduct2.imgurl, (object)(StringHelper.SubString(viewProduct2.title, 20) + " " + this.GetCtStr((object)viewProduct2.zct) + " " + this.GetClolor((object)viewProduct2.zcolor)), (object)viewProduct2.MemberPrice.Value.ToString("N0"), (object)viewProduct2.salecount);
                }
            }
            if (list.Count == 0)
                context.Response.Write("s");
            else
                context.Response.Write(s);
        }

        /// <summary>
        /// 获取钻重信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetCtStr(Object obj)
        {
            string str = "";
            if (obj != null)
            {
                if (obj != "")
                {
                    double s = Convert.ToDouble(obj);
                    str = (s * 100) + "分";
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        /// <summary>
        /// 获取钻石颜色
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetClolor(Object obj)
        {
            string str = "";
            if (obj != null)
            {
                if (obj != "")
                {
                    str = Convert.ToString(obj) + "色";
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}