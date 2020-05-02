namespace CsPokeApiCli
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Antlr4.Runtime;
    using CsPokeApiCli.Showdown;
    using io.github.niccomlt.showdown;

    public class ShowdownObjectVisitor : ShowdownBaseVisitor<object?>
    {
        private List<Pokemon> ParsedTeam = new List<Pokemon>(6);

        // public override object? VisitTeam(ShowdownParser.TeamContext context)
        // {
        //     var pokemons = context.children.OfType<ShowdownParser.PokemonContext>();

        //     foreach (var pkmn in pokemons)
        //     {
        //         VisitPokemon(pkmn);
        //     }

        //     Console.WriteLine(ParsedTeam.Count());

        //     return base.VisitTeam(context);
        // }
        //
        // public override object? VisitPokemon(ShowdownParser.PokemonContext context)
        // {
        //     var nick = (string?) VisitNickname(context.nickname());
        //     var specie = (string) VisitName(context.name());
        //     var gender = (string?) VisitSex(context.sex());
        //     var item = (string?) VisitItem(context.item());
        //     var ability = (string) VisitAbility(context.ability());
        //     var shiny = (bool) VisitShiny(context.shiny());

        //     var s = nick + " " + specie + " " + gender + " " + item + " " + ability + " " + shiny;

        //     Console.WriteLine(s);

        //     return s;
        // }

        [return: NotNullIfNotNull("context")]
        public override object? VisitNickname([MaybeNull] ShowdownParser.NicknameContext? context) => context?.GetText();

        [return: NotNull]
        public override object VisitName(ShowdownParser.NameContext context) => context.GetText();

        [return: NotNullIfNotNull("context")]
        public override object? VisitSex([MaybeNull] ShowdownParser.SexContext? context) => context?.GetText();

        [return: NotNullIfNotNull("context")]
        public override object? VisitItem([MaybeNull] ShowdownParser.ItemContext? context) => context == null ? null : String.Join(" ", context.WORD().Select(word => word.GetText()));

        [return: NotNull]
        public override object VisitAbility(ShowdownParser.AbilityContext context) => context.GetText();

        [return: NotNull]
        public override object VisitShiny(ShowdownParser.ShinyContext? context) => context?.GetText().Equals("Yes") ?? false;

        [return: NotNull]
        public override object VisitHappiness(ShowdownParser.HappinessContext? context) => int.Parse(context?.GetText() ?? "255");

        [return: NotNull]
        public override object VisitStats(ShowdownParser.StatsContext context) => context.stat().Select(stat => VisitStat(stat)).ToList();

        [return: NotNull]
        public override object VisitStat(ShowdownParser.StatContext context) => (int.Parse(context.children[0].GetText()), context.children[1].GetText());

        [return: NotNull]
        public override object VisitNature(ShowdownParser.NatureContext context) => context.GetText();

        [return: NotNull]
        public override object VisitMoves(ShowdownParser.MovesContext context) => context.move().Select(move => VisitMove(move)).ToList();

        [return: NotNull]
        public override object VisitMove(ShowdownParser.MoveContext context) => context.GetText();

        /***********************************************************************************/

        // public override object? Visit(IParseTree tree)
        // {
        //     return base.Visit(tree);
        // }
        //
        // public override object? VisitChildren(IRuleNode node)
        // {
        //     return base.VisitChildren(node);
        // }
        //
        // public override object? VisitTerminal(ITerminalNode node)
        // {
        //     return base.VisitTerminal(node);
        // }
        //
        // public override object? VisitErrorNode(IErrorNode node)
        // {
        //     return base.VisitErrorNode(node);
        // }
        //
        // protected override object? AggregateResult(object? aggregate, object? nextResult)
        // {
        //     return base.AggregateResult(aggregate, nextResult);
        // }
        //
        // protected override bool ShouldVisitNextChild(IRuleNode node, object? currentResult)
        // {
        //     return base.ShouldVisitNextChild(node, currentResult);
        // }
    }
}
