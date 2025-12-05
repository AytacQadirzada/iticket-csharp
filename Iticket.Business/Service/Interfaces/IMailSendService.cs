using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Interfaces
{
    public interface IMailSendService
    {
        IActionResult SendEmail(string email, string otp);
    }
}
