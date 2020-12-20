using System;
using System.Collections.Generic;
using System.Text;

namespace stojson
{
    class Word
    {
        public string Name { get; set; }
        public List<string> Synonyms { get; set; } = new List<string>();

        public Word()
        {
        }
        public override string ToString()
        {
           return $"Name: {Name}, Synonyms: {string.Join(",", Synonyms)}";
        }
    }
}
