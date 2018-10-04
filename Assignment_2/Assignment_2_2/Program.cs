using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer Text = new TextAnalyzer();
            Dictionary<char, int> Characters = new Dictionary<char, int>();

            string TextGenerated = Text.getText();

            Console.WriteLine("Generated String: " + TextGenerated);
               
            // Here we initialize a collection of times char appears in the generated string

            foreach( char c in TextGenerated)
            {
                if (!Characters.ContainsKey(c))
                    Characters.Add(c, 1);
                Characters[c] += 1;
            }

            Console.WriteLine("Characters Count: ");
            foreach(KeyValuePair<char, int> Character in Characters)
            {
                Console.WriteLine("Character : {0}, Count: {1} ", Character.Key, Character.Value);
            }

            Console.ReadLine();
        }
    }
}
