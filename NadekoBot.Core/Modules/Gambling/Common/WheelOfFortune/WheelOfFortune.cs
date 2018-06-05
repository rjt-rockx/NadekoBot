using System.Collections.Immutable;
using NadekoBot.Common;

namespace NadekoBot.Modules.Gambling.Common.WheelOfFortune
{
    public class WheelOfFortune
    {
        private static readonly NadekoRandom _rng = new NadekoRandom();

        private static readonly ImmutableArray<string> _emojis = new string[] {
            "⬆",
            "↖",
            "⬅",
            "↙",
            "⬇",
            "↘",
            "➡",
            "↗" }.ToImmutableArray();

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

        public int Result { get; }
        public string Emoji => _emojis[Result];
        public float Multiplier => Multipliers[Result];

        public WheelOfFortune()
        {
            this.Result = _rng.Next(0, 8);
        }
    }
}
