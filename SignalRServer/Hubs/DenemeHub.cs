using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class DenemeHub : Hub
    {
        public async Task Hello()
        {
            await Clients.All.SendAsync("Hello", "Hello....");
        }

        public async Task Name(String name)
        {
            await Clients.All.SendAsync("Name", $"Hello {name}");
        }

    }
}
