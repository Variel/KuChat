using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KuChat.Models;
using KuChat.Models.Transfer;

namespace KuChat.Extensions
{
    public static class ChannelTransferExtensions
    {
        public static ChannelTransfer ToTransfer(this Channel ch) => new ChannelTransfer(ch);

        public static IEnumerable<ChannelTransfer> ToTransfer(this IEnumerable<Channel> ch) => ch.Select(c => new ChannelTransfer(c));
    }
}