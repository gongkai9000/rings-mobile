using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class CartDAL
    {
        public int DarryRingTypeID = 1;

        /// <summary>
        /// 根据会员id,获取购物车数据
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public List<T_Cart> GetCartByMemberId(int memberId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Cart.Where(t => t.MemberId.Value == memberId && t.isNewWeb).ToList();
            }
        }
        public List<view_cart> GetViewCartByMemberId(int memberId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_cart.Where(t => t.MemberId.Value == memberId && t.isNewWeb).ToList();
            }
        }
        

        /// <summary>
        /// 根据会员id,清理购物车
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public int DeleteCartByMemberId(int memberId)
        {
            using (var db = new DarryJewelryEntities())
            {
                List<T_Cart> cartList = db.T_Cart.Where(t => t.MemberId.Value == memberId && t.isNewWeb).ToList();
                foreach (T_Cart c in cartList)
                {
                    db.DeleteObject(c);
                }
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 添加一条购物车信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddCartData(T_Cart c)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Cart.AddObject(c);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 根据唯一ID,返回Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_Cart GetCartByID(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Cart.SingleOrDefault(t => t.Id == id);
            }
        }

        /// <summary>
        /// 修改一条购物车数据
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int UpdateCart(T_Cart c)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Cart.Attach(c);
                db.ObjectStateManager.ChangeObjectState(c, System.Data.EntityState.Modified);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 根据ID删除购物车数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCartById(int id, int memberid, List<int> ints)
        {
            using (var db = new DarryJewelryEntities())
            {
                List<T_Cart> cartList = new List<T_Cart>();
                var data = db.T_Cart.Single(t => t.Id == id);
                var p = db.Product.Single(t => t.id == data.ProductId);
                if (ints.Contains(p.productTypeId))
                {
                    cartList = db.T_Cart.Where(t => t.MemberId == memberid && t.isNewWeb).ToList();
                }
                else
                {
                    cartList.Add(data);
                }

                foreach (T_Cart c in cartList)
                {
                    db.DeleteObject(c);
                }
                return db.SaveChanges();
            }
        }

        public decimal GetTotal(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Cart.Where(t => t.MemberId == memberid && t.isNewWeb).Sum(t => t.MemberPrice).Value;
            }
        }
        /// <summary>
        /// 判断购物车列表中是否存在Darry钻戒
        /// </summary>
        /// <param name="cartList"></param>
        /// <returns></returns>
        public bool IsHaveDarry(List<T_Cart> cartList, List<int> ints)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (T_Cart c in cartList)
                {
                    int count = db.Product.Count(t => ints.Contains(t.productTypeId) && t.id == c.ProductId);
                    if (count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 判断购物车列表中是否存在Darry钻戒
        /// </summary>
        /// <param name="cartList"></param>
        /// <returns></returns>
        public bool IsHaveDarry(List<view_cart> cartList, List<int> ints)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (view_cart c in cartList)
                {
                    int count = db.Product.Count(t => ints.Contains(t.productTypeId) && t.id == c.ProductId);
                    if (count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public T_Cart getDarryInCart(List<T_Cart> cartList, List<int> ints)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (T_Cart c in cartList)
                {
                    var data = db.Product.SingleOrDefault(t => ints.Contains(t.productTypeId) && t.id == c.ProductId);
                    if (data != null)
                    {
                        return c;
                    }
                }
                return null;
            }
        }

        public view_cart getDarryInCart(List<view_cart> cartList, List<int> ints)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (view_cart c in cartList)
                {
                    var data = db.Product.SingleOrDefault(t => ints.Contains(t.productTypeId) && t.id == c.ProductId);
                    if (data != null)
                    {
                        return c;
                    }
                }
                return null;
            }
        }

        public view_product2 getDarryProduct(List<T_Cart> cartList, List<int> darry)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (T_Cart c in cartList)
                {
                    var p = db.view_product2.SingleOrDefault(t => darry.Contains(t.productTypeId) && t.id == c.ProductId);
                    if (p != null)
                    {
                        return p;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 判断此数据是否是Darry钻戒
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsHaveDarry(T_Cart c)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Product.Any(t => t.productTypeId == 1 && t.id == c.ProductId);
            }
        }


        #region Order部分
        /// <summary>
        /// 添加订单详情
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddOrderDetail(List<T_OrderDetail> detailList)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (T_OrderDetail d in detailList)
                {
                    db.T_OrderDetail.AddObject(d);
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }
        #endregion


        public int GetCartCount(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Cart.Count(t => t.MemberId == memberid && t.isNewWeb);
            }
        }
    }
}
