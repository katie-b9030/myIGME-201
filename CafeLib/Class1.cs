using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    /* Interface: IMood
     * Purpose: defines read-only Method mood
     * Restrictions: None
     */
    public interface IMood
    {
        string Mood
        {
            get;
        }
    }

    /* Interface: ITakeOrder
     * Author: Katie Bogart
     * Purpose: defines TakeOrder()
     * Restrictions: None
     */
    public interface ITakeOrder
    {
        void TakeOrder();
    }

    /* Class: HotDrink
     * Author: Katie Bogart
     * Purpose: define basic fields/methods that may be used by a HotDrink
     * Restrictions: None
     */
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {

        }

        public abstract void Steam();

        public HotDrink()
        {

        }

        public HotDrink(string brand)
        {

        }
    }

    /* Class: Waiter
     * Author: Katie Bogart
     * Purpose: defines methods for a waiter to use
     * Restrictions: None
     */
    public class Waiter : IMood
    {
        public string name;

        string IMood.Mood
        {
            get
            {
                return "";
            }
        }

        public void ServeCustomer(HotDrink cup)
        {

        }
    }

    /* Class: Customer
     * Author: Katie Bogart
     * Purpose: defines fields an methods for a customer
     * Restrictions: None
     */
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        string IMood.Mood
        {
            get
            {
                return "";
            }
        }
    }

    /* Class: CupOfCoffee
     * Author: Katie Bogart
     * Purpose: defines fields and methods that could relate to a cup of coffee
     * Restrictions: None
     */
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }

        public CupOfCoffee(string brand) : base(brand)
        {

        }
    }

    /* Class: CupOfTea
     * Author: Katie Bogart
     * Purpose: defines fields and methods that could relate to a cup of coffee
     * Restrictions: None
     */
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public override void Steam()
        {

        }

        public void TakeOrder()
        {

        }

        public CupOfTea(bool customerIsWealthy)
        {

        }
    }

    /* Class: CupOfCocoa
     * Author: Katie Bogart
     * Purpose: defines fields and methods that could relate to a cup of coffee
     * Restrictions: None
     */
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        string Source
        {
            set
            {
                source = value;
            }
        }

        public override void Steam()
        {

        }

        public override void AddSugar(byte amount)
        {
            base.AddSugar(amount);
        }

        public void TakeOrder()
        {

        }

        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base ("Expensive Organic Brand")
        {

        }
    }
}
