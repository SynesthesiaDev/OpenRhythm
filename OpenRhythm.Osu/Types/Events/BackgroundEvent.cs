// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Osu.Types.Events;

/// <param name="FileName">Location of the background image relative to the beatmap directory.</param>
/// <param name="OffsetX">X offset in osu! pixels from the centre of the screen</param>
/// <param name="OffsetY">Y offset in osu! pixels from the centre of the screen</param>
public record BackgroundEvent(string FileName, int OffsetX, int OffsetY) : OsuEvent(Event.Background, 0)
{
    public static BackgroundEvent Parse(string[] args)
    {
        var filename = args[2].Trim('"');
        var xOffset = args.Length > 3 ? int.Parse(args[3]) : 0;
        var yOffset = args.Length > 4 ? int.Parse(args[4]) : 0;

        return new BackgroundEvent(filename, xOffset, yOffset);
    }
}
