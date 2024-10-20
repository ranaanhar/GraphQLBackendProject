using GraphQLBackend;

namespace NunitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var actual=new Service().add(1,1);
        var expected=2;
        Assert.That(actual==expected);
    }
}