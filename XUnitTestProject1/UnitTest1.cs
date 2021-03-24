using System;
using WebApplication1.Data;
using Xunit;

namespace XUnitTestProject1
{
    public class StripStringTest
    {
        [Fact]
        public void StripString_ReturnTrue()
        {
            MockBookRepo mock = new MockBookRepo();
            string result = mock.StripString("hello how are you");
            Assert.Equal("hello-how-are-you", result);
        }

        [Fact]
        public void StripString_ReturnTrue1()
        {
            MockBookRepo mock = new MockBookRepo();
            string result = mock.StripString("mc#donalds is pretty&cool");
            Assert.True(result == "mc-donalds-is-pretty-cool");
        }

        [Fact]
        public void StripString_ReturnFalse()
        {
            MockBookRepo mock = new MockBookRepo();
            string result = mock.StripString("mc##donalds is pretty&cool");
            Assert.False(result == "mc-donalds-is-pretty-cool");
        }
    }
}
