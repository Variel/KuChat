using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KuChat.Models;

namespace KuChat.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var account = db.Accounts.Find(Guid.Parse("a2d2a066-6549-459e-805b-b303fc5b30ae"));
                var session = new Session { Account = account };

                db.Sessions.Add(session);
                db.SaveChanges();

                Response.SetCookie(new HttpCookie("kc_sid", session.Id));
            }
            return Json("1234", JsonRequestBehavior.AllowGet);
        }
    }
}