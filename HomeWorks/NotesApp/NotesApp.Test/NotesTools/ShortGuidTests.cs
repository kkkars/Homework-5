using FluentAssertions;
using System;
using Xunit;

namespace NotesApp.Test.NotesTools
{
    public class ShortGuidTests
    {
        [Fact]
        public void ToShortId_Should_Convert_Guid_Into_Short_Guid()
        {
            Tools.ShortGuid.ToShortId(Guid.NewGuid()).Length.Should().Be(22);
        }

        [Fact]
        public void FromShortId_Should_Convert_String_Guid_Into_Guid()
        {
            var shortGuid = Tools.ShortGuid.ToShortId(Guid.NewGuid());
            Tools.ShortGuid.FromShortId(shortGuid).ToString().Length.Should().Be(36);
        }

        [Fact]
        public void FromShortId_Should_Work_If_To_ToShortId_Result_Add_Double_Equals()
        {
            var guid = Guid.NewGuid();
            var shortGuid = NotesApp.Tools.ShortGuid.ToShortId(guid);
            Assert.Equal(NotesApp.Tools.ShortGuid.FromShortId(shortGuid+"=="), guid);
        }

        [Fact]
        public void FromShortId_Should_Convert_String_Guid_Representation_Into_Guid()
        {
            var guid = Guid.NewGuid();
            var shortGuid = NotesApp.Tools.ShortGuid.ToShortId(guid);
            Assert.Equal(NotesApp.Tools.ShortGuid.FromShortId(shortGuid), guid);
        }

        [Fact]
        public void FromShortId_Should_Throw_If_Argument_Is_Invalid()
        {
          Assert.Throws<FormatException>(() => NotesApp.Tools.ShortGuid.FromShortId("aeodbuwrf"));
        }

        [Fact]
        public void FromShortId_Should_Return_Null_If_Argument_Is_Null()
        {
            NotesApp.Tools.ShortGuid.FromShortId(null).Should().Be(null);
        }
    }
}
