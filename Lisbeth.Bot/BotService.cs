using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Bot
{
    public class BotService
    {
        public DiscordShardedClient Client { get; }
        private readonly CommandsNextConfiguration commandsConfig;
        private readonly InteractivityConfiguration interactivityConfig;
        private IReadOnlyDictionary<int, CommandsNextExtension> commands;
#pragma warning disable IDE0052 // Remove unread private members
        private IReadOnlyDictionary<int, InteractivityExtension> interactivity;
#pragma warning restore IDE0052 // Remove unread private members
        private readonly IServiceProvider _sp;

        public BotService(IServiceProvider services)
        {
            _sp = services;

            var pr = services.GetService<Random>();

            DiscordConfiguration ClientConfig = new DiscordConfiguration
            {
                Token = "ODU0MzI5OTE5NTU0NDUzNTE0.YMiWvQ.t2ubmyiYOlMmGvXcYEoTvL8Bm6M",
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Information,
                // LoggerFactory = loggerFactory,
                Intents = DiscordIntents.All,
                AutoReconnect = true,
            };

            this.commandsConfig = new CommandsNextConfiguration
            {
                //Services = services,
                EnableDms = true,
                EnableMentionPrefix = true,
                StringPrefixes = new List<string>{"!"},
                Services = services
            };

            this.interactivityConfig = new InteractivityConfiguration
            {
                PaginationBehaviour = PaginationBehaviour.Ignore,
                Timeout = TimeSpan.FromMinutes(2),
            };

            this.Client = new DiscordShardedClient(ClientConfig);
        }

        public async Task StartAsync()
        {
            this.commands = await this.Client.UseCommandsNextAsync(this.commandsConfig);
            this.interactivity = await this.Client.UseInteractivityAsync(this.interactivityConfig);
            this.Client.Ready += this.UpdateDiscordStatus;

            foreach (KeyValuePair<int, CommandsNextExtension> pair in this.commands)
            {
                pair.Value.RegisterCommands<TestCommandModule>();

                await this.Client.StartAsync();
            }
        }

        public async Task StopAsync()
        {
            await this.Client.StopAsync();
        }

        private async Task UpdateDiscordStatus(DiscordClient sender, ReadyEventArgs e)
        {
            await this.Client.UpdateStatusAsync(new DiscordActivity("all the users in anticipation", ActivityType.Watching));
            Debug.WriteLine("Alive");
        }
    }
}
