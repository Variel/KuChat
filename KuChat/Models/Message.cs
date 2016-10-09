using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace KuChat.Models
{
    public class Message
    {
        [Key, MaxLength(32)]
        public string Id { get; set; } = Crypto.SHA256(Guid.NewGuid().ToString());

        [InverseProperty(nameof(Models.Content.Message))]
        [ForeignKey(nameof(ContentId))]
        public virtual Content Content { get; set; }
        public Guid ContentId { get; set; }
        public string ContentPreview { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public Message() { }
        public Message(Content content)
        {
            this.Content = content;
            this.ContentPreview = content.GetPreview();
        }
    }
}