using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    [Authorize(Roles = "User")]
    public class MessageHub : Hub
    {
        public async Task MessageAll(string message)
        {
            await Clients.All.SendAsync("MessageAll", message);
        }
    }
}
