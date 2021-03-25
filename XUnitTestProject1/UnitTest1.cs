using System;
using WebApplication1.Data;
using Xunit;
using System.Web;

namespace XUnitTestProject1
{
    public class StripStringTest: MockBookRepo
    {
        [Fact]
        public void StripString_ReturnTrue()
        {
            string result = StripString("Fortnite the movie");
            Assert.Equal("Fortnite-the-movie", result);
        }

        [Fact]
        public void StripString_ReturnTrue1()
        {
            string result = StripString("mc#donalds is pretty&cool");
            Assert.True(result == "mc-donalds-is-pretty-cool");
        }

        [Fact]
        public void StripString_ReturnFalse()
        {
            string result = StripString("mc##donalds is pretty&cool");
            Assert.False(result == "mc-donalds-is-pretty-cool");
        }
    }



    public class GetBookTests: MockBookRepo
    {
        [Fact]
        public void GetBookByName_ReturnTrue()
        {
            var result = GetBookByName(HttpUtility.UrlDecode("Fortnite%20the%20movie"));
            Assert.Equal(result.Id, GetBookByID(0).Id);
        }
        [Fact]
        public void GetBookByName1_ReturnFalse()
        {
            var result = GetBookByName(HttpUtility.UrlDecode("shitty%20movie%20book"));
            Assert.False(result!=null);
        }

        [Fact]
        public void GetBookById_ReturnTrue()
        {
            var result = GetBookByID(1);
            Assert.True("Steve vs Herobrine" == result.BookName);
        }

        [Fact]
        public void GetBookById1_ReturnTrue()
        {
            var result = GetBookByID(2);
            Assert.True("Faker?, WHAT#WAS%THAT?" == result.BookName);
        }
    }
}
