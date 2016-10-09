using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KuChat.Models;
using KuChat.Models.Transfer;

namespace KuChat.Extensions
{
    public static class MessageTransferExtensions
    {
        public static MessageTransfer ToTransfer(this Message msg) => new MessageTransfer(msg);

        public static IEnumerable<MessageTransfer> ToTransfer(this IEnumerable<Message> source)
            => source.Select(m => new MessageTransfer(m));
    }
}