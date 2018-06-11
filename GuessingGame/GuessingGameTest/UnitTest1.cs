
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
        public void CanRead()
        {
            Assert.Equal("File read", Program.ReadFile());
        }

        [Fact]
        public void CanUpdate()
        {
            Assert.Equal("File updated", Program.UpdateFile("stuff"));
        }

        [Fact]
        public void CanDelete()
        {
            Assert.Equal("File deleted", Program.DeleteFile());
        }

        [Fact]
        public void CanAcceptInput()
        {
            
            Assert.Equal(0, Program.UserChoice(0));
        }

        
    }
}
