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
            CreateDictionary();
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

        private void CreateDictionary()
        {
            this.dictionary = new List<string>();
            while (iterator.HasNext())
            {
                var current = iterator.MoveNext();
                if (!this.dictionary.Contains(current))
                {
                    this.dictionary.Add(current);
                }
            }
            iterator.Reset();
        }

        public int DictionarySize()
        {
            return this.dictionary.Count;
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
            float floatNumber = (float)number / 100;
            var sumOfWords = (float)Size();
            foreach (string element in dictionary)
            {
                if ((float)CountOf(element) / sumOfWords > floatNumber)
                {
                    setOfElements.Add(element);
                }
            }
            return setOfElements;
        }

        public float ShareInText(params string[] elems)
        {
            return (float)CountOf(elems) / (float)Size() * 100;
        }

        public float CountRatio(string first, string second)
        {
            return (float)CountOf(first) / (float)CountOf(second);
        }

        public Dictionary<string, int> CountElementsToDictionary(params string[] elems)
        {
            Dictionary<string, int> dictOfElements = new Dictionary<string, int>();
            for (int i = 0; i < elems.Length; i++)
            {
                dictOfElements.Add(elems[i], CountOf(elems[i]));
            }
            return dictOfElements;
        }

        public Dictionary<string, float> GetShareOfElementsToDictionary(params string[] elems)
        {
            Dictionary<string, float> dictOfElements = new Dictionary<string, float>();
            for (int i = 0; i < elems.Length; i++)
            {
                dictOfElements.Add(elems[i], ShareInText(elems[i]));
            }
            return dictOfElements;
        }

    }
}
