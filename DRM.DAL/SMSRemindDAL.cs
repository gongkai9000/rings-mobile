using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class SMSRemindDAL
    {
        /// <summary>
        /// 添加SmsRemind
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddSmsRemind(List<Tb_SMSRemind> list)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (Tb_SMSRemind r in list)
                {
                    db.Tb_SMSRemind.AddObject(r);
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
