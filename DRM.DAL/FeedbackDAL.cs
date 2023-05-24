using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class FeedbackDAL
    {
        public bool addfeedback(Feedback f)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.Feedback.AddObject(f);
                return db.SaveChanges() > 0;
            }
        }
    }
}
