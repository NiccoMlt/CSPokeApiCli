using System.ComponentModel.DataAnnotations;
using CommandLine;

namespace CsPokeApiCli
{
    public class PkOptions
    {
        public PkOptions(string pokemonName)
        {
            PokemonName = pokemonName;
        }

        [Option(shortName: 'p', longName: "pokemon-name", Required = true, HelpText = "Input the Pokemon name to print the stats")]
        public string PokemonName { get; }
    }
}
