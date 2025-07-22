using System.Reflection;

namespace MSTestV2.Collector.Console;

public class TestUtils
{
    public static List<string?> GetCategories(MethodInfo testMethodInfo)
    {
        List<string?> categories = new List<string?>();
        var testCategories = testMethodInfo.CustomAttributes
            .Where(attribute => attribute.AttributeType.Name == "TestCategoryAttribute");
        foreach (var testMethodCustomAttribute in testCategories)
        {
            foreach (var arguments in testMethodCustomAttribute.ConstructorArguments)
            {
                categories.Add(arguments.Value?.ToString());
            }
        }

        return categories;
    }

    public static List<Type> GetTestClasses(Assembly testAssembly)
    {
        return testAssembly.GetTypes()
            .Where(clazz => clazz.CustomAttributes
                .Any(attribute => attribute.AttributeType.Name == "TestClassAttribute")).ToList();
    }
    
    public static List<MethodInfo> GetTestMethods(Type testClass)
    {
        return testClass.GetMethods()
            .Where(method =>
                method.CustomAttributes.Any(attribute => attribute.AttributeType.Name == "TestMethodAttribute"))
            .ToList();
    }
    public static string GetDescription(MethodInfo testMethodInfo)
    {
        var testDescription = testMethodInfo.CustomAttributes
            .Where(attribute => attribute.AttributeType.Name == "DescriptionAttribute");
        if (!testDescription.Any()) return "";
        return testDescription.First().ConstructorArguments[0].Value.ToString();
    }
    
    public static bool GetIsIgnored(MethodInfo testMethodInfo)
    {
        return testMethodInfo.CustomAttributes
            .Any(attribute => attribute.AttributeType.Name == "IgnoreAttribute");
    }
    
    public static int GetPriority(MethodInfo testMethodInfo)
    {
        var priority = testMethodInfo.CustomAttributes
            .Where(attribute => attribute.AttributeType.Name == "PriorityAttribute");
        if (!priority.Any()) return -1;
        return (int) priority.First().ConstructorArguments[0].Value;
    }
}