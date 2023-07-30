using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Exception
{
    public class ResizeException : System.Exception
    {
        //public int StatusCode { get; set; }
        //public string Message { get; set; }
        //public string InnerException { get; set; }
        public ResizeException(int statusCode, string message) : base(message)
        {
            HResult = statusCode;
        }

    }

    internal class ResizeExceptionMessage
    {
        internal const string UnsupportedType = "فایل ورودی قابل تغییر سایز نمی باشد";
        internal const string LargSizeLimitaion = "حجم فایل ورودی بیشتر از مقدار مجاز می باشد ";
    }

    internal class ResizeExceptionCode
    {
        internal const int BusinessStatucCode = 400;

    }




}
