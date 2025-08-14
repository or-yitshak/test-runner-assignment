using TestFramework;

public class MathTests
{
    [Test] // Our custom attribute from TestRunner
    public void Add_ShouldReturnSum()
    {
        Assert.AreEqual(4, 2 + 2);
    }

    [Test]
    public void ThisWillFail()
    {
        Assert.IsTrue(1 > 5, "5 is bigger than 1");
    }

    [Test]
    public void DivisionByZero()
    {
        int x = 0;
        x = 5/x;
        Assert.IsTrue(true, "Should throw division by zero exception");
    }

    public void ThisShouldNotRun()
    {
        Assert.IsTrue(0 == 1, "Why is it running?!");
    }
    
}