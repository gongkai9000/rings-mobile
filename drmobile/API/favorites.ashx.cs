using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRI.BLL;
using DRM.Common;
using DRM.Entity;




namespace Web_Diamond11.nAPI
{
    /// <summary>
    /// favorites 的摘要说明
    /// </summary>
    public class favorites : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            //context.Response.Write("Hello World");
            string action = context.Request["action"];
            FavoritesBLL fBll = new FavoritesBLL();
            switch (action)
            {
                case "add":
                    int pid = Convert.ToInt32(context.Request["pid"]);
                    int mid = CurrentUser.CurrentUid;
                    string diamondid = context.Request["diamondid"];
                    string price = context.Request["price"];
                    if (!fBll.IsFavorites(pid, mid))
                    {
                        Favorites f = new Favorites();
                        f.memberid = mid;
                        f.pid = pid;
                        f.addtime = DateTime.Now;

                        f.myParms = diamondid == "" ? null : diamondid;

                        f.Price = price;
                        context.Response.Clear();
                        if (!fBll.AddFavorites(f))
                        {
                            context.Response.Write("收藏失败。");
                        }
                        context.Response.End();
                    }
                    else
                    {
                        context.Response.Clear();
                        context.Response.Write("该商品已收藏过。");
                        context.Response.End();
                    }
                    break;
                case "delete":
                    int id = Convert.ToInt32(context.Request.QueryString["id"]);
                    if (!fBll.deleteFavorites(id))
                    {
                        context.Response.Clear();
                        context.Response.Write("删除失败。");
                        context.Response.End();
                    }
                    break;
            }
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