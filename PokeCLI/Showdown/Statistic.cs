using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeCLI.Showdown
{
    public enum Statistic
    {
        Hp,
        Atk,
        Def,
        SpA,
        SpD,
        Spe
    }

    public static class StatisticHelper
    {
        private static IEnumerable<KeyValuePair<Statistic, int>> VisitAllStats() =>
            from int stat in Enum.GetValues(typeof(Statistic))
            select new KeyValuePair<Statistic, int>(Enum.Parse<Statistic>($"{stat}"), 255);

        public static IDictionary<Statistic, int> VisitGetAllStatsAsDictionary() => VisitAllStats()
            .ToDictionary(pair => pair.Key, pair => pair.Value);

    }
}
