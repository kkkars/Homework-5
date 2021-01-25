using FluentAssertions;
using System;
using Xunit;
using static NotesApp.Tools.NumberGenerator;

namespace NotesApp.Test.NotesTools
{
    public class NumberGeneratorTests
    {
        [Fact]
        public void GeneratePositiveLong_Should_Throw_If_Value_Is_Invalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GeneratePositiveLong(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => GeneratePositiveLong(20));
        }
        
        [Fact]
        public void GeneratePositiveLong_Should_Return_Number_With_Given_Characters_Amount()
        {
            var number = GeneratePositiveLong(16);
            Convert.ToString(number).Length.Should().Be(16);
        }
    }
}
