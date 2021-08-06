using System.Threading;
using System.Threading.Tasks;
using Bot;
using Microsoft.Extensions.Hosting;

namespace Bot
{
    public class BotHostedService : IHostedService
    {
        private readonly BotService _discordBot;
        public BotHostedService(BotService bot)
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