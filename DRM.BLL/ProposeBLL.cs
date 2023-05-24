using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    /// <summary>
    /// 常见问题数据业务
    /// 作者：聂广强
    /// </summary>
    public class ProposeBLL
    {
        public static int PageSize { get { return 10; } }
        ///// <summary>
        ///// 根据类型Id获取此类型的文章集合
        ///// </summary>
        ///// <param name="typeId">类型Id</param>
        ///// <returns>文章集合</returns>
        //public static List<T_ProposeNews> GetListByTypeId(int typeId)
        //{
        //    return ProposeDAL.GetListPropose(typeId);
        //}

        ///// <summary>
        /////  根据类型Id获取此类型的文章集合
        ///// </summary>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageCount"></param>
        ///// <param name="typeId"></param>
        ///// <returns></returns>
        //public static List<T_ProposeNews> GetListByTypeId(int pageIndex, out int pageCount, int typeId)
        //{
        //    return ProposeDAL.GetListByTypeId(PageSize, pageIndex, out pageCount, typeId);
        //}

        /// <summary>
        /// 根据文章的Id获取文章的内容
        /// </summary>
        /// <param name="id">文章id</param>
        /// <returns></returns>
        public static T_ProposeNews GetProposeById(int id)
        {
            return ProposeDAL.GetProposeById(id);
        }

        /// <summary>
        /// 根据文章ClassId获取相应的类型的文章集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public static List<T_ProposeNews> GetProposeByClassId(int classId)
        {
            return ProposeDAL.GetProposeByClassId(classId);
        }

        /// <summary>
        ///根据分页参数获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public static List<T_ProposeNews> GetProPageListByClassId(int pageIndex, out int pageCount, int classId)
        {
            return ProposeDAL.GetProposeByClassId(PageSize, pageIndex, out pageCount, classId);
        }

        /// <summary>
        /// 根据类型id获取类型信息
        /// </summary>
        /// <param name="typeId">类型Id</param>
        /// <returns>类型信息</returns>
        public static T_ArticleType GetProTypeById(int typeId)
        {
            return ProposeDAL.GetProTypeById(typeId);
        }

        public List<T_ProposeNews> GetproList(Expression<Func<T_ProposeNews, bool>> where)
        {
            return new ProposeDAL().GetproList(where);
        }

        public static List<T_ProposeNews> getListByTagId(int tagid,int top)
        {
            return ProposeDAL.getListByTagId(tagid, top);
        }
        public static List<T_ProposeNews> getListByTagId(int tagid,int skip,int top)
        {
            return ProposeDAL.getListByTagId(tagid, skip, top);
        }

        public static T_TagWords getTagwordById(int tagid)
        {
            return ProposeDAL.getTagwordById(tagid);
        }
    }
}
