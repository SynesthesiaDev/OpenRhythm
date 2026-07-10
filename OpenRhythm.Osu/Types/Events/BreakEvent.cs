// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Osu.Types.Events;

/// <param name="StartTime">Start time of the break, in milliseconds from the beginning of the beatmap's audio.</param>
/// <param name="EndTime">End time of the break, in milliseconds from the beginning of the beatmap's audio.</param>
public record BreakEvent(int StartTime, int EndTime) : OsuEvent(Event.Break, StartTime)
{
    public static BreakEvent Parse(string[] args)
    {
        var startTime = int.Parse(args[1]);
        var endTime = int.Parse(args[2]);

        return new BreakEvent(startTime, endTime);
    }
}
