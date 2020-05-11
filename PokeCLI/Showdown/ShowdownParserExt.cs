using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace PokeCLI.Showdown
{
    public static class ShowdownParserExt
    {
        /// <summary>
        /// <inheritdoc cref="ParserRuleContext.GetText"/>
        /// <para>It preserves whitespaces from hidden channel.</para>
        /// </summary>
        /// <remarks>
        /// From <a href="https://stackoverflow.com/a/26533266/7907339">StackOverflow</a>, credit to Lucas Trzesniewski.
        /// </remarks>
        /// <param name="context">the parser rule context to retrieve full text from</param>
        /// <returns>the parsed text including hidden channel (mainly spaces)</returns>
        /// <seealso cref="RuleContext.GetText"/>
        ///
        public static string GetFullText(this ParserRuleContext context)
        {
            if (context.Start == null || context.Stop == null || context.Start.StartIndex < 0 || context.Stop.StopIndex < 0)
                return context.GetText(); // Fallback

            return context.Start.InputStream.GetText(Interval.Of(context.Start.StartIndex, context.Stop.StopIndex));
        }
    }
}
