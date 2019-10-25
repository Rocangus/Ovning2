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

        [Fact]
        public void CalculateTicketPriceCalculatesCorrectly()
        {
            int price = CalculateTicketPrice(55);
            Assert.Equal(120, price);
            price = CalculateTicketPrice(20);
            Assert.Equal(120, price);
            price = CalculateTicketPrice(64);
            Assert.Equal(120, price);
            price = CalculateTicketPrice(19);
            Assert.Equal(80, price);
            price = CalculateTicketPrice(100); 
            Assert.Equal(90, price);
            price = CalculateTicketPrice(101); 
            Assert.Equal(0, price);
            price = CalculateTicketPrice(3);
            Assert.Equal(0, price);
        }
    }
}
