// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Osu.Sections;

/// <summary>
/// These options are only relevant when opening maps in the beatmap editor. They do not affect gameplay.
/// </summary>
/// <param name="Bookmarks">Time in milliseconds of bookmarks</param>
/// <param name="DistanceSpacing">Distance snap multiplier</param>
/// <param name="BeatDivisor">Beat snap divisor</param>
/// <param name="GridSize">Grid size</param>
/// <param name="TimelineZoom">Scale factor for the object timeline</param>
public record EditorSection(
    int[] Bookmarks,
    double DistanceSpacing,
    int BeatDivisor,
    int GridSize,
    double TimelineZoom
)
{
    public static EditorSection Parse(string sectionText)
    {
        var parser = new OsuSection(sectionText);
        return new EditorSection
        (
            parser.GetOrNull<int[]>("Bookmarks") ?? [],
            parser.GetOrDefault("DistanceSpacing", 1),
            parser.GetOrDefault("BeatDivisor", 4),
            parser.GetOrDefault("GridSize", 4),
            parser.GetOrDefault("TimelineZoom", 1.0)
        );
    }
}

