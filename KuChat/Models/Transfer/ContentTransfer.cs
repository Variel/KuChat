using System;

namespace KuChat.Models.Transfer
{
    public abstract class ContentTransfer
    {
        public Guid Id { get; }
        public ContentType Type { get; }

        protected ContentTransfer(Content content)
        {
            this.Id = content.Id;
            this.Type = content.Type;
        }
    }
}