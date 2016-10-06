using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace KuChat.Models
{
    public class Session
    {
        public string Id { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public Guid AccountId { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime CreatedAtUtc { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime ExpiresAtUtc { get; set; }

        public bool Expired { get; set; }

        public Session()
        {
            var sha = Crypto.SHA256(Guid.NewGuid().ToString()) + Crypto.SHA256(Guid.NewGuid().ToString());
            var bytes = Enumerable.Range(0, sha.Length / 2)
                     .Select(x => Convert.ToByte(sha.Substring(x * 2, 2), 16))
                     .ToArray();
            Id = Convert.ToBase64String(bytes).Replace('+', '=');

            var now = DateTime.UtcNow;
            CreatedAtUtc = now;
            ExpiresAtUtc = now.AddDays(1);
        }
    }
}