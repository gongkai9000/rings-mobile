using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class NewsBLL
    {
        public List<T_ProposeNews> getNewsByType(int typeid,int top)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getNewsByType(typeid,top);
        }
        public List<T_ProposeNews> getNewsByType(List<int> typeidList, int top)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getNewsByType(typeidList,top);
        }
        public List<T_ProposeNews> getNewsByType(List<int> typeidList,int skip, int top)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getNewsByType(typeidList,skip, top);
        }

        public List<int> getChild(int typeid)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getChild(typeid);
        }
        public List<T_ArticleType> getChildAt(int typeid)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getChildAt(typeid);
        }

        public List<T_ArticleType> getListByPID(int pid)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getListByPID(pid);
        }

                /// <summary>
        /// 珠宝资讯的兼容详情
        /// </summary>
        /// <returns></returns>
        public T_Page getOldDetail(int id)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getOldDetail(id);
        }

        public List<T_Comquestion> getComquestionByType(int type)
        {
            NewsDAL nDal = new NewsDAL();
            return nDal.getComquestionByType(type);
        }
    }
}
