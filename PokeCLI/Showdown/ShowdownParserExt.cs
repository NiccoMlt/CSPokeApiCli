using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using PokeCLI.Showdown.Grammar;

namespace PokeCLI.Showdown
{
    public static class ShowdownParserExt
    {
        /// <summary>
        ///     <inheritdoc cref="ParserRuleContext.GetText" />
        ///     <para>It preserves whitespaces from hidden channel.</para>
        /// </summary>
        /// <remarks>
        ///     From <a href="https://stackoverflow.com/a/26533266/7907339">StackOverflow</a>, credit to Lucas Trzesniewski.
        /// </remarks>
        /// <param name="context">the parser rule context to retrieve full text from</param>
        /// <returns>the parsed text including hidden channel (mainly spaces)</returns>
        /// <seealso cref="RuleContext.GetText" />
        public static string GetFullText(this ParserRuleContext context)
        {
            return context.Start == null
                   || context.Stop == null
                   || context.Start.StartIndex < 0
                   || context.Stop.StopIndex < 0
                ? context.GetText() // Fallback
                : context.Start.InputStream.GetText(Interval.Of(context.Start.StartIndex, context.Stop.StopIndex));
        }

        public static ShowdownParser GetShowdownParser(this string document) => GetShowdownParserFromString(document);

        public static ShowdownParser GetShowdownParserFromString(string? document)
        {
            var stream = new AntlrInputStream(document);
            var lexer = new ShowdownLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ShowdownParser(tokens);
            return parser;
        }
    }
}
