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



namespace cs
{
    public class CartXml
    {
        //public const string SessionKey = "SessionKey";
        //public const string CartKey = "Cart";
        ////private const string format = "#.##";  //保留小数
        //private const string format = "0.00";  //保留小数


        ///// <summary>
        ///// 獲取購物車
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable GetCart()
        //{
        //    string XmlFilePath = GetXmlPath();
        //    return Framework.Common.Data.XmlToDataTable(XmlFilePath);
        //}

        //public static string GetCartValue()
        //{
        //    string value = null;
        //    if (System.Web.HttpContext.Current.Request.Cookies[CartKey] != null)
        //    {
        //        return System.Web.HttpContext.Current.Request.Cookies[CartKey].Value;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //John add 2014/03/17 start
        //            bool lb_flag;
        //            int runCount = 0;

        //            do
        //            {
        //                runCount++;
        //                string tempOrderid = DateTime.Now.ToString("yyyyMMddffffff");
        //                List<Field> oCountList = new List<Field>();
        //                oCountList.Add(new Field("countName", CartKey));
        //                oCountList.Add(new Field("countVlaue", tempOrderid));
        //                lb_flag = DbHelper.ExcuteInsert("Id", "t_ncount", "count_name,count_value", "@countName,@countVlaue", oCountList);
        //                if (lb_flag == true)
        //                {
        //                    value = tempOrderid;
        //                }
        //                if (runCount == 180)
        //                {
        //                    throw new Exception("执行" + CartKey + " Count180次任然无法获取有效的" + CartKey);
        //                }
        //            } while (lb_flag == false);

        //            int UserId = 0;
        //            string LogUserName = "未注册用户";
        //            if (cs.Member.GetLogin)
        //            {
        //                UserId = cs.Member.GetUserId;
        //                LogUserName = cs.Member.GetUserName;
        //            }
        //            cs.orderStatus.WriteLog(value, UserId, LogUserName, cs.orderStatus.UserType.前台账号, "获取唯一购物车号");
        //            //John add 2014/03/17 end
        //        }
        //        catch (Exception ex)
        //        {
        //            int UserId = 0;
        //            string LogUserName = "未注册用户";
        //            if (cs.Member.GetLogin)
        //            {
        //                UserId = cs.Member.GetUserId;
        //                LogUserName = cs.Member.GetUserName;
        //            }
        //            cs.orderStatus.WriteLog(value, UserId, LogUserName, cs.orderStatus.UserType.前台账号, ex.ToString());
        //            throw ex;
        //        }
        //    }
        //    return value;
        //}

        ///// <summary>
        ///// 清空購物車
        ///// </summary>
        //public static void ClearCart()
        //{
        //    Cookie.ClearCookie(CartKey);
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

        //public static string GetXmlPath()
        //{
        //    string Key = GetCartValue();
        //    if (System.Web.HttpContext.Current.Request.Cookies[CartKey] == null)
        //    {
        //        HttpCookie hc = new HttpCookie(CartKey, Key);
        //        //hc.Expires = Framework.Common.Time.GetDateTime().AddDays(1);
        //        System.Web.HttpContext.Current.Response.AppendCookie(hc);
        //    }
        //    return System.Web.HttpContext.Current.Server.MapPath(string.Format("~/xml/{0}.xml", Key));
        //}

        //public static string GetTotal(bool MemberPrice)
        //{
        //    decimal total = 0;
        //    DataTable dt = GetCart();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (MemberPrice)
        //        {
        //            total += decimal.Parse(dt.Rows[i]["SumMember"].ToString());
        //        }
        //        else
        //        {
        //            total += decimal.Parse(dt.Rows[i]["Sum"].ToString());
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
        //    decimal total = 0;
        //    DataTable dt = GetCart();
        //    return dt.Rows.Count;
        //}

        //public static void DeleteCartById(string Id)
        //{
        //    if (Id.Length > 0)
        //    {
        //        string XmlFilePath = GetXmlPath();
        //        DataTable dt = GetCart();
        //        DataRow[] drarr = null;
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            drarr = dt.Select(string.Format("Id='{0}'", Id));
        //        }
        //        if (!Framework.Common.Data.GetIsNullDataRows(drarr))
        //        {
        //            drarr[0].Delete();
        //            dt.WriteXml(XmlFilePath);
        //        }
        //    }
        //}

        //public static void SetHandSize(string Id, string HandSize)
        //{
        //    try
        //    {
        //        if (Id.Length > 0)
        //        {
        //            string XmlFilePath = GetXmlPath();
        //            DataTable dt = GetCart();

        //            DataRow[] drarr = null;
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                drarr = dt.Select(string.Format("Id='{0}'", Id));
        //            }
        //            if (!Framework.Common.Data.GetIsNullDataRows(drarr))
        //            {
        //                drarr[0]["handsize"] = HandSize;
        //                dt.WriteXml(XmlFilePath);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //public static void SetFontStyle(string Id, string FontStyle)
        //{
        //    try
        //    {
        //        if (Id.Length > 0)
        //        {
        //            string XmlFilePath = GetXmlPath();
        //            DataTable dt = GetCart();

        //            DataRow[] drarr = null;
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                drarr = dt.Select(string.Format("Id='{0}'", Id));
        //            }
        //            if (!Framework.Common.Data.GetIsNullDataRows(drarr))
        //            {
        //                drarr[0]["fontstyle"] = FontStyle;
        //                dt.WriteXml(XmlFilePath);
        //            }
        //        }
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
        //        string XmlFilePath = GetXmlPath();
        //        DataTable dt = GetCart();

       
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


        //            if (dt == null || dt.Rows.Count == 0)
        //            {
        //                dt.Columns.Add("ProductId");//Id
        //                dt.Columns.Add("DiamondId");//单价
        //                dt.Columns.Add("Title");//名字
        //                dt.Columns.Add("ProductImg");//产品图片
        //                dt.Columns.Add("MemberPrice");//會員價
        //                dt.Columns.Add("DiamondPrice");//钻石价格
        //                dt.Columns.Add("Quantity");//数量
        //                dt.Columns.Add("Sum");//小计
        //                dt.Columns.Add("SumMember");//小计
        //                //dt.Columns.Add("Desc");//说明
        //                //dt.Columns.Add("Group");//分组

        //                dt.Columns.Add("type");//类型
        //                dt.Columns.Add("Material");//材质
        //                dt.Columns.Add("handsize");//手寸
        //                dt.Columns.Add("fontstyle");//刻字
        //                dt.Columns.Add("Id");//编号，便于修改
        //            }

        //            DataRow dr2 = dt.NewRow();
        //            dr2["ProductId"] = ProductId;
        //            dr2["DiamondId"] = DiamondId;
        //            dr2["Title"] = dr["Title"].ToString();
        //            dr2["ProductImg"] = dr["imgurl1"].ToString();
        //            dr2["MemberPrice"] = d1;
        //            dr2["DiamondPrice"] = d3;
        //            dr2["Quantity"] = 1;
        //            dr2["Sum"] = d1;
        //            dr2["SumMember"] = d1;

        //            dr2["Material"] = Material;
        //            dr2["handsize"] = HandSize;
        //            dr2["fontstyle"] = FontStyle;
        //            dr2["type"] = Type;

        //            dr2["Id"] = DateTime.Now.Ticks.ToString();


        //            dt.Rows.Add(dr2);
        //            dt.TableName = "DateSet";
        //            Framework.Common.Data.WriteXml(dt, XmlFilePath);
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
        //    string rjg = "0";

        //    cz = cs.db.PrductGetValue("caizhi", Pid);
        //    jg = cs.db.PrductGetValue("Price", Pid);

        //    for (int i = 0; i < cz.Split(',').Length; i++)
        //    {
        //        if (cz.Split(',')[i].ToString() == CaiZhi)
        //        {
        //            rjg = jg.Split(',')[i].ToString();
        //        }
        //    }
        //    return rjg;
        //}
       
    }
}
