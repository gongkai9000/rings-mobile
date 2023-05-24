using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRM.BLL
{
    public class CustomException : Exception
    {
        public string CustomMsg { get; set; }
        public CustomException(string msg)
        {
            this.CustomMsg = msg;   
        }
    }
}
