using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KuChat.Models
{
    public abstract class Content
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [InverseProperty(nameof(Models.Message.Content))]
        public virtual Message Message { get; set; }
        public abstract ContentType Type { get; }

        public abstract string GetPreview();
    }

    public enum ContentType
    {
        Text = 0,
        Image = 1,
        File = 2
    }
}