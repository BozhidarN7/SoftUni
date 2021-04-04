namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            sets = new List<ISet>();
            songs = new List<ISong>();
            performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs =>songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return performers.FirstOrDefault(x => x.Name == name);
        }

        public ISet GetSet(string name)
        {
            return sets.FirstOrDefault(x => x.Name == name);
        }

        public ISong GetSong(string name)
        {
            return songs.FirstOrDefault(x => x.Name == name);
        }

        public bool HasPerformer(string name)
        {
            return performers.Any(x => x.Name == name);
        }

        public bool HasSet(string name)
        {
            return sets.Any(x => x.Name == name);
        }

        public bool HasSong(string name)
        {
            return songs.Any(x => x.Name == name);
        }
    }
}
