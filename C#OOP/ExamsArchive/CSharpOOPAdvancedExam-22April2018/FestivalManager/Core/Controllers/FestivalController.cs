namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Sets;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private readonly ISetController setController;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISetFactory setFactory;
        private readonly ISongFactory songFactory;
        public FestivalController(IStage stage)
        {
            this.stage = stage;
            setController = new SetController(stage);
            instrumentFactory = new InstrumentFactory();
            performerFactory = new PerformerFactory();
            setFactory = new SetFactory();
            songFactory = new SongFactory();
        }

        public string RegisterSet(string[] args)
        {
            string setType = args[0];
            string setName = args[1];

            if (setType == "Long")
            {
                stage.AddSet(new Long(setName));
            }
            else if (setType == "Medium")
            {
                stage.AddSet(new Medium(setName));
            }
            else if (setType == "Short")
            {
                stage.AddSet(new Short(setName));
            }
            return $"Registered {setType} set";
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            string[] instrumentTypes = args.Skip(2).ToArray();

            IInstrument[] instruments = instrumentTypes
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            foreach (IInstrument instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];
            TimeSpan duration = TimeSpan.Parse(args[1]);

            ISong song = songFactory.CreateSong(songName, duration);

            return $"Registered song {song.Name} ({duration.Minutes}:{duration.Seconds})";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[0];

            IPerformer performer = stage.GetPerformer(performerName);
            if(performer == null)
            {
                throw new InvalidOperationException("Invalid performer provided");
            }
            ISet set = stage.GetSet(setName);
            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            set.AddPerformer(performer);
            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            return setController.PerformSets();
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            ISet set = stage.GetSet(setName);

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            ISong song = stage.GetSong(songName);
            if (song == null)
            {
                throw new InvalidOperationException("Invalid song provided");
            }
            set.AddSong(song);

            return $"Added {songName} ({song.Duration}) to {setName}";
        }
    }
}