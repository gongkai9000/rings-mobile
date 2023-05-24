using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class nCommentDAL
    {
        public List<T_Comment> getList(int? pid, int pagesize, int pageindex, out int datacount)
        {
            using (var db = new DarryJewelryEntities())
            {
                Product product = new Product();
                nProductDAL pDal = new nProductDAL();
                product = pDal.GetProductById(pid.Value);
                datacount = db.T_Comment.Count(t => t.ProductId == pid || t.ProductId == product.oldId);
                return db.T_Comment.Where(t => t.ProductId == pid || t.ProductId == product.oldId).OrderByDescending(t => t.Id).Skip(pageindex * pagesize).Take(pagesize).ToList();
            }
        }

        /// <summary>
        /// 获取待评论商品
        /// </summary>
        /// <returns></returns>
        public List<view_ordercomment> getNoCommentOrder(int memberid, int pagesize, int pageindex, out int datacount)
        {
            using (var db = new DarryJewelryEntities())
            {
                datacount = db.view_ordercomment.Count(t => t.userid == memberid && !t.CommentID.HasValue);
                return db.view_ordercomment.Where(t => t.userid == memberid && !t.CommentID.HasValue).ToList();
            }
        }

        /// <summary>
        /// 获取待评论商品
        /// </summary>
        /// <returns></returns>
        public List<view_ordercomment> getNoCommentOrder(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_ordercomment.Where(t => t.orderId == orderid && !t.CommentID.HasValue).ToList();
            }
        }

        public int getNoCommentOrderCount(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_ordercomment.Count(t => t.userid == memberid && !t.CommentID.HasValue);
            }
        }

        /// <summary>
        /// 获取已评论商品
        /// </summary>
        /// <returns></returns>
        public List<view_ordercomment> getCommentOrder(int memberid, int pagesize, int pageindex, out int datacount)
        {
            using (var db = new DarryJewelryEntities())
            {
                datacount = db.view_ordercomment.Count(t => t.userid == memberid && t.CommentID.HasValue);
                return db.view_ordercomment.Where(t => t.userid == memberid && t.CommentID.HasValue).ToList();
            }
        }

        public bool AddComment(T_Comment c)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Comment.AddObject(c);
                return db.SaveChanges() > 0;
            }
        }

        public int getCommentCountByProduct(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                Product product = new Product();
                nProductDAL pDal = new nProductDAL();
                product = pDal.GetProductById(pid);
                return db.T_Comment.Count(t => t.ProductId == pid || t.ProductId == product.oldId);
            }
        }

        /// <summary>
        /// 是否有评论权限
        /// </summary>
        /// <returns></returns>
        public bool isCommentRole(int orderdetailid)
        {
            using (var db = new DarryJewelryEntities())
            {
                if (db.T_OrderDetail.Any(t => t.Id == orderdetailid))
                {
                    if (!db.T_Comment.Any(t => t.orderDetailId == orderdetailid))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
