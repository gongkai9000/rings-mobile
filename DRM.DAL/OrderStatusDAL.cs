using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class OrderStatusDAL
    {
        public static void WriteLog(T_Order_Log log)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Order_Log.AddObject(log);
                db.SaveChanges();
            }
        }
    }
}
