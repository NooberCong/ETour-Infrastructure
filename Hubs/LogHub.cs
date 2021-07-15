using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    [Authorize(Roles = "Admin")]
    public class LogHub : Hub
    {
        public static readonly string PATH = "/logs";
        public async Task Subscribe(string TypeOrdinal)
        {
            Log.LogType? type;

            if (int.TryParse(TypeOrdinal, out int ordinal) && (type = (Log.LogType?) ordinal) != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, type.ToString());
            } else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "All");
            }
        }
    }
}
