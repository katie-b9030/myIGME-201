using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Web;

namespace TriviaApp
{
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> trivia;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
