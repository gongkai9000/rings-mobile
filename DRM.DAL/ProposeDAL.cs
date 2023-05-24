using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.Entity;
namespace DRM.DAL
{
    /// <summary>
    /// 常见问题数据访问层
    /// 作者：聂广强
    /// </summary>
    public class ProposeDAL
    {

        ///// <summary>
        ///// 根据类型Id获取此类型的文章集合
        ///// </summary>
        ///// <param name="typeId">类型Id</param>
        ///// <returns>文章集合</returns>
        //public static List<T_ProposeNews> GetListPropose(int typeId)
        //{
        //    using (var db = new DarryJewelryEntities())
        //    {
        //        return db.T_ProposeNews.Where(p => p.articleType == typeId).ToList();
        //    }
        //}

        /// <summary>
        /// 根据文章的Id获取文章的内容
        /// </summary>
        /// <param name="id">文章id</param>
        /// <returns></returns>
        public static T_ProposeNews GetProposeById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ProposeNews.Where(p => p.ProposeNewsId == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据文章类型ClassId获取文章集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public static List<T_ProposeNews> GetProposeByClassId(int classId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ProposeNews.Where(p => p.ProposeNewsClassId == classId).ToList();
            }
        }

        /// <summary>
        /// 根据文章主分类获取主分类数据集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public static List<T_ProposeNews> GetProposeByClassId(int pageSize, int pageIndex, out int pageCount, int classId)
        {
            using (var db = new DarryJewelryEntities())
            {
                pageCount = db.T_ProposeNews.Where(p => p.ProposeNewsClassId == classId).ToList().Count;

                return db.T_ProposeNews.Where(p => p.ProposeNewsClassId == classId).OrderByDescending(p => p.ProposeNewsAddtime).Skip(pageSize * pageIndex).Take(pageSize).ToList();
            }
        }

        // <summary>
        // 根据文章类型获取文章数据集合
        // </summary>
        // <param name="pageSize"></param>
        // <param name="pageIndex"></param>
        // <param name="pageCount"></param>
        // <param name="typeId">文章类型</param>
        // <returns></returns>
        //public static List<T_ProposeNews> GetListByTypeId(int pageSize, int pageIndex, out int pageCount, int typeId)
        //{
        //    using (var db = new DarryJewelryEntities())
        //    {
        //        pageCount = db.T_ProposeNews.Where(p => p.articleType == typeId).ToList().Count;
        //        return db.T_ProposeNews.Where(p => p.articleType == typeId).OrderByDescending(p => p.ProposeNewsAddtime).Skip(pageSize * pageIndex).Take(pageSize).ToList();

        //    }
        //}

        /// <summary>
        /// 根据类型id获取类型信息
        /// </summary>
        /// <param name="typeId">类型Id</param>
        /// <returns>类型信息</returns>
        public static T_ArticleType GetProTypeById(int typeId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ArticleType.Where(t => t.id == typeId).FirstOrDefault();
            }
        }

        public List<T_ProposeNews> GetproList(Expression<Func<T_ProposeNews, bool>> where)
        {
            using (var db=new DarryJewelryEntities())
            {
                return db.T_ProposeNews.Where(where).ToList();
            }
        }

        public static List<T_ProposeNews> getListByTagId(int tagid,int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                string tagname = db.T_TagWords.Single(t=>t.id == tagid).Tagname;
                return db.T_ProposeNews.Where(t=>t.tagwords.Contains(tagname)).OrderByDescending(t=>t.ProposeNewsId).Take(top).ToList();
            }
        }
        public static List<T_ProposeNews> getListByTagId(int tagid,int skip, int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                string tagname = db.T_TagWords.Single(t => t.id == tagid).Tagname;
                return db.T_ProposeNews.Where(t => t.tagwords.Contains(tagname)).OrderByDescending(t => t.ProposeNewsId).Skip(skip).Take(top).ToList();
            }
        }

        public static T_TagWords getTagwordById(int tagid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_TagWords.Single(t=>t.id == tagid);
            }
        }
    }
}
