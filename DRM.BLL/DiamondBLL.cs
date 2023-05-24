using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class DiamondBLL
    {
        DiamondDAL diamondDal = new DiamondDAL();
        public T_Diamonds getDiamondById(int id)
        {
            return diamondDal.getDiamondById(id);
        }

        public bool updateDiamondCount(List<int> dList)
        {
            return diamondDal.updateDiamondCount(dList);
        }
        public List<T_Diamonds> getListByType(int typeid)
        {
            return diamondDal.getListByType(typeid);
        }

        public List<T_Diamonds> getListByType(int typeid,int top)
        {
            return diamondDal.getListByType(typeid);
        }

        public List<view_diamond_product> getViewListByType(int typeid)
        {
            return diamondDal.getViewListById(typeid);
        }
    }
}
