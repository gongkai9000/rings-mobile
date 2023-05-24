using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace cs
{
    public class Cart
    {
        //private bool isLogin = false;
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="isLogin">是否登录</param>
        //public Cart(bool isLogin)
        //{
        //    this.isLogin = isLogin;
        //}
        ///// <summary>
        ///// 獲取購物車
        ///// </summary>
        ///// <returns></returns>
        //public DataTable GetCart()
        //{
        //    if (isLogin)
        //    {
        //        return cs.CartDatabase.GetCart();
        //    }
        //    else
        //    {
        //        return cs.CartXml.GetCart();
        //    }
        //}


        ///// <summary>
        ///// 清空購物車
        ///// </summary>
        //public void ClearCart()
        //{
        //    if (isLogin)
        //    {
        //        cs.CartDatabase.ClearCart();
        //    }
        //    else
        //    {
        //        cs.CartXml.ClearCart();
        //    }
        //}

        ////生成随机数
        //public string randomNum()
        //{
        //    if (isLogin)
        //    {
        //        return cs.CartDatabase.randomNum();
        //    }
        //    else
        //    {
        //        return cs.CartXml.randomNum();
        //    }
        //}


        //public string GetTotal(bool MemberPrice)
        //{
        //    if (isLogin)
        //    {
        //        return cs.CartDatabase.GetTotal(MemberPrice);
        //    }
        //    else
        //    {
        //        return cs.CartXml.GetTotal(MemberPrice);
        //    }
        //}

        //public int GetNumber()
        //{
        //    if (isLogin)
        //    {
        //        return cs.CartDatabase.GetNumber();
        //    }
        //    else
        //    {
        //        return cs.CartXml.GetNumber();
        //    }
        //}

        //public void DeleteCartById(string Id)
        //{
        //    if (isLogin)
        //    {
        //        cs.CartDatabase.DeleteCartById(Id);
        //    }
        //    else
        //    {
        //        cs.CartXml.DeleteCartById(Id);
        //    }
        //}

        //public void SetHandSize(string Id, string HandSize)
        //{
        //    if (isLogin)
        //    {
        //        cs.CartDatabase.SetHandSize(Id, HandSize);
        //    }
        //    else
        //    {
        //        cs.CartXml.SetHandSize(Id, HandSize);
        //    }
        //}

        //public void SetFontStyle(string Id, string FontStyle)
        //{
        //    if (isLogin)
        //    {
        //        cs.CartDatabase.SetFontStyle(Id, FontStyle);
        //    }
        //    else
        //    {
        //        cs.CartXml.SetFontStyle(Id, FontStyle);
        //    }
        //}


        //#region 添加到購物車
        ///// <summary>
        ///// 添加到購物車
        ///// </summary>
        ///// <param name="ProductId"></param>
        //public void AddToCart(int ProductId, bool IsDiyStylePrice, string Material, string FontStyle, string HandSize, string Type, string DiamondId)
        //{
        //    if (isLogin)
        //    {
        //        cs.CartDatabase.AddToCart(ProductId, IsDiyStylePrice, Material, FontStyle, HandSize , Type, DiamondId);
        //    }
        //    else
        //    {
        //        cs.CartXml.AddToCart(ProductId, IsDiyStylePrice, Material, FontStyle, HandSize, Type, DiamondId);
        //    }
        //}
        //#endregion

        ////根据材质获取价格//
        //public string Get_Price(string CaiZhi, int Pid)
        //{
        //    if (isLogin)
        //    {
        //        return cs.CartDatabase.Get_Price(CaiZhi, Pid);
        //    }
        //    else
        //    {
        //        return cs.CartXml.Get_Price(CaiZhi, Pid);
        //    }
        //}

        //public string GetCartValue()
        //{
        //    if (isLogin)
        //    {
        //        return string.Empty;
        //    }
        //    else
        //    {
        //        return cs.CartXml.GetCartValue();
        //    }
        //}
    }
}