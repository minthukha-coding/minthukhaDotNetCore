using Microsoft.AspNetCore.SignalR;

namespace minthukhaDotNetCore.ChartAppUsingSignalR.Hubs;

public class ChatHub : Hub
{
    public async Task ServerReciveMessage(string user, string message)
    {
        await Clients.All.SendAsync("ClientReceiveMessage", user, message);
    }
}