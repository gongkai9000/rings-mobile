using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class HandSizeBll
    {
        HandSizeDal dal = new HandSizeDal();
        /// <summary>
        /// 根据产品Id 手寸 材质 获取HandSize数据
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="i1"></param>
        /// <param name="martial"></param>
        /// <returns></returns>
        public T_HandSize GetSize(int pid, int? i1, string martial)
        {
            return dal.GetSize(pid, i1, martial);
        }
        /// <summary>
        /// 根据产品Id 材质获取手寸数据
        /// </summary>
        /// <param name="pid">产品id</param>
        /// <param name="material">材质</param>
        /// <returns></returns>
        public List<T_HandSize> GetList(int pid, string material)
        {
            return dal.GetList(pid, material);
        }

        public List<int?> GetSizeList(int pid)
        {
            return dal.GetSizeList(pid);
        }

        public List<HandView> GetSizeGroupList(int pid)
        {
            List<IGrouping<int,T_HandSize>> gList = dal.GetSizeGroupList(pid);
            List<HandView> hvList = new List<HandView>();
            foreach (IGrouping<int, T_HandSize> g in gList)
            {
                HandView hv = new HandView();
                hv.HandSize = g.Key;
                var s = g.Select(t => "&quot;" + t.material + "&quot;:&quot;" + t.price + "&quot;").ToList();
                hv.JsonMaterilPrice = "{" + string.Join(",", s) + "}";
                hvList.Add(hv);
            }
            return hvList;
        }
    }

    public class HandView {
        public int HandSize { get; set; }
        public string JsonMaterilPrice { get; set; }
    }
}
