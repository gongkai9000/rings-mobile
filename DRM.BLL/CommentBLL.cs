using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DRM.DAL;
using DRM.Entity;

namespace DRM.BLL
{
     public  class CommentBLL
    {
          #region 查询
         public List<T_Comment> GetCommentByProductId(int ProductId, int PageSize)
         {
             CommentDAL commentdal=new CommentDAL();
             return commentdal.GetCommentByProductId(ProductId, PageSize);
         }
          #endregion
    }
}
