using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeCLI.Showdown;

namespace PokeCLI.Generator.Templates
{
    public class Pokemon : PageModel, IPokemonSet
    {
        public IPokemonSet PokemonSetImplementation { private get; set; }

        public Pokemon(IPokemonSet pokemonSetImplementation)
        {
            PokemonSetImplementation = pokemonSetImplementation;
        }

        public void OnGet()
        {
        }

        public string Nickname => PokemonSetImplementation.Nickname;

        public string Specie => PokemonSetImplementation.Specie;

        public string? Item => PokemonSetImplementation.Item;

        public string Ability => PokemonSetImplementation.Ability;

        public IList<string> Moves => PokemonSetImplementation.Moves;

        public int Level => PokemonSetImplementation.Level;

        public Sex Gender => PokemonSetImplementation.Gender;

        public bool Shiny => PokemonSetImplementation.Shiny;

        public IDictionary<Statistic, int> Ivs => PokemonSetImplementation.Ivs;

        public IDictionary<Statistic, int> Evs => PokemonSetImplementation.Evs;

        public string Nature => PokemonSetImplementation.Nature;
    }
}
