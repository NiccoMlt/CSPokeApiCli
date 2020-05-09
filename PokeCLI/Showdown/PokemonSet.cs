using System.Collections.Generic;

namespace PokeCLI.Showdown
{
    public interface IStatSpread : IDictionary<Statistic, int>
    {
    }

    public interface IMoveSet : ISet<string> // TODO: replace with actual move class
    {
    }

    public enum Sex
    {
        Male,
        Female,
        Unknown
    }

    public interface IPokemonSet
    {
        string Nickname { get; }
        string Pokemon { get; } // TODO: replace with actual specie class
        string? Item { get; } // TODO: replace with actual item class

        string Ability { get; } // TODO: replace with actual ability class

        /*IMoveSet*/
        IList<string> Moves { get; }
        int Level { get; }
        Sex Gender { get; }

        bool Shiny { get; }

        /*IStatSpread*/
        IDictionary<Statistic, int> Ivs { get; }

        /*IStatSpread*/
        IDictionary<Statistic, int> Evs { get; }
        string Nature { get; }
    }

    class PokemonSet : IPokemonSet
    {
        public PokemonSet(string? nickname,
            string pokemon,
            string? item,
            string ability,
            IList<string> moves,
            int level,
            Sex gender,
            bool shiny,
            string nature,
            IDictionary<Statistic, int>? evs = null,
            IDictionary<Statistic, int>? ivs = null)
        {
            Nickname = nickname ?? pokemon;
            Pokemon = pokemon;
            Item = item;
            Ability = ability;
            Moves = moves;
            Level = level;
            Gender = gender;
            Shiny = shiny;
            Ivs = StatisticHelper.VisitGetAllStatsAsDictionary();
            if (ivs != null)
            {
                foreach (var (key, value) in ivs)
                {
                    Ivs[key] = value;
                }
            }

            Evs = StatisticHelper.VisitGetAllStatsAsDictionary();
            if (evs != null)
            {
                foreach (var (key, value) in evs)
                {
                    Evs[key] = value;
                }
            }

            Nature = nature;
        }

        public string Nickname { get; }
        public string Pokemon { get; }
        public string? Item { get; }
        public string Ability { get; }
        public IList<string> Moves { get; }
        public int Level { get; }
        public Sex Gender { get; }
        public bool Shiny { get; }
        public IDictionary<Statistic, int> Ivs { get; }
        public IDictionary<Statistic, int> Evs { get; }
        public string Nature { get; }
    }
}
