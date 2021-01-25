using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using static NotesApp.Tools.StringGenerator;

namespace NotesApp.Test.NotesTools
{
    public class StringGeneratorTests
    {
        [Fact]
        public void GenerateNumbersString_Should_Return_Empty_String_If_Argument_Length_Is_Zero_When_AllowLeadingZero()
        {
            var result = GenerateNumbersString(0,true);
            result.Should().Be("");
        }

        [Fact]
        public void GenerateNumbersString_Should_Return_Empty_String_If_Argument_Length_Is_Zero_When_Not_AllowLeadingZero()
        {
            var result = GenerateNumbersString(0, false);
            result.Should().Be("");
        }

        [Fact]
        public void GenerateNumbersString_Should_Throw_If_Value_Is_Invalid_When_AllowLeadingZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GenerateNumbersString(-2, true));
        }
       
        [Fact]
        public void GenerateNumbersString_Should_Throw_If_Value_Is_Invalid_When_Not_AllowLeadingZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GenerateNumbersString(-2, false));
        }
       
        [Fact]
        public void GenerateNumbersString_Should_Generate_String_Without_Zero_At_Beginning_If_Relevant_Argument_Given()
        {
            string result = GenerateNumbersString(03, true);
            result.StartsWith("0").Should().Be(false);
        }

        [Fact]
        public void GenerateNumbersSrting_Should_Return_String_With_Given_Length_When_AllowLeadingZero()
        {
            string result = GenerateNumbersString(16, true);
            result.Length.Should().Be(16);
        }

        [Fact]
        public void GenerateNumbersSrting_Should_Return_String_With_Given_Length_When_Not_AllowLeadingZero()
        {
            string result = GenerateNumbersString(16, false);
            result.Length.Should().Be(16);
        }

        [Fact]
        public void GenerateNumbersString_Should_Return_String_With_Given_Length_Convertible_Into_Numerical_When_AllowLeadingZero()
        {
            var result = GenerateNumbersString(7, true);
            bool isIntString = result.All(char.IsDigit);
            isIntString.Should().BeTrue();
            result.Length.Should().Be(7);
        }

        [Fact]
        public void GenerateNumbersString_Should_Return_String_With_Given_Length_Convertible_Into_Numerical_When_Not_AllowLeadingZero()
        {
            var result = GenerateNumbersString(7, false);
            bool isIntString = result.All(char.IsDigit);
            isIntString.Should().BeTrue();
            result.Length.Should().Be(7);
        }
    }
}
