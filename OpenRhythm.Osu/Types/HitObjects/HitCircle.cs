// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using OpenRhythm.Common.Exceptions;

namespace OpenRhythm.Osu.Types.HitObjects;

/// <param name="X">Position on the X coordinate in osu! pixels of the object.</param>
/// <param name="Y">Position on the Y coordinate in osu! pixels of the object.</param>
/// <param name="StartTime">Time when the object is to be hit, in milliseconds from the beginning of the beatmap's audio.</param>
/// <param name="HitSound">Bit flags indicating the hitsound applied to the object.</param>
/// <param name="HitSamples">Information about which samples are played when the object is hit.</param>
public record HitCircle(int X, int Y, int StartTime, int HitSound, HitSamples HitSamples) : HitObject(X, Y, StartTime, HitObjectType.HitCircle, HitSound, HitSamples)
{
    public static HitCircle Parse(string line)
    {
        var split = line.Split(",");
        DecodingError.Assert(split.Length < 5, "invalid hit circle format");

        var hitSamples = split.Length == 5 ? HitSamples.DEFAULT : HitSamples.Parse(split[5]);

        return new HitCircle
        (
            int.Parse(split[0]),
            int.Parse(split[1]),
            int.Parse(split[2]),
            int.Parse(split[4]),
            hitSamples
        );
    }
}
