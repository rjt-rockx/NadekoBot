﻿using System.Collections.Immutable;
using System.Threading.Tasks;
using NadekoBot.Common;
using NadekoBot.Core.Services;

namespace NadekoBot.Modules.Gambling.Common.WheelOfFortune
{
    public class WheelOfFortuneGame
    {
        public class Result
        {
            public int Index { get; set; }
            public long Amount { get; set; }
        }

        public static readonly ImmutableArray<float> Multipliers = new float[] {
            1.48f,
            0.97f,
            0.66f,
            0.11f,
            0.35f, 
            0.73f,
            1.23f,
            2.25f
        }.ToImmutableArray();

        private readonly NadekoRandom _rng;
        private readonly ICurrencyService _cs;
        private readonly long _bet;
        private readonly ulong _userId;

        public WheelOfFortuneGame(ulong userId, long bet, ICurrencyService cs)
        {
            _rng = new NadekoRandom();
            _cs = cs;
            _bet = bet;
            _userId = userId;
        }

        public async Task<Result> SpinAsync()
        {
            var result = _rng.Next(0, Multipliers.Length);

            var amount = (long)(_bet * Multipliers[result]);

            if (amount > 0)
                await _cs.AddAsync(_userId, "Wheel Of Fortune - won", amount, gamble: true).ConfigureAwait(false);

            return new Result
            {
                Index = result,
                Amount = amount,
            };
        }
    }
}
