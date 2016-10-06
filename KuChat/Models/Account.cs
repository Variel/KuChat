using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace KuChat.Models
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        [InverseProperty(nameof(Channel.Accounts))]
        public virtual ICollection<Channel> Channels { get; set; } = new HashSet<Channel>();
        public virtual ICollection<Connection> Connections { get; set; } = new HashSet<Connection>();


        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public object ToTransfer()
        {
            return new
            {
                id = this.Id,
                name = this.Name
            };
        }
    }
}