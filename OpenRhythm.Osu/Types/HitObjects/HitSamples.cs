// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using OpenRhythm.Common.Exceptions;

namespace OpenRhythm.Osu.Types.HitObjects;

public record HitSamples(int NormalSet, int AdditionSet, int Index, int Volume, string? FileName)
{
    public static readonly HitSamples DEFAULT = new HitSamples(0, 0, 0, 0, null);

    public static HitSamples Parse(string chunk)
    {
        var split = chunk.Split(":");
        DecodingError.Assert(split.Length >= 4, "Hit sample format is missing required parameters");

        string? filename = split.Length > 4 && !string.IsNullOrEmpty(split[4])
            ? split[4]
            : null;

        return new HitSamples
        (
            int.Parse(split[0]),
            int.Parse(split[1]),
            int.Parse(split[2]),
            int.Parse(split[3]),
            filename
        );
    }
}
