using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class SMSRemindBLL
    {
        SMSRemindDAL _sRemindDal = new SMSRemindDAL();
        /// <summary>
        /// 添加SmsRemind
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddSmsRemind(List<Tb_SMSRemind> list)
        {
            return _sRemindDal.AddSmsRemind(list);
        }
    }
}
