using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRM.Entity;
using DRM.Common;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using System.Web.SessionState;

namespace drmobile.API
{
    /// <summary>
    /// AfterServiceCMD 的摘要说明
    /// </summary>
    public class AfterServiceCMD : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                int odid = Convert.ToInt32(context.Request.QueryString["odid"]);

                switch (context.Request.QueryString["action"])
                {
                    case "AddAfterService":
                        tb_AfterService aservice = new tb_AfterService();
                        aservice.AfterServiceUserId = CurrentUser.CurrentUid;
                        aservice.TypeService = context.Request.Form["TypeService"];
                        aservice.KRemarks = context.Request.Form["KRemarks"];
                        aservice.AddressId = Convert.ToInt32(context.Request.Form["addressid"]);
                        aservice.OrderDetailId = odid;
                        aservice.Orderid = context.Request.QueryString["orderid"];
                        aservice.AfterServiceNo = "AS" + DateTime.Now.ToString("yyyyMMddffffff");
                        aservice.AfterServiceDate = DateTime.Now;

                        AfterServiceBLL asBll = new AfterServiceBLL();
                        int result = 0;
                        asBll.AddAfterService(aservice,out result);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonFun.ResponseData(ex.Message, true);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class DateConverter : JavaScriptConverter
    {

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            if (obj == null)
                result["Value"] = string.Empty;
            else
            {
                DateTime jsdate = (DateTime)obj;
                result["Value"] = jsdate.ToString("yyyy-MM-dd HH:mm");
            }
            return result;
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                IList<Type> typelist = new List<Type>();
                typelist.Add(typeof(DateTime));
                typelist.Add(typeof(DateTime?));
                return typelist;
            }

        }
    }


}