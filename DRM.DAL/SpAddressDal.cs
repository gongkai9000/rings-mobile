using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using System.Data;

namespace DRM.DAL
{
    /// <summary>
    /// 介绍：收货地址列表数据操作
    /// 作者：聂广强
    /// 日期：2014年5月23日
    /// </summary>
    public class SpAddressDal
    {
        /// <summary>
        /// 添加新的收货地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddAdess(T_SpAddress model)
        {
            using (var db=new DarryJewelryEntities())
            {
                db.T_SpAddress.AddObject(model);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 根据用户Id获取所有的待收货地址
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<T_SpAddress> GetAlladderssByUid(int uid)
        {
            using (var db=new DarryJewelryEntities())
            {
                return db.T_SpAddress.Where(a => a.MemberId == uid).OrderByDescending(m => m.SpAddressDefault).ToList();
            }
        }

        /// <summary>
        /// 根据地址的Id获取地址的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_SpAddress GetAddressById(int id)
        {
            using (var db=new DarryJewelryEntities())
            {
                return db.T_SpAddress.Where(a => a.SpAddressId == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 通过收货地址Id删除收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            using (var db=new DarryJewelryEntities())
            {
                var model = GetAddressById(id);
                
                if (model != null)
                {
                    db.T_SpAddress.Attach(model);
                     db.ObjectStateManager.ChangeObjectState(model,EntityState.Deleted);
                     return  db.SaveChanges() > 0;
                }
                else
                {
                    return false; 
                }
               
            }
        }

        public static bool UpdateStatus(int memId)
        {
            using (var db=new DarryJewelryEntities())
            {
                List<T_SpAddress> address = GetAlladderssByUid(memId);
                for (int i = 0; i < address.Count; i++)
                {
                    address[i].SpAddressDefault = false;
                    db.T_SpAddress.Attach(address[i]);
                    db.ObjectStateManager.ChangeObjectState(address[i], EntityState.Modified);
                }

               return db.SaveChanges() > 0;

            }
        }

        public static bool UpdateAddress(T_SpAddress model)
        {
            using (var db=new DarryJewelryEntities())
            {
                db.T_SpAddress.Attach(model);
                db.ObjectStateManager.ChangeObjectState(model, EntityState.Modified);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取默认地址
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static T_SpAddress GetDefaultAddress(int memberId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_SpAddress.SingleOrDefault(t=>t.SpAddressDefault && t.MemberId == memberId);
            }
        }
    }
}
