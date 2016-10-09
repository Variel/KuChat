using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace KuChat.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Content> Contents { get; set; }

        public DatabaseContext()
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
                (sender, e) => DateTimeKindAttribute.Apply(e.Entity);
        }
    }
}