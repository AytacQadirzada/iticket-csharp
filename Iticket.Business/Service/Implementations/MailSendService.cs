using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Implementations;

public class MailSendService : IMailSendService
{
    public IActionResult SendEmail(string userEmail, string otp)
    {
        string from = "qadirzadaaytac@gmail.com";
        string to = userEmail;
        string subject = "iTicket hesabını təsdiqlənməsi";
        string body = $"Sizin OTP kodunuz: {otp}";

        MailMessage mailMessage = new(
            from,
            to,
            subject,
            body
        );
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        mailMessage.IsBodyHtml = true;

        SmtpClient client = new("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(from, "dtah hvas udzz vfsv");
        try
        {
            client.Send(mailMessage);
        }
        catch (Exception)
        {
            throw;
        }

        return Json("Ok");
    }
    public virtual JsonResult Json(object? data)
    {
        return new JsonResult(data);
    }

}
