using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KuChat.Models.Transfer
{
    public class ChannelTransfer
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }
        public int ParticipantsCount { get; }

        public ChannelTransfer(Channel ch)
        {
            Id = ch.Id;
            Name = ch.Name;
            Description = ch.Description;
            CreatedAt = ch.CreatedAtUtc;
            ParticipantsCount = ch.Accounts.Count;
        }
    }
}