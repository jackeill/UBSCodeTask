using System.Collections.Generic;
using Xunit;

namespace UBSCodeTask.Tests
{
    public class WordCounterServiceTests
    {
        private readonly IWordCounterService _wordCounterService;

        public WordCounterServiceTests()
        {
            _wordCounterService = new WordCounterService();
        }

        [Theory]
        [InlineData("test", 1)]
        [InlineData("aaa", 1)]
        [InlineData("This is a test, and this is as well.", 7)]
        [InlineData("test test test test test test Test tEst test's", 2)]
        [InlineData(null, 0)]
        [InlineData("", 0)]                                             
        public void ReturnsProperNumberOfDistinctWords(string testText, int count)
        {
            var result = _wordCounterService.GetWordOccurenceCount(testText);

            Assert.Equal(result.Count, count);
        }
        
        [Fact]
        public void ReturnsProperDictionary()
        {
            var result = _wordCounterService.GetWordOccurenceCount("This is a statement, and so is this.");
            var expected = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "statement", 1 },
                { "and", 1 },
                { "so", 1 }
            };

            Assert.Equal(result.Count, expected.Count);

            foreach(var word in result)
            {
                int expectedValue;
                bool valueExists = expected.TryGetValue(word.Key, out expectedValue);

                Assert.True(valueExists);

                if(valueExists)
                {
                    Assert.Equal(word.Value, expectedValue);
                }
            }
        }
    }
}
