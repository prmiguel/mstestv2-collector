namespace MSTestV2.Collector.Test;

[TestClass]
public class TestMethodWithIgnore
{
    [TestMethod]
    [TestCategory("Smoke")]
    [Ignore]
    public void TestMethod()
    {
        Assert.IsTrue(true);
    }
}