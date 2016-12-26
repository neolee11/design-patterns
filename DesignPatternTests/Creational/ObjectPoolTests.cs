using FactoryKit;
using ObjectPool;
using Should;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DesignPatternTests.Creational
{
    public class ObjectPoolTests
    {
        private readonly ITestOutputHelper output;

        public ObjectPoolTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
            var pool = new OliphauntPool();
            pool.ToString().ShouldEqual("Pool available=0 inUse=0");

            Oliphaunt expectedOliphaunt = pool.checkOut();
            pool.ToString().ShouldEqual("Pool available=0 inUse=1");

            pool.checkIn(expectedOliphaunt);
            pool.ToString().ShouldEqual("Pool available=1 inUse=0");

            for (int i = 0; i < 100; i++)
            {
                Oliphaunt oliphaunt = pool.checkOut();
                pool.ToString().ShouldEqual("Pool available=0 inUse=1");
                expectedOliphaunt.ShouldBeSameAs(oliphaunt);
                expectedOliphaunt.Id.ShouldEqual(oliphaunt.Id);
                expectedOliphaunt.ToString().ShouldEqual(oliphaunt.ToString());

                pool.checkIn(oliphaunt);
                pool.ToString().ShouldEqual("Pool available=1 inUse=0");
            }

        }
    }
}
