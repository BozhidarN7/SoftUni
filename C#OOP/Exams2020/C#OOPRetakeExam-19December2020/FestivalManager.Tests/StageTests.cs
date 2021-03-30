// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
        }
        [Test]
        public void When_ConstructorInvolve_ShouldInitializeToList()
        {
            Assert.That(new Stage().Performers.Count, Is.EqualTo(0));
        }
        [Test]
        public void When_AddPerformerCall_ShouldAddPerofmer()
        {
            Performer performer = new Performer("FirstName", "LastName", 18);

            int currentCount = 0;
            stage.AddPerformer(performer);
            Assert.AreEqual(stage.Performers.Count, currentCount + 1);
        }
        [Test]
        public void When_AddPerfomerCallWithAgeLessThanRequiredAge_ShouldThrowExceptoin()
        {
            Performer performer = new Performer("FirstName", "LastName", 15);

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }
        [Test]
        public void When_AddPerfomerCallWithNullPerfomerObject_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }
        [Test]
        public void When_AddSongCallWithNullObject_ShuldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }
        [Test]
        public void When_AddSongAddSongWithDurationLessThanOneMinute_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Song", new TimeSpan(0,0,30))));
        }
        [Test]
        public void When_AddSongToPerfomerCallWithNullObjects_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Test Test"));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Test", null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, null));
        }

        [Test]
        public void When_AddSongToPerfomerCallAndPerfomerMissed_ShuoldThrowException()
        {
            Song song = new Song("Good song", new TimeSpan(0, 3, 30));
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Good song", "Test"));
        }
        [Test]
        public void When_AddSongToPerfomerCallAndSongMissed_ShouldThrowException()
        {
            Performer performer = new Performer("Test", "Test", 20);
            stage.AddPerformer(performer);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Good song", "Test Test"));
        }
        [Test]
        public void When_AddSongToPerformerCall_ShouldAddNewSongToPerformerSongList()
        {
            Song song = new Song("Song", new TimeSpan(0, 1, 0));
            Performer performer = new Performer("Test", "Test", 18);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            int currentCount = performer.SongList.Count;

            stage.AddSongToPerformer("Song", "Test Test");

            Assert.AreEqual(performer.SongList.Count, currentCount + 1);

        }
        [Test]
        public void When_PlaySongCall_ShouldReturnMessageMessage()
        {
            Performer performer1 = new Performer("Test1", "Test1", 20);
            Performer performer2 = new Performer("Test2", "Test2", 20);

            Song song1 = new Song("Song1", new TimeSpan(0, 3, 30));
            Song song2 = new Song("Song2", new TimeSpan(0, 3, 30));

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song1);
            stage.AddSong(song2);

            stage.AddSongToPerformer("Song1", "Test1 Test1");
            stage.AddSongToPerformer("Song2", "Test2 Test2");

            Assert.That(stage.Play, Is.EqualTo($"{2} performers played {2} songs"));
        }

    }
}