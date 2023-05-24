using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class FavoritesDAL
    {
        public bool AddFavorites(Favorites f)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.Favorites.AddObject(f);
                return db.SaveChanges() > 0;
            }
        }

        public bool IsFavorites(int pid, int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Favorites.Any(t => t.pid == pid && t.memberid == memberid);
            }
        }

        public List<view_myfavorites> getFavorites(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_myfavorites.Where(t => t.memberid == memberid).ToList();
            }
        }

        public bool deleteFavorites(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.Favorites.DeleteObject(db.Favorites.Single(t => t.id == id));
                return db.SaveChanges() > 0;
            }
        }

        public int getFavoritesCountByProduct(int pid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.Favorites.Count(t=>t.pid == pid);
            }
        }

        public Favorites getFavorByid(string pid,int uid)
        {
            using (var db = new DarryJewelryEntities())
            {
                int id = int.Parse(pid);
                return db.Favorites.SingleOrDefault(t => t.pid == id && t.memberid == uid);
            }
        }
    }
}
