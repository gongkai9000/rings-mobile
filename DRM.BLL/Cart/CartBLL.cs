using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.DAL;
using DRM.Entity;
using System.Web;
using DRM.BLL.Order;

namespace DRM.BLL
{
    public class CartBLL
    {

        /// <summary>
        /// 根据会员id,获取购物车数据
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public List<T_Cart> GetCartByMemberId(int memberId)
        {
            CartDAL cDal = new CartDAL();
            var data = cDal.GetCartByMemberId(memberId);
            //foreach (T_Cart c in data)
            //{
            //    c.fontstyle = c.fontstyle.Replace("?", "♥");
            //}
            return data;
        }

        public List<view_cart> GetViewCartByMemberId(int memberId)
        {
            CartDAL cDal = new CartDAL();
            return cDal.GetViewCartByMemberId(memberId);
        }

        /// <summary>
        /// 根据会员id,清理购物车
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public int DeleteCartByMemberId(int memberId)
        {
            CartDAL cDal = new CartDAL();
            return cDal.DeleteCartByMemberId(memberId);
        }

        /// <summary>
        /// 添加购物车信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddCartData(T_Cart c)
        {
            CartDAL cDal = new CartDAL();
            return cDal.AddCartData(c);
        }


        /// <summary>
        /// 根据唯一ID,返回Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_Cart GetCartByID(int id)
        {
            CartDAL cDal = new CartDAL();
            return cDal.GetCartByID(id);
        }

        /// <summary>
        /// 修改一条购物车数据
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int UpdateCart(T_Cart c)
        {
            CartDAL cDal = new CartDAL();
            return cDal.UpdateCart(c);
        }

        /// <summary>
        /// 根据ID删除购物车数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCartById(int id, int memberid)
        {
            CartDAL cDal = new CartDAL();
            return cDal.DeleteCartById(id, memberid, GetInts());
        }


        /// <summary>
        /// 根据产品生成购物车数据
        /// </summary>
        /// <param name="p"></param>
        /// <param name="memberid"></param>
        /// <param name="handsize"></param>
        /// <param name="font"></param>
        public void AddCartByProduct(view_product2 p, int memberid, string handsize, string font, string material, int? diamondId, int? fdiamondId, string type,string sirName,string sirCode)
        {
            T_Cart cart = new T_Cart();
            cart.MemberId = memberid;
            cart.ProductId = p.id;
            //cart.DiamondId = p
            cart.Title = p.title;
            cart.ProductImg = p.imgurl;
            cart.DiamondId = diamondId;
            cart.fDiamondId = fdiamondId;

            ProductBLL npBll = new ProductBLL();
            decimal zdiamondPrice = npBll.GetDiamondPrice(diamondId ?? 0, p.znumber ?? 0);
            decimal fdiamondPrice = npBll.GetDiamondPrice(fdiamondId ?? 0, p.fnumber ?? 0);
            //手寸价格浮动
            decimal handSizePrice = GetHandSizePrice(p.id, handsize, material);
            decimal pPrice = ProductPrice(npBll.GetMaterialPrice(material, p.id), zdiamondPrice, fdiamondPrice) + handSizePrice;

            cart.MemberPrice = pPrice;
            cart.Sum = pPrice;
            cart.SumMember = pPrice;

            //cart.DiamondPrice = p.d
            //cart.Quantity = p
            //cart.Sum = p.
            //cart.SumMember = p.
            cart.type = type;
            cart.Material = material;
            cart.handsize = handsize;
            cart.fontstyle = font;
            cart.addtime = DateTime.Now;
            cart.isNewWeb = true;
            cart.appid = 1;

            cart.sirName = sirName;
            cart.sirCode = sirCode;
            AddCartData(cart);
        }



        /// <summary>
        /// 获取手寸浮动的价格
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        private decimal GetHandSizePrice(int p, string handsize, string material)
        {
            decimal? price = 0;
            if (handsize != "")
            {
                var model = new HandSizeBll().GetSize(p, int.Parse(handsize), material);

                if (model != null)
                {
                    price = model.price;
                }
            }

            return Convert.ToDecimal(price);
        }


        /// <summary>
        /// 根据产品生成购物车数据[对戒]
        /// </summary>
        /// <param name="p"></param>
        /// <param name="memberid"></param>
        /// <param name="handsize"></param>
        /// <param name="font"></param>
        public void AddCartByProduct(view_product2 p, int manid, int womanid, int memberid, string handsize, string mansize, string womansize, string font, string material, int? mandiamondId, int? manfdiamondId, int? womandiamondId, int? womanfdiamondId)
        {
            T_Cart cart = new T_Cart();
            cart.MemberId = memberid;
            cart.ProductId = p.id;
            //cart.DiamondId = p
            cart.Title = p.title;
            cart.ProductImg = p.imgurl;
            cart.DiamondId = mandiamondId;
            cart.fDiamondId = womandiamondId;

            ProductBLL npBll = new ProductBLL();
            decimal manzdiamondPrice = npBll.GetDiamondPrice(mandiamondId ?? 0, p.znumber ?? 0);
            decimal manfdiamondPrice = npBll.GetDiamondPrice(manfdiamondId ?? 0, p.fnumber ?? 0);
            decimal manHandSizePrice = GetHandSizePrice(manid, mansize, material);
            decimal womanzdiamondPrice = npBll.GetDiamondPrice(womandiamondId ?? 0, p.znumber ?? 0);
            decimal womanfdiamondPrice = npBll.GetDiamondPrice(womanfdiamondId ?? 0, p.fnumber ?? 0);
            decimal whandsizePrice = GetHandSizePrice(womanid, womansize, material);
            decimal manpPrice = ProductPrice(npBll.GetMaterialPrice(material, manid), manzdiamondPrice, manfdiamondPrice) + manHandSizePrice;
            decimal womanpPrice = ProductPrice(npBll.GetMaterialPrice(material, womanid), womanzdiamondPrice, womanfdiamondPrice) + whandsizePrice;

            decimal pPrice = manpPrice + womanpPrice;
            cart.MemberPrice = pPrice;
            cart.Sum = pPrice;
            cart.SumMember = pPrice;

            //cart.DiamondPrice = p.d
            //cart.Quantity = p
            //cart.Sum = p.
            //cart.SumMember = p.
            cart.type = "对戒";
            cart.Material = material;
            cart.handsize = handsize;
            cart.fontstyle = font;
            cart.addtime = DateTime.Now;
            cart.isNewWeb = true;
            cart.appid = 1;
            AddCartData(cart);
        }

        /// <summary>
        /// 产品价格
        /// </summary>
        /// <param name="materialPrice"></param>
        /// <param name="diamondPrice"></param>
        /// <returns></returns>
        public decimal ProductPrice(decimal materialPrice, decimal diamondPrice, decimal fdiamondPrice)
        {
            return materialPrice + diamondPrice + fdiamondPrice;
        }

        public decimal GetTotal(int memberid)
        {
            CartDAL cDal = new CartDAL();
            return cDal.GetTotal(memberid);
        }
        public decimal GetTotal(List<view_cart> cartList)
        {
            return cartList.Sum(t => t.MemberPrice) ?? 0;
        }

        /// <summary>
        /// 获取CTloves钻戒类型集合
        /// </summary>
        /// <returns></returns>
        public static List<int> GetInts()
        {
            return new ProTypeBll().GetChidlTypeList(ProductBLL.DarryRingTypeID).Select(t=>t.id).ToList();
        }
        /// <summary>
        /// 判断购物车列表中是否存在darry钻戒
        /// </summary>
        /// <param name="cartList"></param>
        /// <returns></returns>
        public bool IsHaveDarry(List<T_Cart> cartList)
        {
            CartDAL cDal = new CartDAL();
            List<int> ints = GetInts();
            return cDal.IsHaveDarry(cartList, ints);
        }

        /// <summary>
        /// 判断购物车列表中是否存在darry钻戒
        /// </summary>
        /// <param name="cartList"></param>
        /// <returns></returns>
        public bool IsHaveDarry(List<view_cart> cartList)
        {
            CartDAL cDal = new CartDAL();
            List<int> ints = GetInts();
            return cDal.IsHaveDarry(cartList, ints);
        }

        /// <summary>
        /// 判断购物车列表中是否存在darry钻戒
        /// </summary>
        /// <param name="cartList"></param>
        /// <returns></returns>
        public T_Cart getDarryInCart(List<T_Cart> cartList)
        {
            CartDAL cDal = new CartDAL();
            List<int> ints = GetInts();
            return cDal.getDarryInCart(cartList, ints);
        }

        /// <summary>
        /// 判断购物车列表中是否存在darry钻戒
        /// </summary>
        /// <param name="cartList"></param>
        /// <returns></returns>
        public view_cart getDarryInCart(List<view_cart> cartList)
        {
            CartDAL cDal = new CartDAL();
            List<int> ints = GetInts();
            return cDal.getDarryInCart(cartList, ints);
        }


        public string getDarryImg(List<T_Cart> cartList)
        {
            CartDAL cDal = new CartDAL();
            List<int> ints = GetInts();
            var p = cDal.getDarryProduct(cartList, ints);
            if (p == null)
            {
                return string.Empty;
            }
            else
            {
                return p.imgurl;
            }
        }

        /// <summary>
        /// 判断此数据是否是Darry 钻戒 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsHaveDarry(T_Cart c)
        {
            CartDAL cDal = new CartDAL();
            return cDal.IsHaveDarry(c);
        }
        #region Order部分
        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <returns></returns>
        public ResultMsg AddOrder(T_Order order, T_Member member)
        {
            ResultMsg rMsg = new ResultMsg();

            OrderDAL oDal = new OrderDAL();
            rMsg.Result = oDal.AddOrder(order);

            //录入订单日志
            if (rMsg.Result)
            {
                T_Order_Log log = new T_Order_Log();
                log.orderid = order.orderid;
                log.addtime = DateTime.Now;
                log.log_text = "订单创建";
                log.op_id = member.Id;
                log.op_name = member.email;
                log.op_type = OrderStatus.UserType.前台账号.ToString();

                OrderLogDAL orderLogDal = new OrderLogDAL();
                orderLogDal.AddOrderLog(log);

            }
            return rMsg;
        }


        /// <summary>
        /// 将购物车实体转换为订单详情实体
        /// </summary>
        /// <param name="cartlList"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<T_OrderDetail> AddCartToOrderDetail(List<T_Cart> cartlList, string orderId)
        {
            List<T_OrderDetail> result = new List<T_OrderDetail>();
            foreach (T_Cart cart in cartlList)
            {
                T_OrderDetail detail = new T_OrderDetail
                {
                    orderId = orderId,
                    ProductId = cart.ProductId,
                    Title = cart.Title,
                    Price = cart.MemberPrice,
                    memberprice = Convert.ToString(cart.MemberPrice),
                    Quantity = cart.Quantity,
                    protype = cart.type,
                    handsize = Convert.ToString(cart.handsize),
                    fontstyle = cart.fontstyle,
                    Material = cart.Material,
                    isNewWeb = true,
                    diamondId = cart.DiamondId,
                    fdiamondId = cart.fDiamondId
                };
                result.Add(detail);
            }
            return result;
        }


        /// <summary>
        /// 添加订单详情
        /// </summary>
        /// <param name="detailList"></param>
        /// <returns></returns>
        public bool AddOrderDetail(List<T_OrderDetail> detailList)
        {
            CartDAL cDal = new CartDAL();
            return cDal.AddOrderDetail(detailList);
        }
        #endregion

        /// <summary>
        /// 获取购物车中数量
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public int GetCartCount(int memberid)
        {
            CartDAL cDal = new CartDAL();
            return cDal.GetCartCount(memberid);
        }

        /// <summary>
        /// 购买Darry前验证账号
        /// </summary>
        /// <returns></returns>
        public ResultMsg DarryCheckMember(int memberid)
        {
            List<T_Cart> cList = GetCartByMemberId(memberid);
            DarryHomeBLL dhBll = new DarryHomeBLL();
            ResultMsg msg = new ResultMsg();
            msg.Result = true;
            if (IsHaveDarry(cList))
            {
                msg.Result = false;
                msg.Msg = "购物车中存在CTloves钻戒。";
            }
            if (dhBll.IsBuyDarry(memberid))
            {
                msg.Result = false;
                msg.Msg = "此账号已购买过CTloves钻戒。";
            }
            //if (dhBll.IsBuyDarry(context.Request.QueryString["cartid"]))
            //{
            //    msg.Msg = "此身份证已购买过CTloves。";
            //}
            return msg;
        }

        /// <summary>
        /// 购买Darry时验证账号
        /// </summary>
        /// <returns></returns>
        public ResultMsg DarryCheckMember(int memberid, string cardid)
        {
            List<T_Cart> cList = GetCartByMemberId(memberid);
            DarryHomeBLL dhBll = new DarryHomeBLL();
            ResultMsg msg = new ResultMsg();
            msg.Result = true;
            if (IsHaveDarry(cList))
            {
                msg.Result = false;
                msg.Msg = "购物车中存在CTloves钻戒。";
            }
            if (dhBll.IsBuyDarry(memberid))
            {
                msg.Result = false;
                msg.Msg = "此账号已购买过CTloves钻戒。";
            }
            if (dhBll.IsBuyDarry(cardid))
            {
                msg.Result = false;
                msg.Msg = "此身份证已购买过CTloves钻戒。";
            }
            return msg;
        }

        public ResultMsg CheckOther(int memberid)
        {
            List<T_Cart> cList = GetCartByMemberId(memberid);
            DarryHomeBLL dhBll = new DarryHomeBLL();
            ResultMsg msg = new ResultMsg();
            msg.Result = true;
            if (IsHaveDarry(cList) || dhBll.IsBuyDarry(memberid))
            {
                msg.Result = true;

            }
            else
            {
                msg.Result = false;
                msg.Msg = "请先购买DarryRing钻戒";
            }

            return msg;
        }
    }
}
