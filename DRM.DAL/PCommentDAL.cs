using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using System.Data.Objects;


namespace DRM.DAL
{
    /// <summary>
    /// 产品评论
    /// </summary>
    public class PCommentDAL
    {

        #region 查询
        /// <summary>
        /// 获取评论分页列表
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pagesize"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public List<T_Comment> GetCommentList(int productId,int pagesize,int current)
        {
            using (var db = new DarryJewelryEntities())
            {
                List<T_Comment> list = (from c in db.T_Comment
                                        where c.ProductId == productId
                                        orderby c.addtime descending
                                        select c).Skip(pagesize * current).Take(pagesize).ToList();
                return list;
            }  

        }

        /// <summary>
        /// 获取评论分页数
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public int GetCommentPageList(int productId, int pagesize)
        {
            using (var db = new DarryJewelryEntities())
            {
                var list1 = (from c in db.T_Comment
                             where c.ProductId == productId
                             select c).Count();

                if (list1 > 0)
                {
                    return list1 / pagesize;
                }
                else
                {
                    return 0;
                }
            }
        }


        #endregion

    }
}
