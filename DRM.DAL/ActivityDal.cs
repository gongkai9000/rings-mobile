using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
  public   class ActivityDal
    {
      public List<T_activity> GetActivities(Expression<Func<T_activity, bool>> where,int cout)
      {
          using (var db=new DarryJewelryEntities())
          {
              return db.T_activity.OrderByDescending(t=>t.No).Where(where).Take(cout).ToList();
          }
      }
    }
}
