using Rant;
using Rant.Vocabulary;
using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralTextAdventure
{
    public class RantLoader
    {
        private static string folderPath = "C:\\Users\\newel\\Documents\\Code\\Rantionary\\";

        private static List<string> fileNames = new List<string>
        { "activities", "adjectives", "adverbs", "adverbs-attr", "adverbs-time", "celebrities", "countries", "descriptors"
        , "diseases", "elements" , "hobbies", "music-genres", "names-first", "names-last", "nouns", "nouns-uncountable"
        , "personal-titles", "prefixes", "pronouns-third-person", "states", "units", "verbs" };

        public static RantEngine StartEngine()
        {
            RantDictionary dictionary = new RantDictionary(); 

            foreach(string fileName in fileNames)
            {
                string filePath = folderPath + fileName + ".table";
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                RantDictionaryTable table = RantDictionaryTable.FromStream(filePath, stream);
                dictionary.AddTable(table);
                stream.Close();
            }

            return new RantEngine(dictionary); 
        }

        public static RantDictionaryTable FindTable(RantDictionary dictionary, string searchTerm)
        {
            RantDictionaryTable table = null; 
            foreach(RantDictionaryTable _table in dictionary.GetTables())
            {
                if (_table.Name == searchTerm)
                {
                    table = _table; 
                }
            }
            return table; 
        }

        public static List<string> GetClasses(RantDictionaryTable table)
        {
            List<string> classes = new List<string>(); 
            foreach(string className in table.GetClasses())
            {
                classes.Add(className); 
            }
            return classes; 
        }

        public static List<string> GetEntries(RantDictionaryTable table)
        {
            List<string> entries = new List<string>(); 
            foreach(RantDictionaryEntry entry in table.GetEntries())
            {
                entries.Add(entry.ToString()); 
            }
            return entries; 
        }


    }
}
