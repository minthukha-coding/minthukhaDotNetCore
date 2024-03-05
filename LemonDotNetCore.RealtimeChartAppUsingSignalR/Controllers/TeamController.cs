using LemonDotNetCore.RealtimeChartAppUsingSignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LemonDotNetCore.RealtimeChartAppUsingSignalR.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHubContext<TeamHub> _hubContext;

        public TeamController(AppDbContext appDbContext, IHubContext<TeamHub> hubContext)
        {
            _appDbContext = appDbContext;
            _hubContext = hubContext;
        }

        [ActionName("Index")]
        public IActionResult TeamIndex()
        {
            return View("TeamIndex");
        }

        [ActionName("Create")]
        public IActionResult TeamCreate()
        {
            return View("TeamCreate");
        }

        [ActionName("TeamSave")]
        public async Task<IActionResult> TeamSave(TeamDataModel model)
        {
            await _appDbContext.AddAsync(model);
            await _appDbContext.SaveChangesAsync();

            var lst = await _appDbContext.Teams
                .AsNoTracking()
                .ToListAsync();
            string json = JsonSerializer.Serialize(lst);
            await _hubContext.Clients.All.SendAsync("ReceiveTeamClientEvent", json);
            return Redirect("/Team/Create");
        }
    }
}