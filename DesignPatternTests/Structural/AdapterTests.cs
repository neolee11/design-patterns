using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;
using Should;
using Xunit;

namespace DesignPatternTests.Structural
{
    public class AdapterTests
    {
        [Fact]
        public void DoSomethingShouldDo()
        {
            var sut = new DoSomething();
            var result = sut.GetNum();
            result.ShouldEqual(3);
        }
    }
}
