using System.Reflection;
using System.Runtime.CompilerServices;
using OpenRhythm.Common.Extensions;

namespace OpenRhythm.Tests;

public class AssemblyResourceProvider(Assembly assembly)
{
    public string[] AvailableResources => assembly.GetManifestResourceNames();

    public static AssemblyResourceProvider For<T>()
    {
        var assembly = typeof(T).Assembly;
        return new AssemblyResourceProvider(assembly);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AssemblyResourceProvider This()
    {
        var assembly = Assembly.GetCallingAssembly();
        return new AssemblyResourceProvider(assembly);
    }

    public byte[] Get(string name) => !AvailableResources.Contains(name) ? throw new KeyNotFoundException() : assembly.GetManifestResourceStream(name)!.ToByteArray();
}
