﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Ksu.Cis300.TextAnalysis
{

    public static class TextAnalyzer
    {
        const string _pattern = "[^a-z]+";

        static Regex regex = new Regex(_pattern);
        

        
        /// <summary>
        /// Takes a dictionary of a file and returns a dictionary containg the frequency of each word
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Dictionary<String, double> GetFrequencies(Dictionary<string, int>dict)
        {

           Dictionary<String, double> freqeuncies = new Dictionary<String, double>();

            int totalWords = GetTotalWords(dict);

           foreach( KeyValuePair<string,int> kvp in dict)   
            {
                //potentially filter out empty strings here
               freqeuncies.Add(kvp.Key, CalcFrequency(dict, kvp.Key, totalWords));
            }

            return freqeuncies;
        }

        /// <summary>
        /// converts the line of text to lowercase then splits it
        /// </summary>
        /// <param name="Line">the line to be split</param>
        /// <returns>a string array containng the words</returns>
        private static string[] BreakLineIntoWords(string Line)
        {
            Line = Line.ToLower();
            string[] words = regex.Split(Line);
            return words;
        }

        /// <summary>
        /// takes a dict and string array and adds each word that is non empty to the dict 
        /// and updates the corrispoding int
        /// </summary>
        /// <param name="dict"> a dict tracking the words</param>
        /// <param name="words">the array of words to be added</param>
        private static void UpdateOccurences( Dictionary<string,int> dict, string[] words)
        {
            int value;

            foreach ( string word in words)
            {
                if( word != "" && dict.TryGetValue(word, out value))
                {
                    dict[word] = value + 1;
                }
                else if(word != "")
                {
                    dict.Add(word, 1);
                }
            }
        }


        /// <summary>
        /// Takes a File info and reads each file in it and then reads the text in each file to a dictionary with the frequencies of each word
        /// </summary>
        /// <param name="files">the file containing the files</param>
        /// <returns>a dict containing the frequecnies of each word</returns>
        public static Dictionary<string,double>[] BuildFrequencyTables(FileInfo[] files)
        {

            Dictionary<string, double>[] frequencies = new Dictionary<string, double>[files.Count()];

            for (int i = 0; i < files.Count(); i++)
            {
               Dictionary<string, int> wordCount = ReadIntoLines(files[i].FullName);


                frequencies[i] = GetFrequencies(wordCount);
            }

            return frequencies;
                
        }

        /// <summary>
        /// takes a file and reads its text into a dict
        /// </summary>
        /// <param name="fileName">the name of the file</param>
        /// <param name="fileDict">the dict to update to</param>
        private static Dictionary<string, int> ReadIntoLines(string fileName )
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                string line;
                Dictionary<string, int> fileDict = new Dictionary<string, int>();

                while ((line = input.ReadLine()) != null)
                {
                    UpdateOccurences(fileDict, BreakLineIntoWords(line));
                }

                return fileDict;

            }
        }

        /// <summary>
        /// calculates the diffrence between selected file and another file
        /// </summary>
        /// <param name="file1">the selected file</param>
        /// <param name="file2">file calculated on</param>
        /// <param name="lowerThreshold">the lower threshold</param>
        /// <param name="upperThreshold">the upperthreshold</param>
        /// <param name="wordsCompared">the total number of words used in the comparison</param>
        /// <returns>the diffrence between file 1 and file 2 with an out of the amount of words compared</returns>
        public static double CompareDiffrences(Dictionary<string,double> file1, Dictionary<string, double> file2, double lowerThreshold, double upperThreshold, out int wordsCompared)
        {
            double value;
            double frequency1;
            double frequency2;

            double sumOfChange = 0;
            wordsCompared = 0;

            foreach(KeyValuePair<string,double> kvPair in file1)
            {
                if(file2.TryGetValue(kvPair.Key,out value))
                {
                    
                    if(BetweenThreshold(file1, kvPair.Key, lowerThreshold, upperThreshold, out frequency1) && BetweenThreshold(file2, kvPair.Key, lowerThreshold, upperThreshold, out frequency2))
                    {
                        sumOfChange = ( frequency1 - frequency2) * (frequency1 - frequency2);
                        wordsCompared++;
                    }
                }   

            }
            return Math.Sqrt(sumOfChange);
        }

        




        /// <summary>
        /// calculates the frequency of a given word in given file
        /// </summary>
        /// <param name="dict">the dictionary the for the file the word is in</param>
        /// <param name="key">the word you want the freq of</param>
        /// <returns>the frequency as an int</returns>
        private static double CalcFrequency(Dictionary<string,int> dict, string key, int totalWords)
        {
            if(dict.TryGetValue(key,out int value))
            {
                return (double)value / (double)totalWords;
            }
            else
            {
                return -1;
            }
           
        }

        /// <summary>
        /// gets the total words in a dictionary
        /// </summary>
        /// <param name="dict">the dictionary</param>
        /// <returns>an int of the total value</returns>
        private static int GetTotalWords(Dictionary<string,int> dict)
        {
            int wordTotal = 0;

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if(kvp.Key != "")
                {
                    wordTotal = wordTotal + kvp.Value;
                }
                

            }
            return wordTotal;
        }

        /// <summary>
        /// Takes a lot of stuff and echecks if a word falls between the thresholds
        /// </summary>
        /// <param name="TotalUses">total occuences of the checked word</param>
        /// <param name="TotalWords">total words in the file</param>
        /// <param name="LowerThreshold">the lower threshold</param>
        /// <param name="upperThreshold">the upper threshold</param>
        /// <param name="Frequency">an out variable that is set to the frequency of the word</param>
        /// <returns>if the word falls inbetween the threshold</returns>
        private static bool BetweenThreshold(Dictionary<string, double> frequencies, string key, double lowerThreshold, double upperThreshold, out double foundFrequency)
        {
            if (frequencies.TryGetValue(key, out double frequency))
            {
                

                if (lowerThreshold <= frequency && frequency <= upperThreshold)
                {
                    foundFrequency = frequency;
                    return true;

                }
                else
                {
                    foundFrequency = default;
                    return false;
                }
            }
            else
            {
                throw new IOException(); // maby change ex later
            }
                
           

        }
        
    }
}