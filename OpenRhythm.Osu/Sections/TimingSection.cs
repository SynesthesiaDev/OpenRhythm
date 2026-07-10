// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using OpenRhythm.Common.Extensions;
using OpenRhythm.Osu.Types;

namespace OpenRhythm.Osu.Sections;

public record TimingSection(List<TimingPoint> TimingPoints)
{
    public override string ToString() => $"{GetType().Name} {{ TimingPoints = {TimingPoints.ToListString()} }}";

    public static TimingSection Parse(string sectionText)
    {
        var lines = sectionText.Split("\n").Select(s => s.Trim()).ToList();
        var points = new List<TimingPoint>();

        foreach (var line in lines.Select(l => l.Trim()).ToList())
        {
            if (string.IsNullOrEmpty(line) || (line.StartsWith("[") && line.EndsWith("]")) || line.StartsWith("//") || line.StartsWith("_"))
            {
                continue;
            }

            points.Add(TimingPoint.Parse(line));
        }

        return new TimingSection(points);
    }
}
