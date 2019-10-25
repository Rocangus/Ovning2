using System;
using System.IO;
using Xunit;
using static Ovning2.Program;

namespace Ovning2Test
{
    public class UnitTest1
    {
        [Fact]
        public void ParseMovieAgeInputParsesCorrectly()
        {
            int age = ParseMovieAgeInput("40");
            Assert.Equal(40, age);
            age = ParseMovieAgeInput("70");
            Assert.Equal(70, age);
            age = ParseMovieAgeInput("String");
            Assert.Equal(-1, age);
            age = ParseMovieAgeInput("-75");
            Assert.Equal(-1, age);
        }

        [Fact]
        public void PrintTotalTicketPriceInfoGetsCorrectSum()
        {
            var ages = new int[] { 20, 64, 65, 19, 28, 58 };
            var sum = PrintTotalTicketPriceInfo(ages);

            Assert.Equal(650, sum);
        }
    }
}
