using System;
using System.Collections.Generic;

namespace libcsv
{
    public static class CsvrToDictionary
    {
        public static IEnumerable<IDictionary<string, string>> ToDictionaryList(this Csvr csv)
        {
            var rows = csv.Rows;
            var dictList = new List<CsvRow>();
            var headerRow = rows[0];
            for (int y = 1; y < rows.Length; y++)
            {
                var dict = new CsvRow();
                dictList.Add(dict);

                var oneRow = rows[y];
                for (int x = 0, cx = Math.Min(oneRow.Length, headerRow.Length); x < cx; x++)
                {
                    dict[headerRow[x]] = oneRow[x];
                }
            }
            return dictList;
        }
    }
}