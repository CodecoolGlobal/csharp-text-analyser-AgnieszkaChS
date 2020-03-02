using System.Collections.Generic;

namespace Content
{
    public class WordIterator : Iterator
    {
        private string[] words;
        private int index;
        public WordIterator(FileContent fileContent)
        {
            index = -1;
            ConvertToWords(fileContent);
        }

        private void ConvertToWords(FileContent fileContent)
        {
            words = fileContent.TextFromFile.Split(' ');
            List<string> list = new List<string>(words);
            list.RemoveAll(item => item == "");
            words = list.ToArray();
        }

        public bool HasNext()
        {
            if (this.index + 1 < words.Length)
            {
                return true;
            }
            return false;
        }

        public string MoveNext()
        {

            return words[++index];
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
