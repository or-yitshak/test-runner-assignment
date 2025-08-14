using TestFramework;

public class StringTests
{
    [Test]
    public void ShouldBeUppercase()
    {
        string input = "hello";
        string result = input.ToUpper();
        Assert.AreEqual("HELLO", result, "String was not converted to uppercase.");
    }

    [Test]
    public void ShouldBeUppercaseFail()
    {
        string input = "hello";
        Assert.AreEqual("HELLO", input, "String was not converted to uppercase.");
    }

    [Test]
    public void ShouldContainSubstring()
    {
        string text = "evreything is awesome";
        Assert.IsTrue(text.Contains("awesome"), "Substring 'awesome' not found.");
    }

    [Test]
    public void ShouldContainSubstringFail()
    {
        string text = "Hi!";
        Assert.IsTrue(text.Contains("awesome"), "Substring 'awesome' not found.");
    }

    [Test]
    public static void SomeStaticFunction()
    {
        Assert.IsTrue(true, "true is true");
    }

    [BeforeAll]
    public void BeforeAllFun()
    {
        Console.WriteLine("hello we run first");
    }
    
    [AfterAll]
    public void AfterAllAllFun()
    {
        Console.WriteLine("hello we run last");
    }
}