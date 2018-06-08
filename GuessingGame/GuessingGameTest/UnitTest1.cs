
using Xunit;
using GuessingGame;
using System;
using System.IO;

namespace GuessingGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreate()
        {
            Assert.Equal("File created", Program.CreateFile());
        }

        [Fact]
        public void TestMethod()
        {
            Assert.Equal(1, Program.TestMethod());
        }
    }
}
