using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class SMSRecordDAL
    {
        public bool AddSmsRecord(Tb_SMSRecord r)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.Tb_SMSRecord.AddObject(r);
                return db.SaveChanges() > 0;
            }
        }
    }
}
