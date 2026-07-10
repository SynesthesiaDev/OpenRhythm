using OpenRhythm.Osu.Sections;
using OpenRhythm.Osu.Tests;
using OpenRhythm.Tests;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SpectreConsole;

namespace OpenRhythm.Playground;

internal class Playground
{
    private static readonly AssemblyResourceProvider osu_resources = AssemblyResourceProvider.For<OsuDecodeTest>();

    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.SpectreConsole(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u4}] {Message:lj}{NewLine}{Exception}", minLevel: LogEventLevel.Verbose)
            .CreateLogger();

        var beatmap = osu_resources.Get("OpenRhythm.Osu.Tests.Resources.1373606 sokoninaru - Hyouri Ittai.osz");

        var generalText = """
                          [General]
                          AudioFilename: audio.mp3
                          AudioLeadIn: 0
                          PreviewTime: 168099
                          Countdown: 0
                          SampleSet: Soft
                          StackLeniency: 0.7
                          Mode: 0
                          LetterboxInBreaks: 0
                          WidescreenStoryboard: 1

                          """;

        var editorText = """
                         [Editor]
                         Bookmarks: 1910,8310,14710,27510,40310,43510,56310,69110,81910,94710,101110,126710,139510,152310,153573,158625,163678,168731,188941,209152,214204,219257,221783,224309,226835,229362,230940
                         DistanceSpacing: 1
                         BeatDivisor: 4
                         GridSize: 16
                         TimelineZoom: 1.6
                         """;

        var metadataText = """
                           [Metadata]
                           Title:Hyouri Ittai
                           TitleUnicode:表裏一体
                           Artist:sokoninaru
                           ArtistUnicode:そこに鳴る
                           Creator:Some Hero
                           Version:Hard
                           Source:
                           Tags:FuJu ゼロ zero Japanese Rock j-rock jrock koga records
                           BeatmapID:2980121
                           BeatmapSetID:1373606
                           """;

        var difficultyText = """
                             [Difficulty]
                             HPDrainRate:5
                             CircleSize:3.7
                             OverallDifficulty:6.5
                             ApproachRate:7.5
                             SliderMultiplier:1.4
                             SliderTickRate:1
                             """;

        var eventsText = """
                     [Events]
                     //Background and Video events
                     0,0,"new bg.jpg",0,0
                     //Break Periods
                     2,78710,80485
                     2,139510,148285
                     2,158824,162853
                     2,216953,218432
                     //Storyboard Layer 0 (Background)
                     //Storyboard Layer 1 (Fail)
                     //Storyboard Layer 2 (Pass)
                     //Storyboard Layer 3 (Foreground)
                     //Storyboard Layer 4 (Overlay)
                     //Storyboard Sound Samples
                     """;

        var timingText = """
                         [TimingPoints]
                         1910,400,4,2,1,70,1,0
                         8310,-100,4,2,2,70,0,0
                         8510,-100,4,2,1,70,0,0
                         14710,-80,4,2,2,70,0,0
                         15110,-80,4,2,1,70,0,0
                         27510,-80,4,2,2,80,0,0
                         27910,-80,4,2,1,80,0,0
                         40310,-80,4,2,1,60,0,0
                         42110,-100,4,2,1,60,0,0
                         43810,-117.647058823529,4,2,1,60,0,0
                         56310,-100,4,2,1,60,0,0
                         75510,-125,4,2,2,60,0,0
                         81910,-133.333333333333,4,2,1,60,0,0
                         93910,-100,4,2,1,60,0,0
                         97910,-66.6666666666667,4,2,1,90,0,1
                         98710,-66.6666666666667,4,2,1,60,0,0
                         101110,-80,4,2,1,70,0,1
                         126710,-80,4,2,1,60,0,0
                         128310,-80,4,2,1,40,0,0
                         136310,-250,4,2,1,40,0,0
                         136510,-250,4,2,2,40,0,0
                         137910,-250,4,2,1,40,0,0
                         149110,-100,4,2,1,60,0,0
                         152310,315.789473684211,4,2,1,60,1,0
                         152941,-133.333333333333,4,2,1,60,0,0
                         153573,-100,4,2,1,60,0,0
                         163678,-100,4,2,1,65,0,0
                         166362,-100,4,2,1,70,0,1
                         168099,-100,4,2,1,65,0,0
                         168731,-80,4,2,1,75,0,1
                         175046,-80,4,2,2,75,0,1
                         175361,-80,4,2,1,75,0,1
                         186415,-80,4,2,1,75,0,0
                         188941,-80,4,2,1,85,0,1
                         209152,-80,4,2,1,65,0,0
                         209783,-100,4,2,1,65,0,0
                         214204,295.566502463054,4,2,1,60,1,0
                         214795,309.278350515464,4,2,1,60,1,0
                         215478,264.31718061674,4,2,1,60,1,0
                         216051,309.278350515464,4,2,1,60,1,0
                         216753,259.74025974026,4,2,1,60,1,0
                         217319,315.789473684211,4,2,1,60,1,0
                         217950,315.789473684211,4,2,1,60,1,0
                         219257,315.789473684211,4,2,1,90,1,0
                         219414,-100,4,2,1,80,0,1
                         221783,-100,4,2,1,60,0,0
                         224309,-125,4,2,2,60,0,0
                         226835,-125,4,2,1,60,0,0
                         229361,-125,4,2,1,70,0,0
                         229362,315.789473684211,5,2,1,70,1,0
                         230940,-100,5,2,1,70,0,1
                         235046,-100,5,2,1,75,0,1
                         235677,-100,5,2,1,80,0,1
                         236151,-100,5,2,1,82,0,1
                         236388,-100,5,2,1,86,0,1
                         236625,-100,5,2,1,90,0,1
                         236783,-100,5,2,1,5,0,0
                         """;

        var colorsText = """
                     [Colours]
                     Combo1 : 96,166,166
                     Combo2 : 71,104,181
                     Combo3 : 204,84,118
                     Combo4 : 143,141,224
                     """;

        var general = GeneralSection.Parse(generalText);
        var editor = EditorSection.Parse(editorText);
        var metadata = MetadataSection.Parse(metadataText);
        var difficulty = DifficultySection.Parse(difficultyText);
        var events = EventsSection.Parse(eventsText);
        var timings = TimingSection.Parse(timingText);
        var colors = ColoursSection.Parse(colorsText);

        Log.Information(general.ToString());
        Log.Information(editor.ToString());
        Log.Information(metadata.ToString());
        Log.Information(difficulty.ToString());
        Log.Information(events.ToString());
        Log.Information(timings.ToString());
        Log.Information(colors.ToString());
    }
}
