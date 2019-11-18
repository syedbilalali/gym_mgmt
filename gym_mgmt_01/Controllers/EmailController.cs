using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gym_mgmt_01.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace gym_mgmt_01.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("sayedbilalali614@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("bilal@younggeeks.in");  // replace with valid value
                message.Subject = "Demo for the testing Mail form ";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "bilal@younggeeks.in",  // replace with valid value
                        Password = "bilal@admin"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.hostinger.in";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}