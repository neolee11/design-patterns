using FactoryKit;
using Should;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DesignPatternTests.Creational
{
    public class FactoryKitTests
    {
        private readonly ITestOutputHelper output;

        public FactoryKitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(Skip = "Java Specific")]
        public void PatternShouldWork()
        {
          //IWeaponFactory factory = IWeaponFactory.
        }


    }
}
