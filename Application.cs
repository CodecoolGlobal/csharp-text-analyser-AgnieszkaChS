using Content;
using Analysis;
using System;
using System.Collections.Generic;

namespace Application
{
    public class Application
    {
        static void Main(string[] args)
        {
            RunApp("test2.txt");
        }

        private static void RunApp(string path)
        {
            FileContent fileContent = new FileContent(path);
            StatisticalAnalysis charStatisticalAnalysis = new StatisticalAnalysis(fileContent.CharIterator());
            StatisticalAnalysis wordStatisticalAnalysis = new StatisticalAnalysis(fileContent.WordIterator());
            View view = new View();
            Console.WriteLine();
            Console.WriteLine($"---{path}---");
            Console.WriteLine();

            view.Print($"Char count: {charStatisticalAnalysis.Size()}");
            view.Print($"Word count: {wordStatisticalAnalysis.Size()}");
            view.Print($"Dict size: {wordStatisticalAnalysis.DictionarySize()}");

            float vowelShare = charStatisticalAnalysis.ShareInText("a", "e", "i", "o", "u");
            view.Print($"Vowels %: {Math.Round(vowelShare, 0)}%");

            view.Print("Most used words (>1%):");
            view.Print(new List<string>(wordStatisticalAnalysis.OccurMoreThan(1)));

            view.Print(wordStatisticalAnalysis.CountElementsToDictionary("love", "hate", "music"));
            
            string firstLetter = "a";
            string secondLetter = "e";
            Console.WriteLine($"{firstLetter} : {secondLetter} count ratio: {Math.Round(charStatisticalAnalysis.CountRatio(firstLetter, secondLetter), 2)}");

            view.Print(charStatisticalAnalysis.GetShareOfElementsToDictionary(charStatisticalAnalysis.dictionary.ToArray()));

            Console.WriteLine();


            
        }
    }
}
