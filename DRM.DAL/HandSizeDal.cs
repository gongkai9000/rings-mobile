using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class HandSizeDal
    {
        /// <summary>
        /// 根据产品Id 手寸 材质 获取HandSize数据
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="i1"></param>
        /// <param name="martial"></param>
        /// <returns></returns>
        public T_HandSize GetSize(int pid, int? i1, string martial)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_HandSize.Where(t => t.pid == pid && t.material.ToLower() == martial.ToLower() && t.handsize == i1).FirstOrDefault();
            }
        }
        /// <summary>
        /// 根据产品Id 材质获取手寸数据
        /// </summary>
        /// <param name="pid">产品id</param>
        /// <param name="material">材质</param>
        /// <returns></returns>
        public List<T_HandSize> GetList(int pid, string material)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_HandSize.Where(t => t.pid == pid && t.material == material).ToList();
            }
        }

        public List<int?> GetSizeList(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_HandSize.Where(t => t.pid == pid).GroupBy(t => t.handsize).Select(t => t.Key).ToList();
            }
        }

        public List<IGrouping<int,T_HandSize>> GetSizeGroupList(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_HandSize.Where(t => t.pid == pid).GroupBy(t => t.handsize.Value).ToList();
            }
        }
    }

}
