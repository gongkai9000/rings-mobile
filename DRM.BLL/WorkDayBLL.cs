using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.DAL;

namespace DRM.BLL
{
    public class WorkDayBLL
    {
        public static DateTime? getWorkyDayAfter(DateTime dt,int days)
        {
            return WorkDayDAL.getWorkyDayAfter(dt, days);
        }
    }
}
