using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class OrderLogDAL
    {
        /// <summary>
        /// 添加订单日志
        /// </summary>
        /// <returns></returns>
        public bool AddOrderLog(T_Order_Log orderLog)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Order_Log.AddObject(orderLog);
                return db.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
