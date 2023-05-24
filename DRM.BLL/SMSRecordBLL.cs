using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.DAL;
using DRM.Entity;

namespace DRM.BLL
{
    public class SMSRecordBLL
    {
        public bool AddSmsRecord(Tb_SMSRecord r)
        {
            SMSRecordDAL rDal = new SMSRecordDAL();
            return rDal.AddSmsRecord(r);
        }
    }
}
