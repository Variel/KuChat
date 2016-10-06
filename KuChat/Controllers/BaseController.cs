using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KuChat.Models;

namespace KuChat.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Account Account { get; private set; }
        protected DatabaseContext Database { get; }

        public BaseController()
        {
            Database = new DatabaseContext();
        }

        protected override void Initialize(RequestContext requestContext)
        {
        }
    }
}