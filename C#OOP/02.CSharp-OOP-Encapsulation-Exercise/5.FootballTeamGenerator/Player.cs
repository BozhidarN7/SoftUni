using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Player
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfNameIsInvalid(value, "A name should not be empty.");
                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            private set
            {
                Validator.ThrowIfStatIsNotInRange(MinStat, MaxStat, value, $"{nameof(Endurance)} should be between {MinStat} and {MaxStat}.");
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                Validator.ThrowIfStatIsNotInRange(MinStat, MaxStat, value, $"{nameof(Sprint)} should be between {MinStat} and {MaxStat}.");
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                Validator.ThrowIfStatIsNotInRange(MinStat, MaxStat, value, $"{nameof(Dribble)} should be between {MinStat} and {MaxStat}.");
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                Validator.ThrowIfStatIsNotInRange(MinStat, MaxStat, value, $"{nameof(Passing)} should be between {MinStat} and {MaxStat}.");
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                Validator.ThrowIfStatIsNotInRange(MinStat, MaxStat, value, $"{nameof(Shooting)} should be between {MinStat} and {MaxStat}.");
                shooting = value;
            }
        }

        public double SkillLevel => Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);

    }
}
