using Core.Entities;
using Core.Interfaces;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class ETourLogger : IETourLogger
    {
        private readonly IHubContext<LogHub> _hubContext;
        private readonly ILogRepository _logRepository;

        public ETourLogger(ILogRepository logRepository, IHubContext<LogHub> hubContext)
        {
            _logRepository = logRepository;
            _hubContext = hubContext;
        }

        public async Task LogAsync(Log.LogType type, string content)
        {
            var log = new Log
            {
                Type = type,
                Content = content,
                LastUpdated = DateTime.Now
            };
            await _logRepository.AddAsync(log);
            
            await _hubContext.Clients.Group(log.Type.ToString()).SendAsync("ReceiveLog",
                log.LastUpdated.ToString(),
                log.Type.ToString(),
                log.Content);

            await _hubContext.Clients.Group("All").SendAsync("ReceiveLog",
                log.LastUpdated.ToString(),
                log.Type.ToString(),
                log.Content);
        }
    }
}
