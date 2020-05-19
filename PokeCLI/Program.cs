using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using CommandLine;
using PokeCLI.Showdown;

namespace PokeCLI
{
    using Showdown.Grammar;

    public class ShowdownOptions
    {
        public ShowdownOptions(string inputPath)
        {
            InputPath = inputPath;
        }

        [Option(shortName: 'i', longName: "input-team", Required = true)]
        public string InputPath { get; }
    }
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var input = CommandLine.Parser
                .Default
                .ParseArguments<ShowdownOptions>(args)
                .MapResult(opts => opts.InputPath, _ => null!);
            var str = new AntlrInputStream(new StreamReader(
                Environment.CurrentDirectory
                + Path.DirectorySeparatorChar
                + input));
            var lexer = new ShowdownLexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ShowdownParser(tokens);
            var errorListener = new ConsoleErrorListener<IToken>();
            parser.AddErrorListener(errorListener);

            var tree = parser.team();
            var visitor = new ShowdownObjectVisitor();
            var team = visitor.Visit(tree) as IList<PokemonSet>;
        }
    }
}
