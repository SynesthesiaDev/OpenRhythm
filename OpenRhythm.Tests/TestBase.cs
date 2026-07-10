using NUnit.Framework;
using Serilog;

namespace OpenRhythm.Tests;

public abstract class TestBase
{
    [SetUp]
    public void BaseSetup()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.TextWriter(TestContext.Out)
            .CreateLogger();
    }
    
}