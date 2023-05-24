using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class nCommentBLL
    {
        nCommentDAL cDal = new nCommentDAL();
        /// <summary>
        /// 获取评论
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="datacount"></param>
        /// <returns></returns>
        public List<T_Comment> getList(int pid, int pagesize, int pageindex,out int datacount)
        {
            //Product product = new Product();

            //nProductBLL nbll = new nProductBLL();
            //product= nbll.GetProductById(pid);
            
            return cDal.getList(pid, pagesize, pageindex,out datacount);
        }


        /// <summary>
        /// 获取待评论商品
        /// </summary>
        /// <returns></returns>
        public List<view_ordercomment> getNoCommentOrder(int memberid, int pagesize, int pageindex, out int datacount)
        {
            return cDal.getNoCommentOrder(memberid, pagesize, pageindex, out datacount);
        }

        /// <summary>
        /// 获取待评论商品
        /// </summary>
        /// <returns></returns>
        public List<view_ordercomment> getNoCommentOrder(string orderid)
        {
            return cDal.getNoCommentOrder(orderid);
        }

        public int getNoCommentOrderCount(int memberid)
        {
            return cDal.getNoCommentOrderCount(memberid);
        }

        /// <summary>
        /// 获取已评论商品
        /// </summary>
        /// <returns></returns>
        public List<view_ordercomment> getCommentOrder(int memberid, int pagesize, int pageindex, out int datacount)
        {
            return cDal.getCommentOrder(memberid, pagesize, pageindex, out datacount);
        }

        public bool AddComment(T_Comment c)
        {
            //c.postip = Framework.Common.WebRequest.GetIP();
            c.addtime = DateTime.Now;
            nCommentDAL cDal = new nCommentDAL();
            return cDal.AddComment(c);
        }

        public int getCommentCountByProduct(int pid)
        {
            nCommentDAL cDal = new nCommentDAL();
            return cDal.getCommentCountByProduct(pid);
        }

        /// <summary>
        /// 是否有评论权限
        /// </summary>
        /// <returns></returns>
        public bool isCommentRole(int orderdetailid)
        {
            return cDal.isCommentRole(orderdetailid);
        }
    }
}
