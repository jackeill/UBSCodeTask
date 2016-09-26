using System;

namespace UBSCodeTask
{
    public class Program
    {
        private static IWordCounterService _wordCounterService = new WordCounterService();
        
        public static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                return;
            }

            var words = _wordCounterService.GetWordOccurenceCount(args[0]);

            foreach(var word in words)
            {
                Console.WriteLine(word.Key + " - " + word.Value);
            }
        }
    }
}
