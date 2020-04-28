using System;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using PokeApiNet;

namespace CsPokeApiCli
{

    class Program
    {
        public static async Task Main(string[] args)
        {
            var pokeClient = new PokeApiClient();
            var result = Parser.Default.ParseArguments<PkOptions>(args).MapResult(
                parsedFunc: async options =>
                    await pokeClient.GetResourceAsync<Pokemon?>(options.PokemonName),
                notParsedFunc: _ =>
                    Task.FromResult<Pokemon?>(null)
                    );
            var pkmn = await result;
            if (pkmn != null)
            {
                Console.WriteLine($"{pkmn.Name}: {string.Join(", ", pkmn.Types.Select(t => t.Type.Name))}");
            }
        }
    }
}
