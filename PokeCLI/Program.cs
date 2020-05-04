using System;
using System.IO;
using Antlr4.Runtime;
using CommandLine;

namespace PokeCLI
{
    using Showdown.Grammar;

    class ShowdownOptions
    {
        public ShowdownOptions(string path)
        {
            Path = path;
        }

        [Option(shortName: 'i', longName: "input-team", Required = true)]
        public string Path { get; }
    }
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var input = CommandLine.Parser
                .Default
                .ParseArguments<ShowdownOptions>(args)
                .MapResult(opts => opts.Path, _ => null!);
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
            visitor.Visit(tree);
        }
    }
}
