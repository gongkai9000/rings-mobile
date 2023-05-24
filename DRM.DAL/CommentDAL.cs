using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
   public  class CommentDAL
   {
       #region 查询
       public List<T_Comment> GetCommentByProductId(int pid,int PageSize)
       { 
           using (var db = new DarryJewelryEntities())
           {
               Product product = new Product();
               ProductDAL pDal = new ProductDAL();
               product = pDal.GetProduct(pid);
               //datacount = db.T_Comment.Count(t => t.ProductId == pid || t.ProductId == product.oldId);
               return db.T_Comment.Where(t => t.ProductId == pid || t.ProductId == product.oldId).OrderByDescending(t => t.Id).Take(PageSize).ToList();
           }
        
       }

       #endregion


   }
}
