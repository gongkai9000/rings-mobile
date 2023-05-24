using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class FeedbackBLL
    {
        public bool addfeedback(Feedback f)
        {
            FeedbackDAL fdal = new FeedbackDAL();
            return fdal.addfeedback(f);
        }
    }
}
