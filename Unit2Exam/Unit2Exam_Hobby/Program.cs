using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2Exam_Hobby
{
    /* Interface: PlaySong
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public interface PlaySong
    {
        void Play();
        void Stop();
    }

    /* Interface: Instrument
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public interface Instrument
    {
        void Repair();
        void Tune();
    }

    /* Class: Stringed
     * Author: Katie Bogart
     * Purpose: sets up the framework for a stringed instrument
     * Restrictions: None
     */
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

    /* Class: Guitar
     * Author: Katie Bogart
     * Purpose: Creates an instance of a Guitar
     * Restrictions: None
     */
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

    /* Class: Violin
     * Author: Katie Bogart
     * Purpose: Creates an instance of a Violin
     * Restrictions: None
     */
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

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: Establishes MyMethod and Main
     * Restrictions: None
     */
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
