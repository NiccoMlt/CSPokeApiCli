using System.ComponentModel.DataAnnotations;
using CommandLine;

namespace CsPokeApiCli
{
    interface IPokemonOptions
    {
        [Option(shortName: 'p', longName: "pokemon-name", Group = "pokemon", HelpText = "Input the Pokemon name")]
        string PokemonName { get; }

        [Option(shortName: 'i', longName: "pokemon-id", Group = "pokemon", HelpText = "Input the Pokemon number")]
        string PokemonId { get; }
    }

    [Verb(name: "type", HelpText = "Print the type(s) of a pokemon")]
    public class TypeOptions: IPokemonOptions
    {
        public TypeOptions(string pokemonName, string pokemonId)
        {
            PokemonName = pokemonName;
            PokemonId = pokemonId;
        }


        public string PokemonName { get; }

        public string PokemonId { get; }
    }

    [Verb(name: "stats", HelpText = "Print the stats of a Pokemon")]
    public class StatsOptions : IPokemonOptions
    {
        public StatsOptions(string pokemonName, string pokemonId)
        {
            PokemonName = pokemonName;
            PokemonId = pokemonId;
        }

        public string PokemonName { get; }
        public string PokemonId { get; }
    }
}
