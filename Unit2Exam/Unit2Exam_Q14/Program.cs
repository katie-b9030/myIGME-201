using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2Exam_Q14
{

    /* Class: Friend
     * Author: Katie Bogart
     * Purpose: creates a friend
     * Restrictions: None
     */
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;

        public Friend()
        {

        }

        public Friend(Friend friend)
        {
            this.name = friend.name;
            this.greeting = friend.greeting;
            this.birthdate = friend.birthdate;
            this.address = friend.address;
        }
    }

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: Establishes the main
     * Restrictions: None
     */
    class Program
    {

        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy;

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            enemy = new Friend(friend);

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }

}
