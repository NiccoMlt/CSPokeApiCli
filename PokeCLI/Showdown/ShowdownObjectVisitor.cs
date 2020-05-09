using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using PokeCLI.Showdown.Grammar;

namespace PokeCLI.Showdown
{
    public class ShowdownObjectVisitor : ShowdownBaseVisitor<object?>
    {
        [return: NotNull]
        public override object VisitTeam([NotNull] ShowdownParser.TeamContext context)
        {
            var parsedTeam = new List<PokemonSet>(6);
            var pokemons = context
                ?.children
                ?.OfType<ShowdownParser.PokemonContext>()
                           ?? Enumerable.Empty<ShowdownParser.PokemonContext>();

            foreach (var pkmn in pokemons)
            {
                VisitPokemon(pkmn);
            }

            Console.WriteLine(parsedTeam.Count);

            return parsedTeam;
        }

        [return: NotNull]
        public override object VisitPokemon([NotNull] ShowdownParser.PokemonContext context) {
            var nick = (string?) VisitNickname(context.nickname());
            var specie = (string) VisitName(context.name());
            var gender = (string?) VisitSex(context.sex()) switch
            {
                "M" => Sex.Male,
                "F" => Sex.Female,
                _ => Sex.Unknown
            };
            var item = (string?) VisitItem(context.item());
            var ability = (string) VisitAbility(context.ability());
            var shiny = (bool) VisitShiny(context.shiny());
            var level = (int) VisitLevel(context.level());
            var moves = (IList<string>) VisitMoves(context.moves());
            var evs = (IDictionary<Statistic, int>?) VisitEvs(context.evs());
            var ivs = (IDictionary<Statistic, int>?) VisitIvs(context.ivs());
            var nature = (string) VisitNature(context.nature());
            return new PokemonSet(nick, specie, item, ability, moves, level, gender, shiny, nature, evs: ivs, ivs: evs);
        }

        [return: NotNullIfNotNull("context")]
        public override object? VisitNickname([MaybeNull] ShowdownParser.NicknameContext? context) => context?.GetText();

        [return: NotNull]
        public override object VisitName(ShowdownParser.NameContext context) => context.GetText();

        [return: NotNullIfNotNull("context")]
        public override object? VisitSex([MaybeNull] ShowdownParser.SexContext? context) => context?.GetText();

        [return: NotNullIfNotNull("context")]
        public override object? VisitItem([MaybeNull] ShowdownParser.ItemContext? context) => context == null
            ? null
            : string.Join(" ", context.WORD().Select(word => word.GetText()));

        [return: NotNull]
        public override object VisitAbility(ShowdownParser.AbilityContext context) => context.GetText();

        [return: NotNull]
        public override object VisitShiny(ShowdownParser.ShinyContext? context) => context
            ?.GetText()
            .Equals("Yes") ?? false;

        [return: NotNull]
        public override object VisitLevel(ShowdownParser.LevelContext? context) =>
            int.TryParse(context?.GetText(), out var level) ? level : 100;

        [return: NotNull]
        public override object VisitHappiness(ShowdownParser.HappinessContext? context) =>
            int.TryParse(context?.GetText(), out var happinesss) ? happinesss : 255;

        [return: NotNull]
        public override object VisitStats(ShowdownParser.StatsContext context) => context.stat()
            .Select(stat => ((Statistic, int)?) VisitStat(stat))
            .ToDictionary(pair => pair?.Item1, pair => pair?.Item2);

        [return: NotNull]
        public override object VisitStat(ShowdownParser.StatContext context) => new KeyValuePair<Statistic, int>(
            Enum.Parse<Statistic>(context.children[1].GetText(), true),
            int.Parse(context.children[0].GetText())
        );

        [return: NotNull]
        public override object VisitNature(ShowdownParser.NatureContext context) => context.GetText();

        [return: NotNull]
        public override object VisitMoves(ShowdownParser.MovesContext context) => context.move()
            .Select(move => (string) VisitMove(move))
            .ToList();

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
