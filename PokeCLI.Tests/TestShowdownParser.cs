using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using PokeCLI.Showdown;
using PokeCLI.Showdown.Grammar;
using Xunit;

namespace PokeCLI.Tests
{
    public class TestShowdownParser
    {

        [Theory]
        [InlineData(
            "Snowy.sdt", "Snowy", "Vulpix-Alola", "M", "Icium Z", "Snow Cloak", "248 HP / 8 Atk / 252 SpD", null, "Gentle",
            new [] { "Powder Snow", "Hail", "Aurora Veil", "Tackle" })]
        [InlineData(
            "Sejun_Park’s_Pachirisu.sdt", null, "Pachirisu", null, "Sitrus Berry", "Volt Absorb", "252 HP / 252 Def / 4 SpD", null, "Impish",
            new [] { "Nuzzle", "Follow Me", "Super Fang", "Protect" }
            )]
        public void ShowdownParser_Pokemon_Parses(string filename,
            string? nickname, string name, string? sex, string? item,
            string ability,
            string? evs,
            string? ivs,
            string nature,
            IEnumerable<string> moves)
        {
            var stream = new AntlrInputStream(new StreamReader(
                Environment.CurrentDirectory
                + Path.DirectorySeparatorChar
                + "Resources"
                + Path.DirectorySeparatorChar
                + filename));

            var lexer = new ShowdownLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ShowdownParser(tokens);
            var errorListener = new ConsoleErrorListener<IToken>();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            // var errorListener = new DiagnosticErrorListener();
            // parser.RemoveErrorListeners();
            // parser.AddErrorListener(errorListener);

            var tree = parser.pokemon();
            Assert.Equal(nickname, tree.nickname()?.GetText());
            Assert.Equal(name, tree.name()?.GetText());
            Assert.Equal(sex, tree.sex()?.GetText());
            Assert.Equal(ability, tree.ability()?.GetFullText());
            Assert.Equal(evs, tree.evs().stats()?.GetFullText());
            Assert.Equal(ivs, tree!.ivs()?.GetText());
            Assert.Equal(nature, tree.nature()?.GetText());
            Assert.Equal(item, tree.item()?.GetFullText());
            Assert.Equal(
                moves,
                tree.moves()?.move()?.Select(context => context.GetFullText())
            );
        }
    }
}
