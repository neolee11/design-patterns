using System.Threading;
using FactoryKit;
using ObjectPool;
using Should;
using Singleton;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DesignPatternTests.Creational
{
    public class SingletonTests
    {
        private readonly ITestOutputHelper output;

        public SingletonTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PatternShouldWork()
        {
            var server1 = Server.Instance;

            Thread.Sleep(1000);

            var server2 = Server.Instance;

            server1.Name.ShouldEqual(server2.Name);

        }
    }
}
