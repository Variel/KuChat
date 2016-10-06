using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KuChat.Models;

namespace KuChat.Controllers
{
    public class ChannelController : Controller
    {
        public ActionResult Join(Guid id)
        {
            var database = new DatabaseContext();
            var session = database.Sessions.Find(Request.Cookies["kc_sid"]?.Value);
            var account = session?.Account;

            if (account == null)
                return null;

            var channel = database.Channels.Find(id);
            if (channel == null)
                return null;

            channel.Accounts.Add(account);
            database.SaveChanges();

            return null;
        }

        public async Task<ActionResult> Abandon(Guid id)
        {
            var database = new DatabaseContext();
            var session = database.Sessions.Find(Request.Cookies["kc_sid"]?.Value);
            var account = session?.Account;

            if (account == null)
                return null;

            var channel = database.Channels.Find(id);
            if (channel == null)
                return null;

            channel.Accounts.Remove(account);
            database.SaveChanges();

            return null;
        }
    }
}