using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRM.BLL.Result
{
    /// <summary>
    /// 验证是否购买过Darry，返回的类型
    /// </summary>
    public enum DarryCheckResult
    {
        /// <summary>
        /// 曾经购买过Darry，不能购买Darry,可以买其他珠宝
        /// </summary>
        NoCanBuy,
        ///// <summary>
        ///// 在购物车中，不能购买
        ///// </summary>
        //InCart,
        /// <summary>
        /// 尚未购买过Darry,可以购买Darry,无法购买其他珠宝
        /// </summary>
        CanBuy
    }
}
