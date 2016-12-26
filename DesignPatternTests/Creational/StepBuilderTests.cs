using System.Threading;
using Should;
using Singleton;
using StepBuilder;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DesignPatternTests.Creational
{
    public class StepBuilderTests
    {
        private readonly ITestOutputHelper output;

        public StepBuilderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
            var character =
                CharacterStepBuilder.NewBuilder()
                    .SetName("Daniel")
                    .SetFighterClass("Great figher")
                    .WithWeapon("Sword")
                    .WithAbility("Jump")
                    .WithAbility("Run")
                    .NoMoreAbilities()
                    .Build();

            var result = character.ToString();
            output.WriteLine(result);

            result.ShouldNotBeEmpty();
        }
    }
}
