using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class DiamondDAL
    {
        public T_Diamonds getDiamondById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Diamonds.SingleOrDefault(t => t.Id == id);
            }
        }

        public bool updateDiamondCount(List<int> dList)
        {
            using (var db = new DarryJewelryEntities())
            {
                var diamondList = db.T_Diamonds.Where(t => dList.Contains(t.Id)).ToList();
                foreach (T_Diamonds d in diamondList)
                {
                    if (d.stocknumber.HasValue)
                    {
                        d.stocknumber = d.stocknumber - 1;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }

        public List<T_Diamonds> getListByType(int typeid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Diamonds.Where(t => t.protype == typeid).ToList();
            }
        }
        public List<view_diamond_product> getViewListById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_diamond_product.Where(t => t.productid == id).ToList();
            }
        }

        public List<T_Diamonds> getListByType(int typeid, int top)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Diamonds.Where(t => t.protype == typeid).Take(top).ToList();
            }
        }
    }
}
