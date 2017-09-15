using NewABeginning.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NewABeginning.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
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
                message.To.Add(new MailAddress("nabin.adhikari1123@gmail.com"));
                message.From = new MailAddress(model.FromEmail);
                message.Subject = model.Subject.ToString();
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    message.Attachments.Add(new Attachment(model.Upload.InputStream, Path.GetFileName(model.Upload.FileName)));
                }
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("AutoReply");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AutoReply (EmailFormModel model)
        {

            if (ModelState.IsValid)
            {
                
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.FromEmail));
                message.From = new MailAddress("nabin.adhikari1123@gmail.com");
                message.Subject = "Automatic Reply, Please don't reply to this message";
                message.Body = string.Format("Thank you! for contacting us. We received your message at " + DateTime.Now +
                    " and will reply as soon as we can depending on the message we received. Sorry, for the inconvenince." +
                    " If you need immediate help, don't forget to call us on our direct hotline.");
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "nabin.adhikari1123@gmail.com",  // replace with valid value
                        Password = "Smile2307@"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
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