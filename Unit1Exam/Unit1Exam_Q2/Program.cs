using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Exam_Q2
{
    internal class Program
    {
        // CODE COPY-PASTED AND MODIFIED FROM NUMBERSORTV2.CS
        // the definition of the delegate function data type
        delegate string sortingFunction(string[] a);

        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            string[] sUnsorted;
            string[] sSorted;

            // declare the delegate variable which will point to the function to be called
            sortingFunction findHiLow;

        // a label to allow us to easily loop back to the start if there are input issues
        // MODIFIED FOR STRINGS
        start:
            Console.WriteLine("Enter a string: ");

            // read the space-separated string of words
            string sWords = Console.ReadLine();

            // split the string into the an array of strings which are the individual words
            string[] sWord = sWords.Split(' ');

            // initialize the size of the unsorted array to 0
            int nUnsortedLength = 0;

            // STRING DOESN'T NEED TO BE PARSED

            // set nUnsortedLength back to the number of words in the string array
            foreach (string sThisWord in sWord)
            {
                // skip the blank strings
                if (sThisWord.Length != 0)
                {
                    // increment the array index
                    nUnsortedLength++;
                }
            }

            // use nUnsortedLength to only store the non-blank strings in the unsorted array
            sUnsorted = new string[nUnsortedLength];
            int index = 0;
            foreach (string sThisWord in sWord)
            {
                // still skip the blank strings
                if (sThisWord.Length != 0)
                {
                    // increment the array index
                    sUnsorted[index] = sThisWord;
                    index ++;
                }
            }



            // allocate the size of the sorted array
            sSorted = new string[nUnsortedLength];

            // prompt for <a>scending or <d>escending
            Console.Write("Ascending or Descending? ");
            string sDirection = Console.ReadLine();

            if (sDirection.ToLower().StartsWith("a"))
            {
                findHiLow = new sortingFunction(FindLowestValue);
            }
            else
            {
                findHiLow = new sortingFunction(FindHighestValue);
            }

            // start the sorted length at 0 to use as sorted index element
            int nSortedLength = 0;

            // while there are unsorted values to sort
            while (sUnsorted.Length > 0)
            {
                // store the lowest or highest unsorted value as the next sorted value
                sSorted[nSortedLength] = findHiLow(sUnsorted);

                // remove the current sorted value
                RemoveUnsortedValue(sSorted[nSortedLength], ref sUnsorted);

                // increment the number of values in the sorted array
                ++nSortedLength;
            }

            // write the sorted array of words
            Console.WriteLine("The sorted list is: ");
            foreach (string thisWord in sSorted)
            {
                Console.Write($"{thisWord} ");
            }

            Console.WriteLine();
        }

        // find the lowest value in the array of words
        static string FindLowestValue(string[] array)
        {
            // define return value
            string returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (string thisWord in array)
            {
                // if the current value is less than the saved lowest value
                if (thisWord.CompareTo(returnVal) < 0)
                {
                    // save this as the lowest value
                    returnVal = thisWord;
                }
            }

            // return the lowest value
            return (returnVal);
        }

        // find the highest value in the array of words
        static string FindHighestValue(string[] array)
        {
            // define return value
            string returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (string thisWord in array)
            {
                // if the current value is less than the saved lowest value
                if (thisWord.CompareTo(returnVal) > 0)
                {
                    // save this as the lowest value
                    returnVal = thisWord;
                }
            }

            // return the highest value
            return (returnVal);
        }


        // remove the first instance of a value from an array
        static void RemoveUnsortedValue(string removeValue, ref string[] array)
        {
            // allocate a new array to hold 1 less value than the source array
            string[] newArray = new string[array.Length - 1];

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0;

            // the same value may occur multiple times in the array, so skip subsequent occurrences
            bool bAlreadyRemoved = false;

            // iterate through the source array
            foreach (string srcWord in array)
            {
                // if this is the word to be removed and we didn't remove it yet
                if (srcWord == removeValue && !bAlreadyRemoved)
                {
                    // set the flag that it was removed
                    bAlreadyRemoved = true;

                    // and skip it (ie. do not add it to the new array)
                    continue;
                }

                // insert the source word into the new array
                newArray[dest] = srcWord;

                // increment the new array index to insert the next word
                ++dest;
            }

            // set the ref array equal to the new array, which has the target word removed
            // this changes the variable in the calling function (aUnsorted in this case)
            array = newArray;
        }

    }
}
