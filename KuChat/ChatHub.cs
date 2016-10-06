using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KuChat.Models;
using Microsoft.AspNet.SignalR;

namespace KuChat
{
    public class ChatHub : Hub
    {
        DatabaseContext db = new DatabaseContext();

        public async Task SendMessage(Guid channelId, string message)
        {
            var connection = await db.Connections.FindAsync(Context.ConnectionId);
            var account = connection.Account;
            var channel = await db.Channels.FindAsync(channelId);

            if (account.Channels.Contains(channel))
            {
                var channelConnections = channel.Accounts.SelectMany(a => a.Connections).Select(c => c.Id).ToList();

                Clients.Clients(channelConnections).newMessage(channelId, account.ToTransfer(), message);
            }
        }

        public override async Task OnConnected()
        {
            var session =
                await
                    db.Sessions.FindAsync(Context.RequestCookies.ContainsKey("kc_sid")
                        ? Context.RequestCookies["kc_sid"].Value
                        : null);
            var account = session?.Account;

            if (account == null)
                throw new Exception("로그인이 필요합니다");

            var connection = new Connection(Context.ConnectionId, account);

            db.Connections.Add(connection);
            await db.SaveChangesAsync();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            var connection = await db.Connections.FindAsync(Context.ConnectionId);

            if (connection == null)
                return;

            db.Connections.Remove(connection);
            await db.SaveChangesAsync();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}