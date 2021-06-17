﻿using Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public class QAHub : Hub
    {
        public async Task sendQuestions(string content, string date)
        {
            var question = new Question
            {
                Content = content,
            };

            await Clients.All.SendAsync("ReceiveQuestion", 
                question.Content,
                date
                );
        }

    }
}
