using System;
using Xunit;

namespace libcsv.tests
{
    public class UnitTest1
    {
        Csvr reader = new Csvr();

        [Fact]
        public void Simple3Columns()
        {
            reader.ReadStr("1,2,3", ',', '"');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1", "2", "3" });
        }

        [Fact]
        public void Empty3Lines()
        {
            reader.ReadStr("\n\n", ',', '"');
            Assert.Equal(reader.Rows.Length, 2);
            Assert.Equal(reader.Rows[0], new String[] { });
            Assert.Equal(reader.Rows[1], new String[] { });
        }

        [Fact]
        public void Simple3Rows()
        {
            reader.ReadStr("1\n2\n3", ',', '"');
            Assert.Equal(reader.Rows.Length, 3);
            Assert.Equal(reader.Rows[0], new String[] { "1" });
            Assert.Equal(reader.Rows[1], new String[] { "2" });
            Assert.Equal(reader.Rows[2], new String[] { "3" });
        }

        [Fact]
        public void Simple3x3()
        {
            reader.ReadStr("1,2,3\na,b,c\nABC,DEF,GHI", ',', '"');
            Assert.Equal(reader.Rows.Length, 3);
            Assert.Equal(reader.Rows[0], new String[] { "1", "2", "3" });
            Assert.Equal(reader.Rows[1], new String[] { "a", "b", "c" });
            Assert.Equal(reader.Rows[2], new String[] { "ABC", "DEF", "GHI" });
        }

        [Fact]
        public void Simple3AndSeparatorTerminated()
        {
            reader.ReadStr("1,2,3,", ',', '"');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1", "2", "3", "" });
        }

        [Fact]
        public void Simple3AndSeparatorAndEOL()
        {
            reader.ReadStr("1,2,3,\n", ',', '"');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1", "2", "3", "" });
        }

        [Fact]
        public void ContinuousSeparatorsAndEOF()
        {
            reader.ReadStr("1,,", ',', '"');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1", "", "" });
        }

        [Fact]
        public void ContinuousSeparatorsForEOLAndEOFPatterns()
        {
            reader.ReadStr("1,,\n2,,", ',', '"');
            Assert.Equal(reader.Rows.Length, 2);
            Assert.Equal(reader.Rows[0], new String[] { "1", "", "" });
            Assert.Equal(reader.Rows[1], new String[] { "2", "", "" });
        }

        [Fact]
        public void TestQuote()
        {
            reader.ReadStr("\"1,2,3\"", ',', '"');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1,2,3" });
        }

        [Fact]
        public void TestQuoteMixMulti()
        {
            reader.ReadStr("#1,2,3#,4,#A##B##C#", ',', '#');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1,2,3", "4", "A#B#C" });
        }

        [Fact]
        public void TestQuoteAndEOLAndEOF()
        {
            reader.ReadStr("#1,2,3#\n", ',', '#');
            Assert.Equal(reader.Rows.Length, 1);
            Assert.Equal(reader.Rows[0], new String[] { "1,2,3"});
        }
    }
}
