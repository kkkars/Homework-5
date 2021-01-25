using System;
using Xunit;
using NotesApp.Services.Models;
using NotesApp.Services.Abstractions;
using Moq;

namespace NotesApp.Test.NotesService
{
    public class NotesServiceTests
    {
        [Fact]
        public void AddNote_Should_Throw_If_Note_Argument_Is_Null()
        {
            var storageMoq = new Mock<INotesStorage>();
            var eventsMoq = new Mock<INoteEvents>();

            var noteService = new Services.Services.NotesService(storageMoq.Object, eventsMoq.Object);
            Assert.Throws <ArgumentNullException>(()=> noteService.AddNote(null, 1));
        }

        [Fact]
        public void AddNote_Should_Notify_If_Able_To_Add_Note()
        {
            var storageMoq = new Mock<INotesStorage>();
            var eventsMoq = new Mock<INoteEvents>();

            var noteService = new Services.Services.NotesService(storageMoq.Object, eventsMoq.Object);

            var note = new Note();
            note.Id = Guid.NewGuid();

            noteService.AddNote(note, 1);

            storageMoq.Verify(n => n.AddNote(note, 1), Times.Once);
            eventsMoq.Verify(n => n.NotifyAdded(note, 1),Times.Once);
        }

        [Fact]
        public void AddNote_Should_Not_Notify_If_Unable_To_Add_Note()
        {
            var storageMoq = new Mock<INotesStorage>();
            var eventsMoq = new Mock<INoteEvents>();

            var noteService= new Services.Services.NotesService(storageMoq.Object, eventsMoq.Object);

            Assert.Throws<ArgumentNullException>(() => noteService.AddNote(null, 1));

            storageMoq.Verify(n => n.AddNote(null, 1), Times.Never);
            eventsMoq.Verify(n => n.NotifyAdded(null, 1), Times.Never);
        }

        [Fact]
        public void DeleteNote_Should_Notify_If_Able_To_Delete_Note()
        {
            var storageMoq = new Mock<INotesStorage>();
            var eventsMoq = new Mock<INoteEvents>();

            var noteService = new Services.Services.NotesService(storageMoq.Object, eventsMoq.Object);

            Note note = new Note();
            note.Id = Guid.NewGuid();

            storageMoq.Setup(stor => stor.DeleteNote(note.Id)).Returns(true);
            noteService.DeleteNote(note.Id, 1);
            eventsMoq.Verify(n => n.NotifyDeleted(note.Id, 1), Times.Once);
        }
        
        [Fact]
        public void DeleteNote_Should_Not_Notify_If_Unable_To_Delete_Note()
        {
            var storageMoq = new Mock<INotesStorage>();
            var eventsMoq = new Mock<INoteEvents>();

            var noteService = new Services.Services.NotesService(storageMoq.Object, eventsMoq.Object);

            Note note = new Note();
            note.Id = Guid.NewGuid();

            storageMoq.Setup(stor => stor.DeleteNote(note.Id)).Returns(false);

            noteService.DeleteNote(note.Id, 1);
            eventsMoq.Verify(n => n.NotifyDeleted(note.Id, 1), Times.Never);
        }
    }
}