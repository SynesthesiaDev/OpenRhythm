// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Osu.Sections;

/// <param name="Title">Romanised song title</param>
/// <param name="TitleUnicode">Song title</param>
/// <param name="Artist">Romanised song artist</param>
/// <param name="ArtistUnicode">Song artist</param>
/// <param name="Creator">Beatmap creator</param>
/// <param name="Version">Difficulty name</param>
/// <param name="Source">Original media the song was produced for</param>
/// <param name="Tags">Search terms</param>
/// <param name="BeatmapId">Difficulty ID</param>
/// <param name="BeatmapSetId">Beatmap ID</param>
public record MetadataSection(
    string Title,
    string TitleUnicode,
    string Artist,
    string ArtistUnicode,
    string Creator,
    string Version,
    string Source,
    string[] Tags,
    int BeatmapId,
    int BeatmapSetId
)
{
    public static MetadataSection Parse(string sectionText)
    {
        var parser = new OsuSection(sectionText);
        return new MetadataSection
        (
            parser.GetOrDefault("Title", string.Empty),
            parser.GetOrDefault("TitleUnicode", string.Empty),
            parser.GetOrDefault("Artist", string.Empty),
            parser.GetOrDefault("ArtistUnicode", string.Empty),
            parser.GetOrDefault("Creator", string.Empty),
            parser.GetOrDefault("Version", string.Empty),
            parser.GetOrDefault("Source", string.Empty),
            parser.GetOrDefault<string[]>("Source", []),
            parser.GetOrDefault("BeatmapID", 0),
            parser.GetOrDefault("BeatmapSetID", 0)
        );
    }
}
