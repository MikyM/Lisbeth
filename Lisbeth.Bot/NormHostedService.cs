using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Bot
{
    public class NormHostedService : IHostedService
    {
        private readonly BotService _discordBot;
        public NormHostedService(BotService bot)
        {
            this._discordBot = bot;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this._discordBot.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await this._discordBot.StopAsync();
        }
    }
}
