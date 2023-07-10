using System.IO;

namespace Interpreter
{
    public class Dack
    {
        public void Run(string path)
        {
            StreamReader reader = new StreamReader(path);
            string content = reader.ReadToEnd();
            Tokenizer tokenizer = new Tokenizer(content);
        }
    }
}
