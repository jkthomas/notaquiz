using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Placeholders
{
    public static class Messenger
    {
        public static string GoodAnswer()
        {
            return "Good answer!";
        }
        public static string BadAnswer()
        {
            return "Bad answer!";
        }
        public static string End()
        {
            return "End of the game";
        }
        public static string Results(string properAmount, string globalAmount)
        {
            return ("Quiz results: " + "You guessed " + properAmount + " questions right, out of " + globalAmount + " questions!");
        }
    }
}
