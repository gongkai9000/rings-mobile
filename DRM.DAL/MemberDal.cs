using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.Entity;
using System.Data;

namespace DRM.DAL
{
    /// <summary>
    /// 用户登陆 注册
    /// 作者：聂广强
    /// 日期：2014年5月22日
    /// </summary>
    public class MemberDal
    {

        /// <summary>
        /// 判断用户表中是否有被注册的Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsRegByEmail(string email)
        {
            using (var db = new DarryJewelryEntities())
            {
               return db.T_Member.Where(m => m.email == email).FirstOrDefault()!=null;
               
            }
        }

        /// <summary>
        /// 判断用户表中是否有被注册的Mobile
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsRegByMobile(string mobile)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Member.Where(m => m.mobile == mobile).FirstOrDefault() != null;

            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(T_Member model)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Member.AddObject(model);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 跟新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(T_Member model)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Member.Attach(model);
                db.ObjectStateManager.ChangeObjectState(model, EntityState.Modified);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 添加用户 返回 添加后的用户Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int GetAddId(T_Member model)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Member.AddObject(model);
                db.SaveChanges();
                return model.Id;
            }
        }
        /// <summary>
        /// 通过Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_Member GetMemberById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Member.Where(m => m.Id == id).FirstOrDefault();
            }
        }
        /// <summary>
        /// 通过邮箱或者手机号查询用户信息
        /// </summary>
        /// <param name="email">邮箱或者手机号</param>
        /// <returns></returns>
        public static T_Member GetMemberBy(string email)
        {
            using (var db=new DarryJewelryEntities())
            {
                if (email.Contains('@'))
                {
                    return db.T_Member.Where(m => m.email == email).FirstOrDefault();
                }
                else
                {
                    return db.T_Member.Where(m => m.mobile == email).FirstOrDefault();
                }
            }
        }

        public T_DarryHome YzDarry(Expression<Func<T_DarryHome, bool>> where)
        {
            using (var db=new  DarryJewelryEntities())
            {
                return db.T_DarryHome.Where(where).FirstOrDefault();
            }
        }

        public static T_Member GetMemberbyQQid(string qqid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Member.Where(m => m.QQOpenId == qqid).FirstOrDefault();

            }
        }
        public static T_Member GetMemberbySineid(string sineid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Member.Where(m => m.SinaOpenId == sineid).FirstOrDefault();

            }
        }
    }
}
