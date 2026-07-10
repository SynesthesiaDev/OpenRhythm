// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Synesthesia.Utils.Extensions;

namespace OpenRhythm.Osu.Types;

/// <summary>
/// Each timing point influences a specified portion of the map, commonly called a "timing section".
/// </summary>
/// <param name="Time">Start time of the timing section, in milliseconds from the beginning of the beatmap's audio. The end of the timing section is the next timing point's time (or never, if this is the last timing point).</param>
/// <param name="BeatLength">
/// This property has two meanings:
/// For uninherited timing points, the duration of a beat, in milliseconds.
/// For inherited timing points, a negative inverse slider velocity multiplier, as a percentage. For example, -50 would make all sliders in this timing section twice as fast as SliderMultiplier.
/// </param>
/// <param name="Meter">Amount of beats in a measure. Inherited timing points ignore this property.</param>
/// <param name="SampleSet">Default sample set for hit objects (0 = beatmap default, 1 = normal, 2 = soft, 3 = drum).</param>
/// <param name="SampleIndex">Custom sample index for hit objects. 0 indicates osu!'s default hitsounds.</param>
/// <param name="Volume">Volume percentage for hit objects.</param>
/// <param name="Uninherited">Whether or not the timing point is uninherited.</param>
/// <param name="Effects">Bit flags that give the timing point extra effects. See the effects section.</param>
/// <param name="IsKiai">A set of distinctive visual effects emphasising a part of a beatmap</param>
/// <param name="OmitBarline">Whether or not the first barline is omitted in osu!taiko and osu!mania</param>
public record TimingPoint(
    double Time,
    double BeatLength,
    int Meter,
    int SampleSet,
    int SampleIndex,
    int Volume,
    bool Uninherited,
    int Effects,
    bool IsKiai,
    bool OmitBarline
)
{
    public static TimingPoint Parse(string timingLine)
    {
        var split = timingLine.Split(",");

        var effects = int.Parse(split[7]);
        TimingEffects timingEffects = (TimingEffects)effects;
        bool isKiai = timingEffects.HasFlagFast(TimingEffects.KiaiEnabled);
        bool omitBarline = timingEffects.HasFlagFast(TimingEffects.OmitFirstBarLine);

        return new TimingPoint
        (
            double.Parse(split[0]),
            double.Parse(split[1]),
            int.Parse(split[2]),
            int.Parse(split[3]),
            int.Parse(split[4]),
            int.Parse(split[5]),
            split[6].ToInt().ToBoolean(),
            effects,
            isKiai,
            omitBarline
        );
    }
}
