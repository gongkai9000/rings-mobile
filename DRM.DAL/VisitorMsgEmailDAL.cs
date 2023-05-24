using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class VisitorMsgEmailDAL
    {
        public bool AddVisitorMsgEmail(T_QxEmail model)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_QxEmail.AddObject(model);
                return db.SaveChanges() > 0;
            }
        }

        public T_QxEmail getMsgEmailById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_QxEmail.Single(t=>t.id == id);
            }
        }
    }
}
