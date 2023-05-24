using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using System.Data.Objects;


namespace DRM.DAL
{

    /// <summary>
    /// 求婚钻戒DAL
    /// Author:邵继星
    /// </summary>
    public class ProductDAL
    {
        #region 查询
        /// <summary>
        /// 根据产品分类获取产品列表
        /// </summary>
        /// <param name="classid">分类id</param>
        /// <returns></returns>
        public List<view_product2> GetList(int typeid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_product2.OrderByDescending(t => t.pSort).Where(t => t.productTypeId == typeid).Skip(0).Take(10).ToList();
            }  
        }
        public List<view_product2> GetList(int typeid,int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_product2.OrderByDescending(t => t.pSort).Where(t => t.productTypeId == typeid).Skip(top - 10).Take(10).ToList();
            }
        }

        //
        public List<view_product2> GetList(List<int> typeidList)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_product2.OrderByDescending(t => t.pSort).Where(t => t.IsCustomPink != 0).Where(t => typeidList.Contains(t.productTypeId)).Skip(0).Take(10).ToList();
            }
        }
        //
        public List<view_product2> GetList(List<int> typeidList, int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_product2.OrderByDescending(t => t.pSort).Where(t => t.IsCustomPink != 0).Where(t => typeidList.Contains(t.productTypeId)).Skip(top - 10).Take(10).ToList();
            }
        }

        /// <summary>
        /// 获取推荐裸钻的价格
        /// </summary>
        /// <returns></returns>
        public decimal GetDiamondPrice(int diamondId)
        {
            using (var db = new DarryJewelryEntities())
            {
                var data = db.T_Diamonds.SingleOrDefault(t => t.Id == diamondId);
                return data == null ? 0 : data.memberprice.Value;
            }
        }

        /// <summary>
        /// 获取材质价格
        /// </summary>
        /// <param name="material"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public decimal GetMaterialPrice(string material, int pid)
        {
            decimal mprice = 0;
            using (var db = new DarryJewelryEntities())
            {
                Material model = new Material();
                model = db.Material.Where(t => t.pid == pid && t.name == material).FirstOrDefault();
                if (model != null)
                {
                    if (model.price != null)
                    {
                        mprice = Convert.ToDecimal(model.price);
                    }
                }
                return mprice;
            }
        }

        public bool GetMaterial(string material, int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                Material model = new Material();
                model = db.Material.Where(t => t.pid == pid && t.name == material).FirstOrDefault();
                return model == null ? false : true;
            }
        }

        /// <summary>
        ///根据产品id获取产品实体
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public view_product2 GetViewProduct(int productId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_product2.Single(t=>t.id == productId);
            }
        }

        public Product GetProduct(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Product.Single(t => t.id == pid);
            }
        }

        /// <summary>
        /// 根据productid获取材质
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public List<Material> getMaterial(int productid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Material.Where(t => t.pid == productid).ToList();
            }
        }

        public bool updateProClickNum(int productid)
        {
            using (var db = new DarryJewelryEntities())
            {
                Product p = db.Product.Single(t => t.id == productid);
                p.clicknum = p.clicknum + 1;
                return db.SaveChanges() > 0;
            }
        }

        #endregion
    }
}
