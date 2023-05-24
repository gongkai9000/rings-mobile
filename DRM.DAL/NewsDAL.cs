using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class NewsDAL
    {
        public List<T_ProposeNews> getNewsByType(int typeid,int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ProposeNews.Where(t=>t.ProposeNewsClassId == typeid).Take(top).ToList();
            }
        }

        public List<T_ProposeNews> getNewsByType(List<int> typeidList,int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ProposeNews.Where(t => typeidList.Contains(t.ProposeNewsClassId.Value)).OrderByDescending(t=>t.ProposeNewsId).Take(top).ToList();
            }
        }
        public List<T_ProposeNews> getNewsByType(List<int> typeidList,int skip, int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ProposeNews.Where(t => typeidList.Contains(t.ProposeNewsClassId.Value)).OrderByDescending(t => t.ProposeNewsId).Skip(skip).Take(top).ToList();
            }
        }


        public List<int> getChild(int typeid)
        {
            using (var db = new DarryJewelryEntities())
            {
                //var pt = db.ProductType.Single(t => t.id == ptid);
                //寻找子类
                List<int> result = new List<int>();
                var cList = db.T_ArticleType.Where(t => t.pid == typeid).ToList();
                result.Add(typeid);
                if (cList.Count == 0)
                {
                    return result;
                }
                else
                {
                    foreach (T_ArticleType pttemp in cList)
                    {
                        result.AddRange(getChild(pttemp.id));
                    }
                    return result;
                }
            }
        }

        public List<T_ArticleType> getChildAt(int typeid)
        {
            using (var db = new DarryJewelryEntities())
            {
                //var pt = db.ProductType.Single(t => t.id == ptid);
                //寻找子类
                List<T_ArticleType> result = new List<T_ArticleType>();
                var cList = db.T_ArticleType.Where(t => t.pid == typeid).ToList();
                result.AddRange(cList);
                if (cList.Count == 0)
                {
                    return result;
                }
                else
                {
                    foreach (T_ArticleType pttemp in cList)
                    {
                        result.AddRange(getChildAt(pttemp.id));
                    }
                    return result;
                }
            }
        }

        /// <summary>
        /// 珠宝资讯的兼容详情
        /// </summary>
        /// <returns></returns>
        public T_Page getOldDetail(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Page.Single(t=>t.CategoryId == 4 && t.pageid == id);
            }
        }

        public List<T_Comquestion> getComquestionByType(int type)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Comquestion.Where(t=>t.type == type).ToList();
            }
        }

        public List<T_ArticleType> getListByPID(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ArticleType.Where(t => t.pid == pid).ToList();
            }
        }
    }
}
