using NUnit.Framework;

namespace LineCountKata.UnitTests
{
    public class LineCounterShould
    {
        private LineCounter _lineCounter;

        [SetUp]
        public void SetUp()
        {
            _lineCounter = new LineCounter();
        }

        [Test]
        public void return_zero_on_an_empty_line()
        {
            Assert.AreEqual(0, _lineCounter.CountLines(""));
        }
        
        [Test]
        public void return_one_on_a_file_with_a_line_of_code()
        {
            Assert.AreEqual(1, _lineCounter.CountLines("while  { // I'm a comment"));
        }

        [Test]
        public void not_count_empty_lines()
        {
            Assert.AreEqual(2, _lineCounter.CountLines("I'm code \r\n  \t  \r\n And I'm another line of code"));
        }
        
        [Test]
        public void not_count_single_line_comments()
        {
            Assert.AreEqual(2, _lineCounter.CountLines("I'm code \r\n // I'm a comment \t  \r\n And I'm another line of code"));
        }

        [Test]
        public void not_count_inline_comments()
        {
            Assert.AreEqual(1, _lineCounter.CountLines("/* I'm a comment And I'm another comment */ I'm code"));
        }        
        
        [Test]
        public void not_count_multiple_line_comments()
        {
            Assert.AreEqual(0, _lineCounter.CountLines("/* I'm a comment And \r\n I'm another comment */"));
        }

        [Test]
        public void count_code_after_multiple_line_comments()
        {
            Assert.AreEqual(1, _lineCounter.CountLines("/* I'm a comment And \r\n I'm another comment */ I'm code"));
        }

        [Test]
        public void not_count_line_breaks_inside_strings()
        {
            Assert.AreEqual(1, _lineCounter.CountLines("print(\"Hello \r\n World\")"));
        }
    }
}
