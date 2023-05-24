using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class AfterServiceBLL
    {
        /// <summary>
        /// URL的参数orderid
        /// </summary>
        public const string UrlOrderId = "OrderId";

        AfterServiceDAL _aServiceDal = new AfterServiceDAL();
        /// <summary>
        /// 根据会员id,获取售后服务信息
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public List<tb_AfterService> GetAfterService(int memberid)
        {
            return _aServiceDal.GetAfterService(memberid);
        }

        /// <summary>
        /// 新增售后服务信息
        /// </summary>
        /// <param name="aService"></param>
        /// <returns></returns>
        public bool AddAfterService(tb_AfterService aService,out int id)
        {
            return _aServiceDal.AddAfterService(aService,out id);
        }

        public tb_AfterService GetAfterServiceByid(int asid)
        {
            return _aServiceDal.GetAfterServiceByid(asid);
        }
    }
}
