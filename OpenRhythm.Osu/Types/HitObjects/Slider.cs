// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Numerics;
using OpenRhythm.Common.Exceptions;
using Synesthesia.Utils.Extensions;

namespace OpenRhythm.Osu.Types.HitObjects;

public record Slider(
    int X,
    int Y,
    int StartTime,
    int HitSound,
    CurveType CurveType,
    List<Vector2> CurvePoints,
    int Slides,
    double Length,
    List<int> EdgeSounds,
    List<string> EdgeSets,
    HitSamples HitSamples
) : HitObject(X, Y, StartTime, HitObjectType.Slider, HitSound, HitSamples)
{
    public static Slider Parse(string line)
    {
        var split = line.Split(",");
        DecodingError.Assert(split.Length < 10, "invalid slider format");

        var hitSamples = split.Length >= 11 ? HitSamples.Parse(split[10]) : HitSamples.DEFAULT;

        var hitSound = split[3].ToInt();

        var curveSplit = split[4].Split("|");
        var curveType = curveSplit[0] switch
        {
            "B" => CurveType.Bezier,
            "C" => CurveType.Catmull,
            "L" => CurveType.Linear,
            "P" => CurveType.PerfectCircle,
            _ => throw new ArgumentOutOfRangeException()
        };

        var curvePoints = curveSplit.Skip(1)
            .Select(pointStr => pointStr.Split(":"))
            .Select(pointSplit => new Vector2(pointSplit[0].ToInt(), pointSplit[1].ToInt()))
            .ToList();

        var edgeSounds = split[6].Split("|").Select(res => res.ToInt()).ToList();
        var edgeSets = split[7].Split("|").ToList();

        return new Slider
        (
            split[0].ToInt(),
            split[1].ToInt(),
            split[2].ToInt(),
            hitSound,
            curveType,
            curvePoints,
            split[5].ToInt(),
            double.Parse(split[8]),
            edgeSounds,
            edgeSets,
            hitSamples
        );
    }
}
