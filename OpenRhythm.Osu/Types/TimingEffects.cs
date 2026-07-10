// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Osu.Types;

[Flags]
public enum TimingEffects
{
    None = 0,
    KiaiEnabled = 1 << 0,
    OmitFirstBarLine = 1 << 3
}
