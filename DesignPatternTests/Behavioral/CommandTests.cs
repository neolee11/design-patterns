using Command;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternTests.Behavioral
{
    public class CommandTests
    {
        private readonly ITestOutputHelper output;

        public CommandTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
            Wizard wizard = new Wizard(this.output);
            Goblin goblin = new Goblin();

            goblin.printStatus(this.output);

            wizard.castSpell(new ShrinkSpell(), goblin);
            goblin.printStatus(this.output);

            wizard.castSpell(new InvisibilitySpell(), goblin);
            goblin.printStatus(this.output);

            wizard.undoLastSpell();
            goblin.printStatus(this.output);

            wizard.undoLastSpell();
            goblin.printStatus(this.output);

            wizard.redoLastSpell();
            goblin.printStatus(this.output);

            wizard.redoLastSpell();
            goblin.printStatus(this.output);
        }
    }
}
