namespace MSTestV2.Collector.Test;

[TestClass]
public class TestMethodWithPriority
{
    [TestMethod]
    [TestCategory("Smoke")]
    [Priority(1)]
    public void TestMethod()
    {
        Assert.IsTrue(true);
    }
}