using Builder;
using Should;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternTests.Creational
{
    public class BuilderTests
    {
        private readonly ITestOutputHelper output;

        public BuilderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
           var megaHero = new Hero.HeroBuilder(Profession.MAGE, "Daniel").WithHairType(HairType.LONG_STRAIGHT).Build();
            var result = megaHero.ToString();

            output.WriteLine(result);
            result.ShouldNotBeEmpty();
        }


    }
}
