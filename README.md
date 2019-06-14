# libcsv

CSV file reader/writer for .NET Standard 1.0

nuget https://www.nuget.org/packages/kenjiuno.libcsv/

Reader:

```C#
var csv = new Csvr();

csv.ReadStr("1,2,3", ',', '"');
//           CSV     Sep  Quote

Console.WriteLine(csv.Rows[0][0]);
//                  String[y][x]  0-based
```

Writer:

```C#
using (var writer = new StringWriter()) {
  var csv = new Csvw(writer, ',', '"');
  //                         Sep  Quote
  
  csv.Write("row-1 col-1");
  csv.Write("row-1 col-2");
  csv.Write("row-1 col-3");
  csv.NextRow();
  csv.Write("row-2 col-1");
  csv.Write("row-2 col-2");
  csv.Write("row-2 col-3");
}
```
