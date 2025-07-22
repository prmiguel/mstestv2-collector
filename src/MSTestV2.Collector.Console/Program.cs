using System.Diagnostics;
using System.Reflection;
using MSTestV2.Collector.Console;
using MSTestV2.Collector.Console.Splunk;
using MSTestV2.Collector.Console.Utils;

var traceSource = SplunkTestClient.Initialize();
var assembly = Assembly.LoadFile("MSTestV2.Collector.Test.dll");
var testClasses = TestUtils.GetTestClasses(assembly);

foreach (var testClass in testClasses)
{
    var testMethods = TestUtils.GetTestMethods(testClass);
    foreach (var testMethod in testMethods)
    {
        TestCase testCase = new TestCase
        {
            Name = testMethod.Name,
            Description = TestUtils.GetDescription(testMethod),
            Categories = TestUtils.GetCategories(testMethod),
            IsIgnored = TestUtils.GetIsIgnored(testMethod),
            Priority = TestUtils.GetPriority(testMethod)
        };
        TestCaseRepository.Repository.Add(testCase);
    }
}

TestSummary summary = new TestSummary(TestCaseRepository.Repository);
Console.WriteLine(summary.TotalTests);

traceSource.TraceData(TraceEventType.Information, 1, 
    new
    {
        total = summary.TotalTests
    }
);
Thread.Sleep(10000);
