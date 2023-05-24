using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class SpAddressBLL
    {
        /// <summary>
        /// 添加新的收货地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddAdess(T_SpAddress model)
        {
            return SpAddressDal.AddAdess(model);
        }
        /// <summary>
        /// 根据用户Id获取所有的待收货地址
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<T_SpAddress> GetAlladderssByUid(int uid)
        {
            return SpAddressDal.GetAlladderssByUid(uid);
        }

        /// <summary>
        /// 根据地址的Id获取地址的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_SpAddress GetAddressById(int id)
        {
            return SpAddressDal.GetAddressById(id);
        }

        /// <summary>
        /// 通过收货地址Id删除收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return SpAddressDal.Delete(id);
        }

        /// <summary>
        /// 通过用户Id更新用户收货地址的状态
        /// </summary>
        /// <param name="memId"></param>
        /// <returns></returns>
        public static bool UpdateStatus(int memId)
        {
            return SpAddressDal.UpdateStatus(memId);
        }

     
        /// <summary>
        /// 更新收货地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateAddress(T_SpAddress model)
        {
            return SpAddressDal.UpdateAddress(model);
        }


                /// <summary>
        /// 获取默认地址
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static T_SpAddress GetDefaultAddress(int memberId)
        {
            return SpAddressDal.GetDefaultAddress(memberId);
        }
    }
}
