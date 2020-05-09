using System.Collections.Generic;
using PokeCLI.Showdown.Grammar;

namespace PokeCLI.Showdown
{
    public class ShowdownVisitor
    {
        private IShowdownVisitor<object> _visitor;

        public ShowdownVisitor(IShowdownVisitor<object> visitor)
        {
            _visitor = visitor;
        }

        public IList<IPokemonSet> VisitTeam(ShowdownParser.TeamContext context) => _visitor.VisitTeam(context) as IList<IPokemonSet>;

        public IPokemonSet VisitPokemon(ShowdownParser.PokemonContext context) => _visitor.VisitPokemon(context) as IPokemonSet;

        public string? VisitNickname(ShowdownParser.NicknameContext? context) => _visitor.VisitNickname(context) as string ?? null;

        public string VisitName(ShowdownParser.NameContext context) => _visitor.VisitName(context) as string;
        //
        // [return: NotNullIfNotNull("context")]
        // public override object? VisitSex([MaybeNull] ShowdownParser.SexContext? context) => context?.GetText();
        //
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
        //
        // [return: NotNull]
        // public override object VisitMoves(ShowdownParser.MovesContext context) => context.move()
        //     .Select(move => (string) VisitMove(move))
        //     .ToList();
        //
        // [return: NotNull]
        // public override object VisitMove(ShowdownParser.MoveContext context) => context.GetText();
    }
}
