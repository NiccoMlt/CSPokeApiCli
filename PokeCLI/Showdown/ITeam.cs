using System.Collections.Generic;

namespace PokeCLI.Showdown
{
    public interface ITeam: IEnumerable<IPokemonSet>
    {
        string Name { get; }
        string Format { get; }
        IList<IPokemonSet> Members { get; }
    }
}
