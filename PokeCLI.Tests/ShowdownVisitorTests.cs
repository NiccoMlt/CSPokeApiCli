using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using PokeCLI.Showdown;
using PokeCLI.Showdown.Grammar;
using Xunit;

namespace PokeCLI.Tests
{
    public class ShowdownVisitorTests
    {
        [Theory]
        [InlineData("Karate Chop")]
        [InlineData("Fly")]
        [InlineData("Soft-Boiled")]
        [InlineData("Conversion 2")]
        [InlineData("King's Shield")]
        [InlineData("Baby-Doll Eyes")]
        [InlineData("Soul-Stealing 7-Star Strike")]
        [InlineData("10,000,000 Volt Thunderbolt")]
        public void VisitMove_ShouldReturnMove_IfTheMoveIsValid(string move)
        {
            var visitor = Substitute.For<IShowdownVisitor<object?>>();
            var sut = new ShowdownVisitor(visitor);
            var parser = move.GetShowdownParser();
            var moveContext = parser.move();

            visitor.VisitMove(moveContext).Returns(move);
            sut.VisitMove(moveContext).Should().Be(visitor.VisitMove(moveContext) as string);
        }

        [Fact]
        public void VisitMove_ShouldThrowException_IfTheMoveIsNotValid()
        {
            var visitor = Substitute.For<IShowdownVisitor<object?>>();
            var sut = new ShowdownVisitor(visitor);
            visitor.VisitMove(Arg.Any<ShowdownParser.MoveContext>()).Returns(null);
            Action action = () => sut.VisitMove(null!);
            action.Should().Throw<ShowdownSemanticException>();
        }

        public static IEnumerable<object[]> MovesData
        {
            get
            {
                return new[]
                {
                    new object[] { new List<string> { "Soft-Boiled", "Conversion 2", "King's Shield", "10,000,000 Volt Thunderbolt" } }
                };
            }
        }

        [Theory]
        [MemberData(nameof(MovesData))]
        public void VisitMoves_ShouldReturnCollectionOfMoves(IList<string> moves)
        {
            var visitor = Substitute.For<IShowdownVisitor<object?>>();
            var sut = new ShowdownVisitor(visitor);
            var parser = string.Join("\n", moves.Select(move => $"- {move}")).GetShowdownParser();
            var movesContext = parser.moves();

            visitor.VisitMoves(movesContext).Returns(moves);
            sut.VisitMoves(movesContext).Should().Equal(moves);
        }

        [Fact]
        public void VisitMoves_ShouldReturnEmptyCollectionOfMoves_IfNull()
        {
            var visitor = Substitute.For<IShowdownVisitor<object?>>();
            var sut = new ShowdownVisitor(visitor);
            visitor.VisitMoves(null).Returns(null);
            sut.VisitMoves(null!).Should().BeNull();
        }
    }
}
