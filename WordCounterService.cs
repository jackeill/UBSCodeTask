using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UBSCodeTask
{    
    public class WordCounterService : IWordCounterService
    {
        private const string WordSelectorPattern = "[a-z0-9']+";

        public IDictionary<string, int> GetWordOccurenceCount(string text)
        {
            text = text ?? string.Empty;

            var results = Regex
                .Matches(text.ToLower(), WordSelectorPattern, RegexOptions.None, Regex.InfiniteMatchTimeout)
                .Cast<Match>()
                .GroupBy(m => m.Value)
                .ToDictionary(grp => grp.Key, grp => grp.Count());

            return results;
        }
    }
}