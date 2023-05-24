using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class DarryHomeDAL
    {
        /// <summary>
        /// 根据DarryHomeIDCard查询DarryHome记录
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public T_DarryHome GetDarryHomeByCardID(string cardId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_DarryHome.FirstOrDefault(t => t.DarryHomeIDCard == cardId);
            }
        }

        public T_DarryHome GetDarryHomeByCardID2(string cardId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_DarryHome.FirstOrDefault(t => t.DarryHomeIDCardMd5 == cardId);
            }
        }
        /// <summary>
        /// 根据DarryHomeIDCard查询DarryHome记录
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public T_DarryHome GetDarryHomeByMemberID(int memberId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_DarryHome.FirstOrDefault(t => t.DarryHomeMemberId == memberId);
            }
        }


        /// <summary>
        /// 添加DarryHome
        /// </summary>
        /// <param name="darryHome"></param>
        /// <returns></returns>
        public bool AddDarryHome(T_DarryHome darryHome)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_DarryHome.AddObject(darryHome);
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        public bool UpdateHomeIsBit(string orderid,int memberId)
        {
            using (var db = new DarryJewelryEntities())
            {
                var d = db.T_DarryHome.FirstOrDefault(t => t.DarryHomeOrderId == orderid && t.DarryHomeMemberId == memberId);
                if (d != null)
                {
                    d.DarryHomeIsBit = true;
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        public bool DeleteDarryHome(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                var dh = db.T_DarryHome.FirstOrDefault(t => t.DarryHomeOrderId == orderid);
                if (dh != null)
                {
                    db.T_DarryHome.DeleteObject(dh);
                }
                return db.SaveChanges() > 0;
            }
        }

     

        public T_DarryHome getByCardMd5(string sirCard)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_DarryHome.First(t => t.DarryHomeIDCardMd5 == sirCard);
            }
        }
    }
}
