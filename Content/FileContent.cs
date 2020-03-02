using System.IO;
using System;

namespace Content
{
    public class FileContent : IterableText
    {
        private string path;
        private Iterator charIterator;
        private Iterator wordIterator;

        public string TextFromFile { get; set; }
        
        
        public FileContent(string path)
        {
            this.path = path;
            if (IsFileGoodToProcess(path))
            {
                GetFileText();
                this.charIterator = new CharIterator(this);
                this.wordIterator = new WordIterator(this);
            }
        }

        public Iterator CharIterator()
        {
            return charIterator;
        }

        public Iterator WordIterator()
        {
            return wordIterator;
        }

        public string GetFileName()
        {
            return path;
        }

        private bool IsFileGoodToProcess(string path)
        {
            if (File.Exists(path) && new FileInfo(path).Length > 0)
            {
                return true;
            }
            return false;
        }
        private void GetFileText()
        {
            this.TextFromFile = File.ReadAllText(path).ToLower().Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " "); // Environment.NewLine did not work
        }
    }
}
