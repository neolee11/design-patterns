using FactoryKit;
using Should;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DesignPatternTests.Creational
{
    public class ModuleTests
    {
        private readonly ITestOutputHelper output;

        public ModuleTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(Skip = "Pattern not implemented")]
        public void PatternShouldWork()
        {
          //IWeaponFactory factory = IWeaponFactory.
        }


    }
}
