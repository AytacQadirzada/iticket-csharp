using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Expection
{
    public class OtpMismatchException :Exception
    {        
        public OtpMismatchException() : base("OTP uyğun gəlmir!") { }

        public OtpMismatchException(string message) : base(message) { }

        public OtpMismatchException(string message, Exception inner) : base(message, inner) { }
    }
}
