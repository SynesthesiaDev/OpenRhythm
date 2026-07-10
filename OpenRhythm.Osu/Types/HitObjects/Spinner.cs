// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Osu.Types.HitObjects;

public record Spinner(
    int X,
    int Y,
    int StartTime,
    int HitSound,
    int EndTime,
    HitSamples HitSamples

) : HitObject()
{
}
