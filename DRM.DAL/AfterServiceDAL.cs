using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class AfterServiceDAL
    {
        /// <summary>
        /// 根据会员id,获取售后服务信息
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public List<tb_AfterService> GetAfterService(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.tb_AfterService.Where(t => t.AfterServiceUserId.Value == memberid).OrderByDescending(t=>t.AfterServiceDate).ToList();
            }
        }

        /// <summary>
        /// 新增售后服务信息
        /// </summary>
        /// <param name="aService"></param>
        /// <returns></returns>
        public bool AddAfterService(tb_AfterService aService,out int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.tb_AfterService.AddObject(aService);
                
                int result = db.SaveChanges();
                id = aService.AfterServiceId;
                return result > 0 ? true : false;
            }
        }

        public tb_AfterService GetAfterServiceByid(int asid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.tb_AfterService.Single(t=>t.AfterServiceId == asid);
            }
        }
    }
}
