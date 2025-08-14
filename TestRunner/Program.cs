using System;
using System.Linq;
using System.Reflection;
using System.Text;
using TestFramework;

class TestRunner
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: TestRunner <path to assembly>");
            return;
        }

        string assemblyPath = args[0];
        Assembly assembly;

        try
        {
            assembly = Assembly.LoadFrom(assemblyPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading assembly: {ex.Message}");
            return;
        }

        var testMethods = assembly
            .GetTypes()
            .Where(type => type.IsClass && type.IsPublic)
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
            .Where(method => method.GetCustomAttributes()
                         .Any(attr => attr.GetType().Name == "TestAttribute"))
            .ToList();

        var testGroups = testMethods
            .GroupBy(method => method.DeclaringType)
            .ToList();

        var output = new StringBuilder();
        int totalPassed = 0;
        int totalFailed = 0;
        foreach (var group in testGroups)
        {
            var className = group.Key.Name;
            output.AppendLine($"{className}:");

            int classPassed = 0, classFailed = 0;

            foreach (var method in group)
            {
                try
                {
                    object instance = method.IsStatic ? null : Activator.CreateInstance(method.DeclaringType);
                    method.Invoke(instance, null);
                    output.AppendLine($"\t[PASS] {method.Name}");
                    classPassed++;
                }
                catch (TargetInvocationException tie)
                {
                    output.AppendLine($"\t[FAIL] {method.Name}");
                    output.AppendLine($"\t\t{tie.InnerException?.Message}");
                    classFailed++;
                }
                catch (Exception ex)
                {
                    output.AppendLine($"\t[FAIL] {method.Name}");
                    output.AppendLine($"\t\t{ex.Message}");
                    classFailed++;
                }
            }

            output.AppendLine($"  Class Summary: Passed: {classPassed}, Failed: {classFailed}\n");

            totalPassed += classPassed;
            totalFailed += classFailed;
        }

        output.AppendLine($"Total: {testMethods.Count}, Passed: {totalPassed}, Failed: {totalFailed}");
        
        string filePath = "TestResults.txt";
        Console.WriteLine(output.ToString());
        File.WriteAllText(filePath, output.ToString());
        Console.WriteLine($"Test results written to {filePath}");
    }
}