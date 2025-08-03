using AwesomeAssertions;

namespace API.Tests;

public class UnitTest1
{
    private bool banana = true;

    [Fact]
    public void Test1()
    {
        banana.Should().BeTrue();
    }
}
