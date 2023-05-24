using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.DAL;
using DRM.Entity;
using System.Linq.Expressions;
using DRM.DAL.Dynamic;

namespace DRM.BLL
{
    public class ProductBLL
    {

        /// <summary>
        /// Darry Ring求婚钻戒类型ID
        /// </summary>
        public static readonly int DarryRingTypeID = 1;
        /// <summary>
        /// 男戒
        /// </summary>
        public static readonly int ManJiezi = 2;

        /// <summary>
        /// 对戒ID
        /// </summary>
        public static readonly int DuijieID = 3;

        /// <summary>
        /// 珠宝饰品
        /// </summary>
        public static readonly int JewelleryID = 36;

        /// <summary>
        /// 裸钻ID
        /// </summary>
        public static readonly int LZID = 9;
        /// <summary>
        /// 推荐钻石类型ID
        /// </summary>
        public static readonly int TJZuanShi = 10;


        ProductDAL dringdal = new ProductDAL();
        nProductDAL pDal = new nProductDAL();
        #region 查询
        public List<view_product2> GetList(int typeid)
        {
            ProTypeBll ptbll = new ProTypeBll();
            List<int> typeidList = ptbll.GetChidlTypeList(typeid).Select(t => t.id).ToList();
            return dringdal.GetList(typeidList);
        }
        public List<view_product2> GetList(List<int> ints)
        {
            return dringdal.GetList(ints);
        }
        /// <summary>
        /// 查看更多获取产品数据
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<view_product2> GetList(int typeid, int top)
        {
            ProTypeBll ptbll = new ProTypeBll();
            List<int> typeidList = ptbll.GetChidlTypeList(typeid).Select(t => t.id).ToList();
            return dringdal.GetList(typeidList, top);
        }
        /// <summary>
        /// 查看更多获取产品数据
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<view_product2> GetList(List<int> ints , int top)
        {
            return dringdal.GetList(ints, top);
        }
        /// <summary>
        ///根据产品id获取产品实体
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public view_product2 GetProduct(int productId)
        {
            return dringdal.GetViewProduct(productId);
        }

        #endregion


        public ProductBLL() { }

        public bool IsDarryRing(int typeid)
        {
            ProTypeBll ptbll = new ProTypeBll();
            var darryRingTypeList = ptbll.GetChidlTypeList(DarryRingTypeID).Select(t => t.id).ToList();
            return darryRingTypeList.Contains(typeid);
        }

        public bool IsPhonics(int typeid)
        {
            ProTypeBll ptbll = new ProTypeBll();
            var list = ptbll.GetChidlTypeList(DuijieID).Select(t => t.id).ToList();
            return list.Contains(typeid);
        }
        public bool IsMan(int typeid)
        {
            ProTypeBll ptbll = new ProTypeBll();
            var list = ptbll.GetChidlTypeList(ManJiezi).Select(t => t.id).ToList();
            return list.Contains(typeid);
        }
        public bool IsJew(int typeid)
        {
            ProTypeBll ptbll = new ProTypeBll();
            var list = ptbll.GetChidlTypeList(JewelleryID).Select(t => t.id).ToList();
            return list.Contains(typeid);
        }

        public List<Material> getMaterial(int productid)
        {
            return dringdal.getMaterial(productid);
        }

        /// <summary>
        /// 获取推荐裸钻的价格
        /// </summary>
        /// <returns></returns>
        public decimal GetDiamondPrice(int diamondId, int number)
        {
            return dringdal.GetDiamondPrice(diamondId) * number;
        }

        /// <summary>
        /// 获取材质价格
        /// </summary>
        /// <param name="material"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public decimal GetMaterialPrice(string material, int pid)
        {
            return dringdal.GetMaterialPrice(material, pid);
        }

        public bool GetMaterial(string material, int pid)
        {
            return dringdal.GetMaterial(material, pid);
        }

        public ResultMsg checkDiamond(T_Diamonds zdiamond, view_product2 product)
        {
            bool isCustomDiamond = product.IsCustomDiamond ?? false;
            ResultMsg msg = new ResultMsg();
            msg.Result = true;
            if (zdiamond == null)
            {
                msg.Result = false;
                msg.Msg = "该钻石不存在";
            }
            else
            {
                if (zdiamond.Id != product.DiamondId)
                {
                    if (!isCustomDiamond && !product.TJLZ.HasValue)
                    {
                        msg.Result = false;
                        msg.Msg = "该产品不能搭配该钻石";
                    }
                    else if (!isCustomDiamond)
                    {
                        if (product.TJLZ.Value != zdiamond.protype.Value)
                        {
                            msg.Result = false;
                            msg.Msg = "该产品不能搭配该钻石";
                        }
                    }
                }
            }
            return msg;
        }


        /// <summary>
        /// 根据产品Id获取图片集合
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public List<ProductImgUrl> GetUrlById(int proid)
        {
            return pDal.GetUrlById(proid);
        }

        public bool updateProClickNum(int productid)
        {
            return dringdal.updateProClickNum(productid);
        }


        public List<T_Diamonds> getDiamonds(int typeid, List<KeyValuePair<string, string>> paras, int pagesize, int pageindex, out int datacount)
        {
            Expression<Func<T_Diamonds, bool>> result = t => t.protype == typeid;
            string orderby = "pSort desc";
            foreach (KeyValuePair<string, string> kv in paras)
            {
                if (kv.Key == "startBudget")
                {
                    decimal? start = string.IsNullOrEmpty(kv.Value) ? (decimal?)null : Convert.ToDecimal(kv.Value);
                    string endBudget = paras.Single(p => p.Key == "endBudget").Value;
                    decimal? end = string.IsNullOrEmpty(endBudget) ? (decimal?)null : Convert.ToDecimal(endBudget);
                    //&& t.price <= Convert.ToDecimal(paras.Single(p => p.Key == "endBudget").Value)
                    result = DynamicQueryable.And(result, t => (!start.HasValue || t.memberprice >= start) && (!end.HasValue || t.memberprice <= end));

                }
                if (kv.Key == "startWeight")
                {
                    double? start = string.IsNullOrEmpty(kv.Value) ? (double?)null : Convert.ToDouble(kv.Value);
                    string endWeight = paras.Single(p => p.Key == "endWeight").Value;
                    double? end = string.IsNullOrEmpty(endWeight) ? (double?)null : Convert.ToDouble(endWeight);
                    result = DynamicQueryable.And(result, t => (!start.HasValue || t.carat >= start) && (!end.HasValue || t.carat <= end));
                }
                if (kv.Key == "color" && !string.IsNullOrEmpty(kv.Value))
                {
                    string[] colorArray = kv.Value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    result = DynamicQueryable.And(result, t => colorArray.Contains(t.color));
                }
                if (kv.Key == "jingdu" && !string.IsNullOrEmpty(kv.Value))
                {
                    string[] jingduArray = kv.Value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    result = DynamicQueryable.And(result, t => jingduArray.Contains(t.clarity));
                }
                if (kv.Key == "qiegong" && !string.IsNullOrEmpty(kv.Value))
                {
                    string[] qiegongArray = kv.Value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    result = DynamicQueryable.And(result, t => qiegongArray.Contains(t.cut));
                }

                if (kv.Key == "duichen" && !string.IsNullOrEmpty(kv.Value))
                {
                    string[] duichenArray = kv.Value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    result = DynamicQueryable.And(result, t => duichenArray.Contains(t.symmetry));
                }
                if (kv.Key == "paoguang" && !string.IsNullOrEmpty(kv.Value))
                {
                    string[] paoguangArray = kv.Value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    result = DynamicQueryable.And(result, t => paoguangArray.Contains(t.polish));
                }
                if (kv.Key == "yingguang" && !string.IsNullOrEmpty(kv.Value))
                {
                    string[] yingguangArray = kv.Value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    result = DynamicQueryable.And(result, t => yingguangArray.Contains(t.fluorescence));
                }
                if (kv.Key == "isSpot" && !string.IsNullOrEmpty(kv.Value))
                {
                    if (kv.Value == "true")
                    {
                        result = DynamicQueryable.And(result, t => t.stocknumber > 0);
                    }
                }

                if (kv.Key == "orderby")
                {
                    string value = kv.Value.Replace("price", "memberprice");
                    value = value.Replace("weigth", "carat");
                    value = value.Replace("color", "color");
                    value = value.Replace("jd", "clarity");
                    value = value.Replace("cut", "cut");
                    orderby = value;
                }

            }
            return pDal.getDiamonds(typeid, result, orderby, pagesize, pageindex, out datacount);
        }
    }
}
