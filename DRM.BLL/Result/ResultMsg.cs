using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DRM.BLL
{
    public class ResultMsg
    {
        public ResultMsg() { }
        public ResultMsg(bool result,string msg)
        {
            Result = result;
            Msg = msg;
        }

        private bool _result;
        public bool Result {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                if (string.IsNullOrEmpty(Msg))
                {
                    if (value)
                    {
                        Msg = "操作成功。";
                    }
                    else
                    {
                        Msg = "操作失败";
                    }
                }
            } 
        }

        public string Msg { get; set; }
    }
}
