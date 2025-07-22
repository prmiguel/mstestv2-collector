namespace MSTestV2.Collector.Test;

[TestClass]
public class TestMethodWithSingleTestCategory
{
    [TestMethod]
    [TestCategory("Smoke")]
    public void TestMethod()
    {
        Assert.IsTrue(true);
    }
}