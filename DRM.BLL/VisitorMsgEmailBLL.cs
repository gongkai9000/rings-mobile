using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class VisitorMsgEmailBLL
    {
        public bool AddVisitorMsgEmail(T_QxEmail model)
        {
            VisitorMsgEmailDAL dal = new VisitorMsgEmailDAL();
            model.type = 2;
            return dal.AddVisitorMsgEmail(model);
        }

        public T_QxEmail GetMsgEmailById(int id)
        {
            VisitorMsgEmailDAL dal = new VisitorMsgEmailDAL();
            return dal.getMsgEmailById(id);
        }
    }
}
