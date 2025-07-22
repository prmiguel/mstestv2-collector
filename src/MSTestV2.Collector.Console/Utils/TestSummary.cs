namespace MSTestV2.Collector.Console.Utils;

public class TestSummary
{
    public int TotalTests { get; private set; }
    
    public TestSummary(List<TestCase> testCases)
    {
        TotalTests = testCases.Count;
    }
}