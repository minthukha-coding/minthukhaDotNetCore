using Microsoft.AspNetCore.SignalR;

namespace LemonDotNetCore.RealtimeChartAppUsingSignalR.Hubs
{
    public class TeamHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
