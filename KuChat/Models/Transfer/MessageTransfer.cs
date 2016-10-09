using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KuChat.Extensions;

namespace KuChat.Models.Transfer
{
    public class MessageTransfer
    {
        public string Id { get; }
        public string ContentPreview { get; }
        public ContentTransfer Content { get; }
        public DateTime CreatedAt { get; }

        public MessageTransfer(Message msg)
        {
            Id = msg.Id;
            ContentPreview = msg.ContentPreview;
            Content = msg.Content.ToTransfer();
            CreatedAt = msg.CreatedAtUtc;
        }
    }
}