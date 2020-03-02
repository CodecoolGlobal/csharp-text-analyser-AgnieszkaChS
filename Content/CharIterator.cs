using System.Linq;
using System.Collections.Generic;

namespace Content
{
    public class CharIterator : Iterator
    {
        private string[] chars;
        private int index;
        public CharIterator(FileContent fileContent)
        {
            index = -1;
            ConvertToChars(fileContent);
        }

        private void ConvertToChars(FileContent fileContent)
        {
            string[] charsWithWhitespaces = fileContent.TextFromFile.ToCharArray().Select(item => item.ToString()).ToArray();
            List<string> list = new List<string>(charsWithWhitespaces);
            list.RemoveAll(item => item == " ");
            chars = list.ToArray();
        }

        public bool HasNext()
        {
            if (this.index + 1 < chars.Length)
            {
                return true;
            }
            return false;
        }

        public string MoveNext()
        {
            return chars[++index];
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
