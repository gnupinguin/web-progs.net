using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            int matches = 21;

            while (matches > 1)
            {
                Console.WriteLine("Box has {0} matches", matches);
                Console.WriteLine("You can take 1..{0} matches", matches >= 3?3:2);
                int numUserMatches;
                int.TryParse(Console.ReadLine(), out numUserMatches);
                while (numUserMatches > 3 || numUserMatches < 1)
                {
                    Console.WriteLine("Invalid value. Please repeat");
                    int.TryParse(Console.ReadLine(), out numUserMatches);
                }
                matches -= numUserMatches;
                if (matches == 1)
                {
                    Console.WriteLine("YOU WIN!");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("You toke {0} matches", numUserMatches);
                //int myNumMathes = 1 + new Random().Next(matches > 3?3:2);//if computer choosing random values
                int myNumMatches = 4 - numUserMatches;//for Computer wins
                matches -= myNumMatches;
                Console.WriteLine("I toke {0} mathes", myNumMatches);   
            }
            Console.WriteLine("You lost =(");
            Console.ReadKey();
        }
    }
}
