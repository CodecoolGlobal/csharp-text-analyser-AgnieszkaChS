using System.Collections.Generic;
using System;
using Content;

namespace Analysis
{
    public class StatisticalAnalysis
    {
        private Iterator iterator;
        public List<string> dictionary {get; set;}
        public StatisticalAnalysis(Iterator iterator)
        {
            this.iterator = iterator;
        }

        public int CountOf(params string[] elems)
        {
            int count = 0;
            while (iterator.HasNext())
            {
                var current = iterator.MoveNext();

                foreach (string element in elems)
                {
                    if (current == element)
                    {
                        count++;
                    }
                }
            }
            iterator.Reset();

            return count;
        }

        public int DictionarySize()
        {
            dictionary = new List<string>();
            while (iterator.HasNext())
            {
                var current = iterator.MoveNext();
                if (!dictionary.Contains(current))
                {
                    dictionary.Add(current);
                }
            }
            iterator.Reset();
            return dictionary.Count;
        }

        public int Size()
        {
            int count = 0;
            while (iterator.HasNext())
                {
                    count++;
                    iterator.MoveNext();
                }
            iterator.Reset();
            return count;
        }

        public ISet<string> OccurMoreThan(int number)
        {
            ISet<string> setOfElements = new HashSet<string>();
            number = number / 100;
            foreach (string element in dictionary)
            {
                if ((float)CountOf(element) / (float)Size() > number)
                {
                    setOfElements.Add(element);
                }
            }
            return setOfElements;
        }
    }
}
