using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UBSCodeTask
{    
    public interface IWordCounterService 
    {
        IDictionary<string, int> GetWordOccurenceCount(string text);
    }
}