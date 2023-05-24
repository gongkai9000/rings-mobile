using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.DAL;
using DRM.Entity;
using DRM.BLL.Result;

namespace DRM.BLL
{
    public class DarryHomeBLL
    {
        /// <summary>
        /// 验证身份证是否购买过Darry求婚钻戒
        /// </summary>
        /// <returns></returns>
        public bool IsBuyDarry(string cardId)
        {
            DarryHomeDAL darryDal = new DarryHomeDAL();
            T_DarryHome darryHome = darryDal.GetDarryHomeByCardID(cardId);

            return darryHome == null ? false : true;
        }

        public bool IsBuyDarry2(string cardId)
        {
            DarryHomeDAL darryDal = new DarryHomeDAL();
            T_DarryHome darryHome = darryDal.GetDarryHomeByCardID2(cardId);

            return darryHome == null ? false : true;
        }
        /// <summary>
        /// 验证会员id是否购买过Darry求婚钻戒
        /// </summary>
        /// <returns></returns>
        public bool IsBuyDarry(int memberId)
        {
            DarryHomeDAL darryDal = new DarryHomeDAL();
            T_DarryHome darryHome = darryDal.GetDarryHomeByMemberID(memberId);

            return darryHome == null ? false : true;
        }

        /// <summary>
        /// 添加DarryHome
        /// </summary>
        /// <param name="darryHome"></param>
        /// <returns></returns>
        public bool AddDarryHome(T_DarryHome darryHome)
        {
            DarryHomeDAL darryDal = new DarryHomeDAL();
            return darryDal.AddDarryHome(darryHome);
        }

        /// <summary>
        /// 修改DarryHome中的IsBit字段
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public bool UpdateHomeIsBit(string orderid, int memberId)
        {
            DarryHomeDAL darryDal = new DarryHomeDAL();
            return darryDal.UpdateHomeIsBit(orderid,memberId);
        }

      

        public T_DarryHome getByCardMd5(string sirCard)
        {
            DarryHomeDAL darryDal = new DarryHomeDAL();
            return darryDal.getByCardMd5(sirCard);
        }
    }
}
