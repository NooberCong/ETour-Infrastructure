using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    [AllowAnonymous]
    public class QAHub : Hub
    {
        public async Task sendQuestions(string content)
        {
            var question = new Question
            {
                Content = content,
            };

            await Clients.All.SendAsync("ReceiveQuestion", 
                question.Content);
        }

    }
}
