using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Bot
{
    public class TestCommandModule : BaseCommandModule
    {
        public Random Rng { private get; set; }

        [Command("hi")]
        public async Task Hi(CommandContext ctx, int min, int max)
        {
            await ctx.RespondAsync($"I'm fukin alive, {Rng.Next(min, max)}");
        }
    }
}
