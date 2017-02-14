using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputSplitString("The quick brown fox jumped over the lazy dog", 10);
            Console.ReadLine();
        }

        /// <summary>
        /// Parses the words of the input sentence, concatenating them until output string is at most the
        /// length of the provided max length, and writes each concatenation to the console.
        /// </summary>
        /// <param name="input">The string to split up into concatenated parts of the provided max length</param>
        /// <param name="maxLength">The max length of a concatenated string</param>
        private static void OutputSplitString(string input, int maxLength)
        {
            OutputSplitString(input, maxLength, Console.WriteLine);
        }

        /// <summary>
        /// Parses the words of the input sentence, concatenating them until output string is at most the
        /// length of the provided max length, and provides each concatenation via the provided output method.
        /// </summary>
        /// <param name="input">The string to split up into concatenated parts of the provided max length</param>
        /// <param name="maxLength">The max length of a concatenated string</param>
        /// <param name="outputMethod">Function which deals with max length concatenated strings</param>
        private static void OutputSplitString(string input, int maxLength, Action<string> outputMethod)
        {
            // Split the string on the space character so you have the individual words.
            string[] words = input.Split(new char[] { ' ' });

            // Nice name so you can keep your bounds simple
            int indexOfLastWord = words.Length - 1;

            // Start the output with the first word
            string output = words[0];

            // Loop the words, appending them to the output string unless doing so would
            // make the resultant string longer than the provided max; in that case, output
            // what you have and start the next line of output over with the next word in 
            // the array.
            for (int i = 1; i <= indexOfLastWord; i++)
            {
                // If adding the next word to the current string would not make the result
                // exceed the max length, then concatenate.
                int newLength = output.Length + words[i].Length + 1; //1 is for the space

                bool canAppend = (newLength <= maxLength);
                if (canAppend)
                {
                    output += " " + words[i];
                }
                else
                {
                    // Adding the next word (and a space) would have made the output string
                    // too long, so write what you have and start again with the next word.
                    outputMethod(output);
                    output = words[i];
                }
            }

            // In any case, the above will not print out the last buffer of info you have.
            // It's either the last concatenation you did if the last word was short enough,
            // or it's the last word.  Output it.
            outputMethod(output);
        }
    }
}
