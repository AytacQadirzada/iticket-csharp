using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Expection;

public class AuthException : Exception
{
    public int StatusCode { get; }
    public AuthException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
