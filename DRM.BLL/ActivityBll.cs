using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.DAL;
using DRM.Entity;

namespace DRM.BLL
{
    public class ActivityBll
    {
        public List<T_activity> GetActivities(Expression<Func<T_activity, bool>> where, int cout)
        {
            return new ActivityDal().GetActivities(where, cout);
        }
    }
}
