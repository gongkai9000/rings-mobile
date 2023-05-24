using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class ProTypeDal
    {

        /// <summary>
        /// 根据类型数组获取 类型信息 
        /// </summary>
        /// <param name="arrInts"></param>
        /// <returns></returns>
        public List<ProductType> GetList(int[] arrInts)
        {
            using (var db = new DarryJewelryEntities())
            {
                List<ProductType> list = (from c in db.ProductType
                                          where arrInts.Contains(c.id)
                                          select c).ToList();
                return list;
            }
        }

        public ProductType GetType(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.ProductType.Single(t => t.id == id);
            }
        }

        public List<ProductType> GetListByPid(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.ProductType.Where(t => t.parentID == id).ToList();
            }
        }

        /// <summary>
        /// 使用递归获取一个类型包括自身所有的子类
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<ProductType> GetChildByPID(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                var p = db.Product.Single(t => t.id == pid);
                var pt = db.ProductType.Single(t => t.id == p.productTypeId);
                return getChild(pt);
            }
        }

        /// <summary>
        /// 根据产品类型id获取子类
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<ProductType> GetChidlTypeList(int typeid)
        {
            using (var db = new DarryJewelryEntities())
            {
                //var p = db.Product.Single(t=>t.id == pid);
                var pt = db.ProductType.FirstOrDefault(t => t.id == typeid);
                if (pt != null)
                {
                    return getChild(pt);
                }
                else
                {
                    return null;
                }

            }
        }

        protected List<ProductType> getChild(ProductType pt)
        {
            using (var db = new DarryJewelryEntities())
            {
                //var pt = db.ProductType.Single(t => t.id == ptid);
                //寻找子类
                List<ProductType> result = new List<ProductType>();
                var cList = db.ProductType.Where(t => t.parentID == pt.id).ToList();
                result.Add(pt);
                if (cList.Count == 0)
                {
                    return result;
                }
                else
                {
                    foreach (ProductType pttemp in cList)
                    {
                        result.AddRange(getChild(pttemp));
                    }
                    return result;
                }
            }
        }



        /// <summary>
        /// 使用递归获取一个类型包括自身所有的父类
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<ProductType> GetParentByPID(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                var p = db.Product.Single(t => t.id == pid);
                var pt = db.ProductType.Single(t => t.id == p.productTypeId);
                return getParent(pt);
            }
        }

        protected List<ProductType> getParent(ProductType pt)
        {
            using (var db = new DarryJewelryEntities())
            {
                //寻找父类
                List<ProductType> result = new List<ProductType>();
                result.Insert(0, pt);
                if (!pt.parentID.HasValue)
                {
                    return result;
                }
                else
                {
                    var tt = db.ProductType.Single(t => t.id == pt.parentID);

                    result.InsertRange(0, getParent(tt));
                    return result;
                }
            }
        }
    }
}
