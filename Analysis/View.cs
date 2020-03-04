using System;
using System.Collections.Generic;

namespace Analysis
{
    public class View
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void Print(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    Console.Write(list[i]);
                }
                else
                {
                    Console.Write(list[i] + ", ");
                }
            }
            Console.WriteLine();
        }

        public void Print(Dictionary<string, int> dictionary)
        {
            foreach (KeyValuePair<string, int> item in dictionary)
            {
                Console.WriteLine($"'{item.Key}' count: {item.Value}");
            }
        }

        public void Print(Dictionary<string, float> dictionary)
        {
            foreach (KeyValuePair<string, float> item in dictionary)
            {
                Console.Write($"[ {item.Key.ToUpper()} -> {Math.Round(item.Value, 2)} ] ");
            }
        }
    }


}
