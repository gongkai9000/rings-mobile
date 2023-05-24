using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Objects;
using System.Data;
using DRM.DAL.Dynamic;

namespace DRM.DAL
{
    public class nProductDAL
    {
        public List<view_diyproduct> getDIYProduct(Expression<Func<view_diyproduct, bool>> express, string orderby, int pagesize, int pageindex, out int datacount)
        {
            using (var db = new DarryJewelryEntities())
            {
                datacount = db.view_diyproduct.Where(express).Count();
                return db.view_diyproduct.Where(express).OrderBy(orderby).Skip(pageindex * pagesize).Take(pagesize).ToList();
            }
        }

        public List<T_Diamonds> getDiamonds(int typeid, Expression<Func<T_Diamonds, bool>> express, string orderby, int pagesize, int pageindex, out int datacount)
        {
            using (var db = new DarryJewelryEntities())
            {
                datacount = db.T_Diamonds.Where(express).Count();
                return db.T_Diamonds.Where(express).OrderBy(orderby).Skip(pageindex * pagesize).Take(pagesize).ToList();
            }
        }

        public List<Product> GetList(int typeid, int pagesize, int pageindex, string orderby)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Product.Where(t => t.productTypeId == typeid).Skip(pageindex * pagesize).Take(pagesize).OrderBy(orderby).ToList();
            }
        }

        public List<view_product2> GetProListbyCol(string col, string qg, string jd, string sort, int pageindex, int PageSize, out int count,out int total)
        {
            using (var db = new DarryJewelryEntities())
            {
                //var sql = (from n in db.Product join b in db.T_ProductDetail on n.id equals b.productId select new { n.id, n.title, n.p_content, n.price, n.MemberPrice, b.zcolor, b.zcut, b.zclarity }).Where(t => t.zcolor == col && t.zclarity == jd && t.zcut == qg);
                //return db.view_product2.Where(t => t.zclarity== col && t.zclarity == jd && t.zcut == qg).ToList();
                //List<view_product2> list = new List<view_product2>();
                IQueryable<view_product2> list = db.view_product2.Where(t => t.zclarity == col && t.zclarity == jd && t.zcut == qg) ;
                string c = (list.Count() / (PageSize * 1.00)).ToString();
                count = int.Parse(Math.Ceiling(decimal.Parse(c)).ToString());
                total = list.Count();
                return list.Skip((pageindex - 1) * PageSize).Take(PageSize).ToList();
            }
        }

        


        public Product GetProductById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Product.Single(t => t.id == id);
            }
        }

        public T_ProductDetail GetPDetailByPID(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_ProductDetail.Where(t => t.productId == pid).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据产品Id获取图片集合
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public List<ProductImgUrl> GetUrlById(int proid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.ProductImgUrl.Where(t=>t.productId == proid).ToList();
            }
        }

        public view_product2 GetViewProductById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_product2.Where(t=>t.id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据产品类型获取一定数量产品
        /// </summary>
        /// <returns></returns>
        public List<T_Diamonds> getTuijianZuanshi(int? tjlz, int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                if (tjlz.HasValue)
                {
                    return db.T_Diamonds.Where(t => t.protype == tjlz).Take(top).ToList();
                }
                else
                {
                    return null;
                }
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
                return db.Material.Where(t=>t.pid == productid).ToList();
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

        public view_orderdetail getpinlunInfo(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_orderdetail.Single(t => t.Id == id&&t.status==4);
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
                        mprice =Convert.ToDecimal(model.price);
                    }
                }
                return mprice;
            }
        }

        /// <summary>
        /// 获取自定义
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns></returns>
        public DiyProduct GetDIYProductByID(int dpid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.DiyProduct.Single(t=>t.id == dpid);
            }
        }
    }
}
