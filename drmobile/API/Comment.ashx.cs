using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Entity;
using DRM.Common;
using DRM.BLL;

namespace drmobile.API
{
    /// <summary>
    /// Comment 的摘要说明
    /// </summary>
    public class Comment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["action"] == "add")
            {
                nCommentBLL cBll = new nCommentBLL();
                
                if(!cBll.isCommentRole(int.Parse(context.Request.Form["OrderDetailID"])))
                {
                    context.Response.Clear();
                    context.Response.Write("权限不足");
                    context.Response.End();
                }

                T_Comment comment = new T_Comment();
                comment.satisfaction = context.Request.Form["satisfaction"];
                comment.Evaluation = context.Request.Form["evaluation"];
                comment.recontent = context.Request.Form["recontent"];

                comment.orderid = context.Request.Form["orderid"];

                comment.ProductId = Convert.ToInt32(context.Request.Form["pid"]);
                comment.postip = CommonFun.GetIp();
                comment.userid = CurrentUser.CurrentUid;
                comment.UserName = CurrentUser.Member.nickname;
                comment.orderDetailId = int.Parse(context.Request.Form["OrderDetailID"]);

                cBll.AddComment(comment);
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