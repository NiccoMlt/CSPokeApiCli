using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using PokeCLI.Showdown.Grammar;

namespace PokeCLI.Showdown
{
    public class ShowdownVisitor
    {
        private readonly IShowdownVisitor<object?> _visitor;

        public ShowdownVisitor() : this(new ShowdownObjectVisitor())
        {
        }

        public ShowdownVisitor(IShowdownVisitor<object?> visitor)
        {
            _visitor = visitor;
        }

        [return: NotNull]
        public IList<IPokemonSet> VisitTeam([NotNull] ShowdownParser.TeamContext context) =>
            _visitor.VisitTeam(context) as IList<IPokemonSet>
            ?? throw new ShowdownSemanticException("Team should not be null");

        [return: NotNull]
        public IPokemonSet VisitPokemon([NotNull] ShowdownParser.PokemonContext context) =>
            _visitor.VisitPokemon(context) as IPokemonSet
            ?? throw new ShowdownSemanticException("PokemonSet should not be null");

        [return: NotNullIfNotNull("context")]
        public string? VisitNickname([MaybeNull] ShowdownParser.NicknameContext? context) =>
            _visitor.VisitNickname(context) as string;

        public string VisitSpecie(ShowdownParser.SpecieContext context) =>
            _visitor.VisitSpecie(context) as string
            ?? throw new ShowdownSemanticException("Pokemon name should not be null");

        [return: NotNullIfNotNull("context")]
        public Sex? VisitSex([MaybeNull] ShowdownParser.SexContext? context) => (Sex?) _visitor.VisitSex(context);

        // [return: NotNullIfNotNull("context")]
        // public override object? VisitItem([MaybeNull] ShowdownParser.ItemContext? context) => context == null
        //     ? null
        //     : string.Join(" ", context.WORD().Select(word => word.GetText()));
        //
        // [return: NotNull]
        // public override object VisitAbility(ShowdownParser.AbilityContext context) => context.GetText();
        //
        // [return: NotNull]
        // public override object VisitShiny(ShowdownParser.ShinyContext? context) => context
        //     ?.GetText()
        //     .Equals("Yes") ?? false;
        //
        // [return: NotNull]
        // public override object VisitLevel(ShowdownParser.LevelContext? context) =>
        //     int.TryParse(context?.GetText(), out var level) ? level : 100;
        //
        // [return: NotNull]
        // public override object VisitHappiness(ShowdownParser.HappinessContext? context) =>
        //     int.TryParse(context?.GetText(), out var happinesss) ? happinesss : 255;
        //
        // [return: NotNull]
        // public override object VisitStats(ShowdownParser.StatsContext context) => context.stat()
        //     .Select(stat => ((Statistic, int)?) VisitStat(stat))
        //     .ToDictionary(pair => pair?.Item1, pair => pair?.Item2);
        //
        // [return: NotNull]
        // public override object VisitStat(ShowdownParser.StatContext context) => new KeyValuePair<Statistic, int>(
        //     Enum.Parse<Statistic>(context.children[1].GetText(), true),
        //     int.Parse(context.children[0].GetText())
        // );
        //
        // [return: NotNull]
        // public override object VisitNature(ShowdownParser.NatureContext context) => context.GetText();

        [return: NotNull]
        public IEnumerable<string> VisitMoves(ShowdownParser.MovesContext context) => (IEnumerable<string>) _visitor.VisitMoves(context)!;

        [return: NotNull]
        public string VisitMove(ShowdownParser.MoveContext context) =>
            _visitor.VisitMove(context) as string
            ?? throw new ShowdownSemanticException("Pokemon move should not be null");
    }

    public class ShowdownSemanticException : Exception
    {
        public ShowdownSemanticException()
        {
        }

        public ShowdownSemanticException(string message)
            : base(message)
        {
        }

        public ShowdownSemanticException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
