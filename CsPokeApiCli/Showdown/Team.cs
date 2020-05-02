using System.Collections.Generic;

namespace CsPokeApiCli.Showdown
{
    class Team
    {
        public Team(List<Pokemon> pokemons)
        {
            Pokemons = pokemons;
        }

        public List<Pokemon> Pokemons { get; }
    }

    enum Sex {
        Male,
        Female,
        Unknown
    }

    class Pokemon
    {
        private readonly string? _nickName;

        public Pokemon(string? nickName, string name)
        {
            _nickName = nickName;
            Name = name;
        }

        public string Name { get; }

        public string NickName
        {
            get { return _nickName ?? Name; }
        }
    }
}

