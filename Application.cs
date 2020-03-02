using Content;
using Analysis;
using System;

namespace Application
{
    public class Application
    {
        static void Main(string[] args)
        {
            RunApp("test.txt");
        }

        private static void RunApp(string path)
        {
            FileContent fileContent = new FileContent(path);
            StatisticalAnalysis charStatisticalAnalysis = new StatisticalAnalysis(fileContent.CharIterator());
            StatisticalAnalysis wordStatisticalAnalysis = new StatisticalAnalysis(fileContent.WordIterator());
            View view = new View();
            Console.WriteLine($"---{path}---");
            view.Print($"Char count: {charStatisticalAnalysis.Size()}");
            view.Print($"Word count: {wordStatisticalAnalysis.Size()}");
            view.Print($"Dict size: {wordStatisticalAnalysis.DictionarySize()}");
            float vowelShare = (float)charStatisticalAnalysis.CountOf("a", "e", "i", "o", "u") / (float)charStatisticalAnalysis.Size() * 100;
            view.Print($"Vowels %: {Math.Round(vowelShare, 2)}%");
            view.Print("Most used words (>1%):");
            view.Print(wordStatisticalAnalysis.OccurMoreThan(1));
            
            
            
        }
    }
}
