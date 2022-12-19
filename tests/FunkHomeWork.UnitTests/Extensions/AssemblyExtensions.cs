using System.Reflection;

namespace FunkHomeWork.UnitTests.Extensions;

public static class AssemblyExtensions
{
    public static MethodInfo? GetExtensionMethods(this Assembly assembly, string extensionName)
    {
        var query = from type in assembly.GetTypes()
            where type.IsSealed && !type.IsGenericType && !type.IsNested
            from method in type.GetMethods(BindingFlags.Static
                                           | BindingFlags.Public
                                           | BindingFlags.NonPublic)
            where method.Name == extensionName
            select method;

        return query.FirstOrDefault();
    }

    public static FieldInfo? GetFieldInfoByName(this Assembly assembly, string className, string fieldName)
    {
        return assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == className)
            ?.GetFields()
            .FirstOrDefault(m => m.Name == fieldName);
    }
}