using AbstractFactory;
using Adapter;
using Should;
using Xunit;

namespace DesignPatternTests.Creational
{
    public class AbstractFactoryTests
    {
        public ICastle Castle { get; set; }
        public IKing King { get; set; }

        private void CreateKingdom(IKingdomFactory factory)
        {
            this.Castle = factory.CreateCastle();
            this.King = factory.CreateKing();
        }

        [Fact]
        public void PatternShouldWork()
        {
            this.CreateKingdom(new GoodKingdomFactory());
            this.Castle.Location().ShouldEqual("Awesome city");
            this.King.Description().ShouldEqual("I'm a good king");

            this.CreateKingdom(new EvilKingdomFactory());
            this.Castle.Location().ShouldEqual("Winter town");
            this.King.Description().ShouldEqual("I'm an evil king");
        }


    }
}
