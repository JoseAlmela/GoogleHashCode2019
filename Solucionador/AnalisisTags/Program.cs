﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/carla/Desktop/hasCodeGoogle/example/";
            Dictionary<string, int> dicTags = new Dictionary<string, int>();
            List<string> lines = File.ReadAllLines(path + "c_memorable_moments.txt").Skip(1).ToList();

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                string[] tags = words.Skip(2).ToArray();

                for (int index = 0; index < tags.Length; index++)
                {
                    string tag = tags[index];

                    if (dicTags.ContainsKey(tag))
                    {
                        dicTags[tag]++;
                    }
                    else
                    {
                        dicTags.Add(tag, 1);
                    }
                }
            }

            List<KeyValuePair<string, int>> listTags = dicTags.ToList().OrderBy(pair => pair.Value).ToList();

            using (StreamWriter writer = new StreamWriter(path + "c_memorable_moments.result.txt"))
            {
                foreach (KeyValuePair<string, int> tag in listTags)
                {
                    string outputLine = "tag: " + tag.Key + " count: " + tag.Value;
                    writer.WriteLine(outputLine);
                }
            }
        }
    }
}
