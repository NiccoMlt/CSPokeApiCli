using System.Collections.Generic;

namespace PokeCLI.Showdown
{
    public interface ITeam: IEnumerable<IPokemonSet>
    {
        string Name { get; }
        string Format { get; }
        IList<IPokemonSet> Members { get; }
    }

    public interface IPokemonSet
    {
        string Nickname { get; }
        string Pokemon { get; } // TODO: replace with actual specie class
        string Item { get; } // TODO: replace with actual item class
        string Ability { get; } // TODO: replace with actual ability class
        IMoveSet Moves { get; }
        int Level { get; }
        Sex Gender { get; }
        bool Shiny { get; }
        IStatSpread Ivs { get; }
        IStatSpread Evs { get; }
        string Nature { get; }
    }

    public interface IMoveSet: ISet<string> // TODO: replace with actual move class
    {
    }

    public interface IStatSpread : IDictionary<Statistic, int>
    {
    }

    public enum Sex {
        Male,
        Female,
        Unknown
    }

    public enum Statistic
    {
        Hp,
        Atk,
        Def,
        SpA,
        SpD,
        Spe
    }
}
