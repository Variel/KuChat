using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KuChat.Extensions;
using KuChat.Models;

namespace KuChat.Controllers
{
    public class ChannelController : Controller
    {
        private DatabaseContext _database = new DatabaseContext();

        public ActionResult List()
        {
            return Json(_database.Channels.OrderBy(c => c.Name).ToTransfer(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult MyList()
        {
            var session = _database.Sessions.Find(Request.Cookies["kc_sid"]?.Value);
            var account = session?.Account;

            return Json(account.Channels.ToTransfer(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(string name, string description)
        {
            var session = _database.Sessions.Find(Request.Cookies["kc_sid"]?.Value);
            var account = session?.Account;
            
            if (account == null)
                return null;

            var channel = new Channel
            {
                Name = name,
                Description = description
            };
            channel.Accounts.Add(account);
            _database.SaveChanges();

            return Json(channel.ToTransfer());
        }

        public ActionResult Join(Guid id)
        {
            var session = _database.Sessions.Find(Request.Cookies["kc_sid"]?.Value);
            var account = session?.Account;

            if (account == null)
                return null;

            var channel = _database.Channels.Find(id);
            if (channel == null)
                return null;

            channel.Accounts.Add(account);
            _database.SaveChanges();

            return null;
        }

        public async Task<ActionResult> Abandon(Guid id)
        {
            var session = _database.Sessions.Find(Request.Cookies["kc_sid"]?.Value);
            var account = session?.Account;

            if (account == null)
                return null;

            var channel = _database.Channels.Find(id);
            if (channel == null)
                return null;

            channel.Accounts.Remove(account);
            _database.SaveChanges();

            return null;
        }
    }
}