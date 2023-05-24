using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class WorkDayDAL
    {
        public static DateTime? getWorkyDayAfter(DateTime dt, int days)
        {
            using (var db = new DarryJewelryEntities())
            {
                var data = db.WorkDay.Where(t => t.Date > dt).OrderBy(t => t.Date).Take(days).OrderByDescending(t=>t.Date).FirstOrDefault();
                if (data == null)
                {
                    return (DateTime?)null;
                }
                return data.Date;
            }
        }
    }
}
