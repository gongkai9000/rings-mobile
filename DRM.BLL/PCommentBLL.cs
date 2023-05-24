using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.DAL;
using DRM.Entity;

namespace DRM.BLL
{
    public class PCommentBLL
    {
        PCommentDAL pcommentdal = new PCommentDAL();

        #region 查询
        /// <summary>
        /// 获取评论分页列表
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pagesize"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public List<T_Comment> GetCommentList(int productId, int pagesize, int current)
        {

            return pcommentdal.GetCommentList(productId, pagesize, current);
        }

        /// <summary>
        /// 获取评论分页数
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public int GetCommentPageList(int productId, int pagesize)
        {
            return pcommentdal.GetCommentPageList(productId, pagesize);
        }


        #endregion
    }
}
