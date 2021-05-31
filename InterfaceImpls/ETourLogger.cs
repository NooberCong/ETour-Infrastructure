using Core.Entities;
using Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class ETourLogger : IETourLogger
    {
        private readonly ILogRepository _logRepository;

        public ETourLogger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task LogAsync(Log.LogType type, string content)
        {
            await _logRepository.AddAsync(new Log
            {
                Type = type,
                Content = content,
                LastUpdated = DateTime.Now
            });
        }
    }
}
