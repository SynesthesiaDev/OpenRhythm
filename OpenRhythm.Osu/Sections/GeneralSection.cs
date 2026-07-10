// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using OpenRhythm.Osu.Types;

namespace OpenRhythm.Osu.Sections;

/// <param name="AudioFileName">Location of the audio file relative to the current folder</param>
/// <param name="AudioLeanIn">Milliseconds of silence before the audio starts playing</param>
/// <param name="AudioHash">Deprecated</param>
/// <param name="PreviewTime">Time in milliseconds when the audio preview should start</param>
/// <param name="Countdown">Speed of the countdown before the first hit object (0 = no countdown, 1 = normal, 2 = half, 3 = double)</param>
/// <param name="SampleSet">Sample set that will be used if timing points do not override it (Normal, Soft, Drum)</param>
/// <param name="StackLeniency">Multiplier for the threshold in time where hit objects placed close together stack (0–1)</param>
/// <param name="Mode">Game mode (0 = osu!, 1 = osu!taiko, 2 = osu!catch, 3 = osu!mania)</param>
/// <param name="LetterboxInBreaks">Whether or not breaks have a letterboxing effect</param>
/// <param name="StoryFireInFront">Deprecated</param>
/// <param name="UseSkinSprites">Whether or not the storyboard can use the user's skin images</param>
/// <param name="AlwaysShowPlayfield">Deprecated</param>
/// <param name="OverlayPosition">Draw order of hit circle overlays compared to hit numbers (NoChange = use skin setting, Below = draw overlays under numbers, Above = draw overlays on top of numbers)</param>
/// <param name="SkinPreference">Preferred skin to use during gameplay</param>
/// <param name="EpilepsyWarning">Whether or not a warning about flashing colours should be shown at the beginning of the map</param>
/// <param name="CountdownOffset">Time in beats that the countdown starts before the first hit object</param>
/// <param name="SpecialStyle">Whether or not the "N+1" style key layout is used for osu!mania</param>
/// <param name="WidescreenStoryboard">Whether or not the storyboard allows widescreen viewing</param>
/// <param name="SamplesMatchPlaybackRate">Whether or not sound samples will change rate when playing with speed-changing mods</param>
public record GeneralSection(
    string AudioFileName,
    int AudioLeanIn,
    string? AudioHash,
    int PreviewTime,
    Countdown Countdown,
    string SampleSet,
    double StackLeniency,
    Mode Mode,
    bool LetterboxInBreaks,
    bool StoryFireInFront,
    bool UseSkinSprites,
    bool AlwaysShowPlayfield,
    OverlayPosition OverlayPosition,
    string? SkinPreference,
    bool EpilepsyWarning,
    int CountdownOffset,
    bool SpecialStyle,
    bool WidescreenStoryboard,
    bool SamplesMatchPlaybackRate
)
{
    public static GeneralSection Parse(string sectionText)
    {
        var parser = new OsuSection(sectionText);
        return new GeneralSection
        (
            parser.Get<string>("AudioFilename"),
            parser.GetOrDefault("AudioLeadIn", 0),
            parser.GetOrNull<string>("AudioHash"),
            parser.GetOrDefault("PreviewTime", -1),
            (Countdown?)parser.GetOrNull<int>("Countdown") ?? Countdown.Normal,
            parser.GetOrDefault("SampleSet", "Normal"),
            parser.GetOrDefault("StackLeniency", 0.7),
            (Mode?)parser.GetOrNull<int>("Mode") ?? Mode.Standard,
            parser.GetOrDefault("LetterboxInBreaks", false),
            parser.GetOrDefault("StoryFireInFront", true),
            parser.GetOrDefault("UseSkinSprites", false),
            parser.GetOrDefault("AlwaysShowPlayfield", false),
            (OverlayPosition?)parser.GetOrNull<int>("OverlayPosition") ?? OverlayPosition.NoChange,
            parser.GetOrNull<string>("SkinPreference"),
            parser.GetOrDefault("EpilepsyWarning", false),
            parser.GetOrDefault("CountdownOffset", 0),
            parser.GetOrDefault("SpecialStyle", false),
            parser.GetOrDefault("WidescreenStoryboard", false),
            parser.GetOrDefault("SamplesMatchesPlaybackRate", false)
        );
    }
}
