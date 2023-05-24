using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace DRM.Common
{
   public static class JSHelper
    {
       public static void Alert(string msg)
       {
           string ConfirmContent = "<script>alert('" + msg + "'); </script>";
           Page ParameterPage = (Page)System.Web.HttpContext.Current.Handler;
           ParameterPage.RegisterStartupScript("confirm", ConfirmContent);
       }

    }
}
