using TestFramework;

public class MathTests
{
    static int y = 0;

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
        x = 5 / x;
        Assert.IsTrue(true, "Should throw division by zero exception");
    }

    [Test]
    public void YEqual5()
    {
        Assert.IsTrue(y == 5, "y should be equal to 5 ");
    }

    public void ThisShouldNotRun()
    {
        Assert.IsTrue(0 == 1, "Why is it running?!");
    }

    [BeforeAll]
    public void BeforeAllFun()
    {
        y = 5;
        Console.WriteLine("i changed y from 0 to 5");
    }
    
    [AfterAll]
    public void AfterAllAllFun()
    {
        Console.WriteLine("hello we run last");
    }
    
}