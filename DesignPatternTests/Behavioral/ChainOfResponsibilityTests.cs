using ChainOfResponsibility;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternTests.Behavioral
{
    public class ChainOfResponsibilityTests
    {
        private readonly ITestOutputHelper output;

        public ChainOfResponsibilityTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
            var king = new OrcKing();
            king.makeRequest(new Request(RequestType.DEFEND_CASTLE, "defend castle"));
            king.makeRequest(new Request(RequestType.TORTURE_PRISONER, "torture prisoner"));
            king.makeRequest(new Request(RequestType.COLLECT_TAX, "collect tax"));
        }
    }
}
