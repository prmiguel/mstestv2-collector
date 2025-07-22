namespace MSTestV2.Collector.Test;

[TestClass]
public class TestClassWithMultipleTestMethods
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public void TestMethod4()
    {
        Assert.IsTrue(true);
    }
}