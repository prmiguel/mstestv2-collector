namespace MSTestV2.Collector.Test;

[TestClass]
public class TestMethodWithMultipleTestCategories
{
    [TestMethod]
    [TestCategory("Smoke")]
    [TestCategory("E2E")]
    [TestCategory("Manual")]
    [TestCategory("Local")]
    public void TestMethod()
    {
        Assert.IsTrue(true);
    }
}