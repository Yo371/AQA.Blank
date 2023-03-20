using System.Reflection;

namespace AQA.Blank.Core.Utils;

public static class PathHelper
{
    private static string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    public static string GetAssemblyFile(string fileName) => Path.Combine(AssemblyLocation, fileName);

    public static void CreateAssemblyDir(string name) => Directory.CreateDirectory(GetAssemblyFile(name));
}