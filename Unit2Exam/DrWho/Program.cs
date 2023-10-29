using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrWho
{
    /* Class: Phone
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get 
            {
                return phoneNumber;
            }
            set 
            { 
                phoneNumber = value; 
            }
        }

        public abstract void Connect();
        public abstract void Disconnect();
    }

    /* Interface: PhoneInterface
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    /* Class: RotaryPhone
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {
            
        }
    }

    /* Class: PushButtonPhone
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    /* Class: Tardis
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get
            {
                return whichDrWho;
            }
        }

        public string FemaleSideKick
        {
            get
            {
                return femaleSideKick;
            }
        }

        public void TimeTravel()
        {

        }

        public virtual bool Equals(Tardis other)
        {
            if (this.whichDrWho == other.whichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Tardis left, Tardis right)
        {
            if ((right.whichDrWho == 10) || (left.whichDrWho < right.whichDrWho))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Tardis left, Tardis right)
        {
            if ((left.whichDrWho == 10) || (left.whichDrWho > right.whichDrWho))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(Tardis left, Tardis right)
        {
            if ((left.whichDrWho <= right.whichDrWho))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(Tardis left, Tardis right)
        {
            if ((left.whichDrWho >= right.whichDrWho))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    /* Class: PhoneBooth
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {

        }

        public void CloseDoor()
        {

        }
    }

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    internal class Program
    {
        static void UsePhone(object obj)
        {
            try
            {
                PhoneInterface phone = (PhoneInterface)obj;
                phone.MakeCall();
                phone.HangUp();

                if (obj.GetType() == typeof(PhoneBooth))
                {
                    PhoneBooth booth = (PhoneBooth)obj;
                    booth.OpenDoor();
                }

                else if (obj.GetType() == typeof(Tardis))
                {
                    Tardis booth = (Tardis)obj;
                    booth.TimeTravel();
                }
            }
            catch 
            {

            }
        }

        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);
        }
    }
}
