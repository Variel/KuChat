using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KuChat.Models
{
    public class Channel
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(Account.Channels))]
        public virtual ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
    }
}