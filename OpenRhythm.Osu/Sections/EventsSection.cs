// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.


using OpenRhythm.Common.Extensions;
using OpenRhythm.Osu.Types.Events;

namespace OpenRhythm.Osu.Sections;

public record EventsSection(List<OsuEvent> Events)
{
    public static EventsSection Parse(string sectionText)
    {
        var events = new List<OsuEvent>();
        var lines = sectionText.Split("\n").Select(s => s.Trim()).ToList();

        foreach (var line in lines.Select(l => l.Trim()).ToList())
        {
            if (string.IsNullOrEmpty(line) || (line.StartsWith("[") && line.EndsWith("]")) || line.StartsWith("//") || line.StartsWith("_"))
            {
                continue;
            }

            var split = line.Split(",");
            if (split.Length == 0) continue;

            var eventType = split[0].Trim();
            try
            {
                OsuEvent? parsedEvent = eventType switch
                {
                    "0" => BackgroundEvent.Parse(split),
                    "Video" or "1" => VideoEvent.Parse(split),
                    "2" or "Break" => BreakEvent.Parse(split),
                    //TODO Storyboard stuff
                    _ => null
                };

                if (parsedEvent != null)
                {
                    events.Add(parsedEvent);
                }
            }
            catch (Exception)
            {
                //ignore
            }
        }

        return new EventsSection(events);
    }

    public override string ToString() => $"{this.GetType().Name} {{ Events = {Events.ToListString()} }}";
}
