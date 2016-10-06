using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KuChat.Models
{
    public class Connection
    {
        public string Id { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public Guid AccountId { get; set; }


        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public Connection() { }
        public Connection(string connectionId, Account account)
        {
            this.Id = connectionId;
            this.Account = account;
        }
    }
}