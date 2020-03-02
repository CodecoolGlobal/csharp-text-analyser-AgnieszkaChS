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

        public void Print(ICollection<string> list)
        {
            foreach (string element in list)
            {
                Console.Write(element + ", ");
            }
        }

        // public void Print(Dictionary<string, int> dictionary, int number)
        // {

        // }
    }


}
