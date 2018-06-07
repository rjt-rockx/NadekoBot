using SixLabors.Fonts;
using System.IO;

namespace NadekoBot.Core.Services.Impl
{
    public class FontProvider : INService
    {
        private readonly FontCollection _fonts;

        public FontProvider()
        {
            _fonts = new FontCollection();
            if (Directory.Exists("data/fonts"))
                foreach (var file in Directory.GetFiles("data/fonts"))
                {
                    _fonts.Install(file);
                }

            NotoSansBold = _fonts.Find("NotoSans-Bold");
            NotoSansBoldItalic = _fonts.Find("NotoSans-BoldItalic");
            NotoSansItalic = _fonts.Find("NotoSans-Italic");
            NotoSansRegular = _fonts.Find("NotoSans-Regular");

            UsernameFontFamily = _fonts.Find("Whitney-Bold");
            ClubFontFamily = _fonts.Find("Whitney-Bold");
            LevelFont = _fonts.Find("Whitney-Bold").CreateFont(45);
            XpFont = _fonts.Find("Whitney-Bold").CreateFont(50);
            AwardedFont = _fonts.Find("Whitney-Bold").CreateFont(25);
            RankFont = _fonts.Find("Uni Sans Thin CAPS").CreateFont(30);
            TimeFont = _fonts.Find("Whitney-Bold").CreateFont(20);
            RipNameFont = _fonts.Find("Whitney-Bold").CreateFont(20);
        }

        public Font NotoSansRegular { get; }
        public Font NotoSansItalic { get; }
        public Font NotoSansBold { get; }
        public Font NotoSansBoldItalic { get; }
        public Font LevelFont { get; }
        public Font XpFont { get; }
        public Font AwardedFont { get; }
        public Font RankFont { get; }
        public Font TimeFont { get; }
        public FontFamily UsernameFontFamily { get; }
        public FontFamily ClubFontFamily { get; }
        public Font RipNameFont { get; }
    }
}
