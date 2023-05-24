using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRI.BLL
{
    public class FavoritesBLL
    {
        FavoritesDAL fDal = new FavoritesDAL();
        public bool AddFavorites(Favorites f)
        {
            return fDal.AddFavorites(f);
        }

        public bool IsFavorites(int pid, int memberid)
        {
            return fDal.IsFavorites(pid, memberid);
        }

        public List<view_myfavorites> getFavorites(int memberid)
        {
            return fDal.getFavorites(memberid);
        }

        public bool deleteFavorites(int id)
        {
            return fDal.deleteFavorites(id);
        }

        public int getFavoritesCountByProduct(int pid)
        {   
            return fDal.getFavoritesCountByProduct(pid);
        }

        public Favorites getFavorByid(string pid,int uid)
        {
            return fDal.getFavorByid(pid,uid);
        }


    }
}
