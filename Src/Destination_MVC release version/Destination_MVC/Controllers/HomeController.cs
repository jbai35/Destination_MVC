using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Destination_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Document()
        {
            return View();
        }

        public ActionResult Send()
        {
            var userName = Request["userName"];
            var userEmail = Request["userEmail"];
            var userSubject = Request["userSubject"];
            var userContent = Request["userContent"];

            MailMessage newMsg = new MailMessage();

            try
            {
                //newMsg.To.Add(new MailAddress("jue.xie@monash.edu","Grace"));
                newMsg.To.Add(new MailAddress("jbai35@student.monash.edu", "BaiJun"));
                newMsg.From = new MailAddress(userEmail, userName);
                newMsg.Subject = userSubject;
                newMsg.Body = userContent;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.monash.edu.au";
                smtp.Send(newMsg);                
            }
            catch (Exception exc)
            {
                Console.Write(exc);
                return View("Error");
            }

            return View("Success");
        }
    }
}