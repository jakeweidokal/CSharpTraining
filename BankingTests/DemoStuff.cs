using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class DemoStuff
    {
        [Fact]
        public void CohesionAndStuff()
        {
            var words = new List<string> { "The", "Brown", "Cow" };

            var sentence = "The Brown Cow";
            var theWords = sentence.Split(' ');

            var sentenceTwo = String.Join(' ', theWords);
        }
    }
}
