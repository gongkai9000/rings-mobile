using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;

namespace DRM.BLL
{
    public class ProTypeBll
    {
        ProTypeDal dal = new ProTypeDal();

        public List<ProductType> GeTypes(int[] arrInts)
        {
            return dal.GetList(arrInts);
        }
        public ProductType GetType(int id)
        {
            return dal.GetType(id);
        }

        public List<ProductType> GetListByPid(int pid)
        {
            return dal.GetListByPid(pid);
        }

        public List<ProductType> GetChildByPID(int pid)
        {
            return dal.GetChildByPID(pid);
        }

        public List<ProductType> GetParentByPID(int pid)
        {
            return dal.GetParentByPID(pid);
        }
        public List<ProductType> GetChidlTypeList(int typeid)
        {
            return dal.GetChidlTypeList(typeid);
        }
    }
}
