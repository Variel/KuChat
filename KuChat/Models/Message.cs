using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KuChat.Models
{
    public class Message
    {
        [Key, MaxLength(32)]
        public string Id { get; set; }

        [InverseProperty(nameof(Models.Content.Message))]
        [ForeignKey(nameof(ContentId))]
        public virtual Content Content { get; set; }
        public Guid ContentId { get; set; }
        public string ContentPreview { get; set; }
    }
}