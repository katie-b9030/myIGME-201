using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words =
                { "the", "red", "car", "speeds", "away" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            LinkedListNode<string> firstNode = sentence.First;
            sentence.AddLast(firstNode);
        }
    }
}
