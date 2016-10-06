using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KuChat.Models;

namespace KuChat.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            using (var db = new DatabaseContext())
            {
                var account = db.Accounts.Find(Guid.Parse("a2d2a066-6549-459e-805b-b303fc5b30ae"));
                var session = new Session { Account = account };

                db.Sessions.Add(session);
                db.SaveChanges();

                Response.SetCookie(new HttpCookie("kc_sid", session.Id));
            }

            return null;
        }

        public ActionResult Login2()
        {
            using (var db = new DatabaseContext())
            {
                var account = db.Accounts.Find(Guid.Parse("a2d2a066-6549-459e-805b-b303fc5b30a2"));
                var session = new Session { Account = account };

                db.Sessions.Add(session);
                db.SaveChanges();

                Response.SetCookie(new HttpCookie("kc_sid", session.Id));
            }

            return null;
        }
    }
}