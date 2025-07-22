namespace MSTestV2.Collector.Test;

[TestClass]
public class AnotherTest
{
    [TestMethod]
    [TestCategory("Smoke")]
    [Description("Test method with description")]
    public void TestMethod()
    {
        Assert.IsTrue(true);
    }
}
