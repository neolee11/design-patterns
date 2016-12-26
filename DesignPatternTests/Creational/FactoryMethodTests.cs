using FactoryMethod;
using Should;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DesignPatternTests.Creational
{
    public class FactoryMethodTests
    {
        private readonly ITestOutputHelper output;

        public FactoryMethodTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
          IBlacksmith factory = new ElfBlacksmith();
            var weapon = factory.manufactureWeapon(EWeaponType.AXE);
            weapon.ToString().ShouldEqual("Elven AXE");
        }


    }
}
