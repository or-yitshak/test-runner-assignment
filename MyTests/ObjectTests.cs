using TestFramework;

public class ObjectTests
{
    [Test]
    public void Objects_WithSameReference_ShouldBeEqual()
    {
        var obj1 = new object();
        var obj2 = obj1; // Same object
        Assert.AreEqual(obj1, obj2, "Objects with same reference should be equal.");
    }

    [Test]
    public void Objects_WithDifferentReferences_ShouldNotBeEqual()
    {
        var obj1 = new object();
        var obj2 = new object(); // Different object
        Assert.IsTrue(!obj1.Equals(obj2), "Different objects should not be equal.");
    }

    [Test]
    public void CustomObjects_WithSameValues_ShouldBeEqual()
    {
        var p1 = new Person("Alice", 30);
        var p2 = new Person("Alice", 30);
        Assert.AreEqual(p1, p2, "Custom objects with same values should be equal.");
    }
}

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
            return Name == other.Name && Age == other.Age;
        return false;
    }
    public override int GetHashCode() => (Name, Age).GetHashCode();
}