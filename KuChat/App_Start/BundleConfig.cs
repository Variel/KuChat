using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace KuChat.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/scripts/app/kuchat.js")
                .IncludeDirectory("~/scripts/app", "*.js", searchSubdirectories: true));
        }
    }
}