using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Collections;

using DRM.Entity;

namespace cs
{
	public class CartDatabase
	{
        //public const string SessionKey = "SessionKey";
        //private const string CartKey = "Cart";
        ////private const string format = "#.##";  //保留小数
        //private const string format = "0.00";  //保留小数


        ///// <summary>
        ///// 獲取購物車
        ///// </summary>
        ///// <returns></returns>
        //public static List<T_Cart> GetCart(int memberId)
        //{
        //    CartBLL cartBll = new CartBLL();
        //    return cartBll.GetCartByMemberId(cs.Member.GetUserId);
        //}

        ///// <summary>
        ///// 獲取購物車
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable GetCart()
        //{
        //    //string XmlFilePath = GetXmlPath();           
        //    //return Framework.Common.Data.XmlToDataTable(XmlFilePath);
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ProductId");//Id
        //    dt.Columns.Add("DiamondId");//单价
        //    dt.Columns.Add("Title");//名字
        //    dt.Columns.Add("ProductImg");//产品图片
        //    dt.Columns.Add("MemberPrice");//會員價
        //    dt.Columns.Add("DiamondPrice");//钻石价格
        //    dt.Columns.Add("Quantity");//数量
        //    dt.Columns.Add("Sum");//小计
        //    dt.Columns.Add("SumMember");//小计
        //    //dt.Columns.Add("Desc");//说明
        //    //dt.Columns.Add("Group");//分组

        //    dt.Columns.Add("type");//类型
        //    dt.Columns.Add("Material");//材质
        //    dt.Columns.Add("handsize");//手寸
        //    dt.Columns.Add("fontstyle");//刻字
        //    dt.Columns.Add("Id");//编号，便于修改

        //    CartBLL cartBll = new CartBLL();
        //    List<T_Cart> cartList = cartBll.GetCartByMemberId(cs.Member.GetUserId);

        //    foreach (T_Cart cart in cartList)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["Id"] = cart.Id;
        //        dr["ProductId"] = cart.ProductId;
        //        dr["DiamondId"] = cart.DiamondId;
        //        dr["Title"] = cart.Title;
        //        dr["ProductImg"] = cart.ProductImg;
        //        dr["MemberPrice"] = cart.MemberPrice;
        //        dr["DiamondPrice"] = cart.DiamondPrice;
        //        dr["Quantity"] = cart.Quantity;
        //        dr["Sum"] = cart.Sum;
        //        dr["SumMember"] = cart.SumMember;
        //        dr["type"] = cart.type;
        //        dr["Material"] = cart.Material;
        //        dr["handsize"] = cart.handsize;
        //        dr["fontstyle"] = cart.fontstyle;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}


        ///// <summary>
        ///// 清空購物車
        ///// </summary>
        //public static void ClearCart()
        //{


        //    CartBLL cartBll = new CartBLL();
        //    cartBll.DeleteCartByMemberId(cs.Member.GetUserId);

        //}

        ////生成随机数
        //public static string randomNum()
        //{
        //    System.Collections.ArrayList list = new System.Collections.ArrayList();
        //    string str = "0,1,2,3,4,5,6,7,8,9";
        //    list.AddRange(str.Split(','));
        //    //随机码。
        //    string randomContent = "";
        //    Random rd = new Random();
        //    //设置随机码的个数。这里你也可以随机生成一个范围数，应该QQ的位数不是固定的。
        //    int nuM = 4;
        //    for (int i = 0; i < nuM; i++)
        //    {
        //        randomContent += list[rd.Next(0, 9)];
        //    }
        //    return randomContent;
        //}

        //public static string GetTotal(bool MemberPrice)
        //{
        //    decimal total = 0;
        //    List<T_Cart> cartList = GetCart(cs.Member.GetUserId);
        //    foreach(T_Cart c in cartList)
        //    {
        //        if (MemberPrice)
        //        {
        //            total += c.SumMember.Value;
        //        }
        //        else
        //        {
        //            total += c.Sum.Value;
        //        }
        //    }
        //    if (total.ToString().Length > 0)
        //    {
        //        return total.ToString(format);
        //    }
        //    return "0";
        //}

        //public static int GetNumber()
        //{
        //    List<T_Cart> cartList = GetCart(cs.Member.GetUserId);
        //    return cartList.Count;
        //}

        //public static void DeleteCartById(string Id)
        //{
        
        //    CartBLL cartBll = new CartBLL();
        //    cartBll.DeleteCartById(Convert.ToInt32(Id));
        //}

        //public static void SetHandSize(string Id , string HandSize)
        //{
        //    try
        //    {
         
        //        CartBLL cartBll = new CartBLL();
        //        T_Cart cart = cartBll.GetCartByID(Convert.ToInt32(Id));
        //        cart.handsize = Convert.ToInt32(HandSize);
        //        cartBll.UpdateCart(cart);
        //    }
        //    catch
        //    {

        //    }
        //}

        //public static void SetFontStyle(string Id, string FontStyle)
        //{
        //    try
        //    {
        //        CartBLL cartBll = new CartBLL();
        //        T_Cart cart = cartBll.GetCartByID(Convert.ToInt32(Id));
        //        cart.fontstyle = FontStyle;
        //        cartBll.UpdateCart(cart);
        //    }
        //    catch
        //    {

        //    }
        //}



        //#region 添加到購物車
        ///// <summary>
        ///// 添加到購物車
        ///// </summary>
        ///// <param name="ProductId"></param>
        //public static void AddToCart(int ProductId, bool IsDiyStylePrice, string Material, string FontStyle, string HandSize, string Type, string DiamondId)
        //{
        //    if (ProductId > 0)
        //    {
        //        //string XmlFilePath = GetXmlPath();
        //        //DataTable dt = GetCart(cs.Member.GetUserId);

        //        List<Field> oList = new List<Field>();
        //        oList.Add(new Field("ProductId", ProductId));
        //        DataRow dr = DbHelper.GetDataRow("select * from T_Product where ProductId=@ProductId", oList);//去掉判断 and display=0

        //        string DiamondPrice = "0";//裸钻价格
        //        string MrDiamondPrice = "0";//戒指默认裸钻价格
        //        int RingPrice = 0;//当前戒指总价
        //        int RingAskedPrice = 0;//当前戒托价格

        //        int Sum = 0;
        //        string d1;//小计
        //        string d2;//戒指价格
        //        string d3;//裸钻价格


        //        if (dr != null)
        //        {
        //            bool IsCustom = false;
        //            IsCustom = (TypeParse.StrToInt(dr["diybit"].ToString(), 0) == 1);//判断是否可以订制

        //            if (IsCustom == true) //允许订制
        //            {
        //                oList.Add(new Field("DProductId", DiamondId));
        //                DataRow dr1 = DbHelper.GetDataRow("select * from T_Product where ProductId=@DProductId", oList);//去掉判断 and display=0
        //                if (dr1 != null)
        //                {
        //                    DiamondPrice = dr1["memberprice"].ToString();//当前裸钻价格
        //                    MrDiamondPrice = dr["diyStylePrice"].ToString();//戒指默认裸钻价格

        //                    //判断材质是否为空
        //                    if (Material == "")
        //                    {
        //                        //当前戒托价格=戒指总价-戒指默认裸钻价格
        //                        RingAskedPrice = int.Parse(dr["memberprice"].ToString()) - int.Parse(MrDiamondPrice);
        //                        //当前戒指总价=当前裸钻价格+当前戒托价格
        //                        RingPrice = int.Parse(DiamondPrice) + RingAskedPrice;

        //                        d1 = Decimal.Parse(RingPrice.ToString()).ToString(format);//小计
        //                        d2 = Decimal.Parse(RingAskedPrice.ToString()).ToString(format);//戒指价格
        //                        d3 = Decimal.Parse(DiamondPrice).ToString(format);//裸钻价格
        //                    }
        //                    else
        //                    {
        //                        //获取当前材质价格
        //                        string MaterialPrice = Get_Price(Material, ProductId);
        //                        //当前戒托价格=当前材质价格-戒指默认裸钻价格
        //                        RingAskedPrice = int.Parse(MaterialPrice) - int.Parse(MrDiamondPrice);
        //                        //当前戒指总价=当前裸钻价格+当前戒托价格
        //                        RingPrice = int.Parse(DiamondPrice) + RingAskedPrice;

        //                        d1 = Decimal.Parse(RingPrice.ToString()).ToString(format);//小计
        //                        d2 = Decimal.Parse(RingAskedPrice.ToString()).ToString(format);//戒指价格
        //                        d3 = Decimal.Parse(DiamondPrice).ToString(format);//裸钻价格
        //                    }
        //                }
        //                else//不允许订制价格
        //                {
        //                    //判断材质是否为空
        //                    if (Material == "")
        //                    {
        //                        //当前戒托价格=戒指价格-戒指默认裸钻价格
        //                        RingAskedPrice = int.Parse(dr["memberprice"].ToString()) - int.Parse(MrDiamondPrice);
        //                        RingPrice = int.Parse(dr["memberprice"].ToString());

        //                        d1 = Decimal.Parse(RingPrice.ToString()).ToString(format);//小计
        //                        d2 = Decimal.Parse(RingAskedPrice.ToString()).ToString(format);//戒指价格
        //                        d3 = Decimal.Parse(MrDiamondPrice).ToString(format);//裸钻价格
        //                    }
        //                    else
        //                    {
        //                        //获取当前材质价格
        //                        string MaterialPrice = Get_Price(Material, ProductId);
        //                        //当前戒托价格=当前材质价格-戒指默认裸钻价格
        //                        RingAskedPrice = int.Parse(MaterialPrice) - int.Parse(MrDiamondPrice);
        //                        RingPrice = int.Parse(MaterialPrice);

        //                        d1 = Decimal.Parse(RingPrice.ToString()).ToString(format);//小计
        //                        d2 = Decimal.Parse(RingAskedPrice.ToString()).ToString(format);//戒指价格
        //                        d3 = Decimal.Parse(MrDiamondPrice).ToString(format);//裸钻价格
        //                    }
        //                }
        //            }//不允许订制价格
        //            else
        //            {
        //                //判断材质是否为空
        //                if (Material == "")
        //                {
        //                    //当前戒托价格=戒指价格-戒指默认裸钻价格
        //                    RingAskedPrice = int.Parse(dr["memberprice"].ToString()) - int.Parse(MrDiamondPrice);
        //                    RingPrice = int.Parse(dr["memberprice"].ToString());

        //                    d1 = Decimal.Parse(RingPrice.ToString()).ToString(format);//小计
        //                    d2 = Decimal.Parse(RingAskedPrice.ToString()).ToString(format);//戒指价格
        //                    d3 = Decimal.Parse(MrDiamondPrice).ToString(format);//裸钻价格
        //                }
        //                else
        //                {
        //                    //获取当前材质价格
        //                    string MaterialPrice = Get_Price(Material, ProductId);
        //                    //当前戒托价格=当前材质价格-戒指默认裸钻价格
        //                    RingAskedPrice = int.Parse(MaterialPrice) - int.Parse(MrDiamondPrice);
        //                    RingPrice = int.Parse(MaterialPrice);

        //                    d1 = Decimal.Parse(RingPrice.ToString()).ToString(format);//小计
        //                    d2 = Decimal.Parse(RingAskedPrice.ToString()).ToString(format);//戒指价格
        //                    d3 = Decimal.Parse(MrDiamondPrice).ToString(format);//裸钻价格
        //                }
        //            }

        //            T_Cart cart = new T_Cart();
        //            cart.MemberId = cs.Member.GetUserId;
        //            cart.ProductId = ProductId;
        //            cart.DiamondId = DiamondId == "" ? false : true;
        //            cart.Title = dr["Title"].ToString();
        //            cart.ProductImg = dr["imgurl1"].ToString();
        //            cart.MemberPrice = Convert.ToDecimal(d1);
        //            cart.DiamondPrice = Convert.ToDecimal(d3);
        //            cart.Quantity = 1;
        //            cart.Sum = Convert.ToDecimal(d1);
        //            cart.SumMember = Convert.ToDecimal(d1);

        //            cart.Material = Material;
        //            cart.handsize = Convert.ToInt32(HandSize);
        //            cart.fontstyle = FontStyle;
        //            cart.type = Type;

        //            CartBLL cartBll = new CartBLL();
        //            cartBll.AddCartData(cart);
        //        }
        //        //}
        //    }
        //}
        //#endregion

        ////根据材质获取价格//
        //public static string Get_Price(string CaiZhi, int Pid)
        //{
        //    string cz;
        //    string jg;
        //    string rjg="0";

        //    cz = cs.db.PrductGetValue("caizhi", Pid);
        //    jg = cs.db.PrductGetValue("Price", Pid);

        //        for (int i = 0; i < cz.Split(',').Length; i++)
        //        {
        //            if (cz.Split(',')[i].ToString() == CaiZhi)
        //            {
        //                rjg= jg.Split(',')[i].ToString();
        //            }
        //    }
        //        return rjg;
        //}


	}
}
