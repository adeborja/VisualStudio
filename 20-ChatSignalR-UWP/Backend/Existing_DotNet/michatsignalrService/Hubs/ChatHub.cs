using michatsignalrService.DataObjects;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace michatsignalrService.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(ChatMessage message)
        {
            Clients.All.broadcastMessage(message);

            Clients.All.pintarCuadro();
        }
    }
}