using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace stojson
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Wrong or missing file");
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Too many arguments");
            }
            else
            {
                try
                {
                    string fileContent = "";
                    using (var sr = new StreamReader(args[0]))
                    {
                        fileContent = sr.ReadToEnd();
                    }
                    var WordList = ToWordList(fileContent);
                    string jsonString = JsonSerializer.Serialize(WordList,
                        // This line for a proper encoding
                        new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
                    string fileName = "WordsJson.json";
                    int i = 1;
                    while (File.Exists(fileName))
                    {
                        fileName = $"WordsJson{i}.json";
                        i++;
                    }
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.WriteLine(jsonString);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("End");
        }

        private static List<Word> ToWordList(string fileContent)
        {
            var ListOfWords = new List<Word>();
            var elements = fileContent.Split("\r\n");
            foreach (var i in elements)
            {
                var wordElements = i.Split(';');
                var word = new Word();
                word.Name = wordElements[0];
                for (int j = 1; j < wordElements.Length; j++)
                {
                    word.Synonyms.Add(wordElements[j]);
                }
                ListOfWords.Add(word);
            }

            return ListOfWords;
        }
    }
}
