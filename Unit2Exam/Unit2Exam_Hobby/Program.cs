using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2Exam_Hobby
{
    public interface PlaySong
    {
        void Play();
        void Stop();
    }

    public interface Instrument
    {
        void Repair();
        void Tune();
    }

    public abstract class Stringed : PlaySong, Instrument
    {
        private int numStrings;
        public bool usesBow;
        public bool usesPick;
        public bool isTuned;
        public bool needsRepairs;

        public int NumStrings
        {
            get 
            { 
                return numStrings; 
            }
        }

        public virtual void Play()
        {
            Console.WriteLine("You are playing a song!");
        }

        public virtual void Stop()
        {
            Console.WriteLine("You stopped playing the song.");
        }

        public void Repair()
        {
            Console.WriteLine("Your stringed instrument is fixed!");
        }

        public abstract void Tune();

        public Stringed()
        {

        }

        public Stringed(int numStrings, bool usesBow, bool usesPick)
        {
            this.numStrings = numStrings;
            this.usesBow = usesBow;
            this.usesPick = usesPick;
            this.isTuned = false;
            this.needsRepairs = false;
        }
    }

    public class Guitar : Stringed
    {
        public bool isElectric;

        public override void Tune()
        {
            Console.WriteLine("All " + this.NumStrings + " strings of your guitar are tuned to perfection!");
        }

        public Guitar(): base(6, false, true)
        {
            
        }

        public Guitar(bool isElectric, int numStrings) : base(numStrings, false, true)
        {
            this.isElectric = isElectric;
        }
    }

    public class Violin : Stringed
    { 

        public override void Tune()
        {
            Console.WriteLine("All " + this.NumStrings + " strings of your violin are tuned to perfection!");
        }

        public Violin() : base(4, true, false)
        {

        }

        public Violin(int numStrings) : base(numStrings, true, false)
        {

        }
    }

    internal class Program
    {
        static void MyMethod(object obj)
        {
            try
            {
                Instrument instrument = (Instrument)obj;
                instrument.Repair();
                if (obj.GetType() == typeof(Guitar))
                {
                    Guitar guitar = (Guitar)obj;
                    guitar.Tune();
                }
                else if (obj.GetType() == typeof(Violin))
                {
                    Violin violin = (Violin)obj;
                    violin.Tune();
                }
            }
            catch
            {

            }
        }

        static void Main(string[] args)
        {
            Guitar guitar = new Guitar();
            Violin violin = new Violin();

            MyMethod(guitar);
            MyMethod(violin);
        }
    }
}
