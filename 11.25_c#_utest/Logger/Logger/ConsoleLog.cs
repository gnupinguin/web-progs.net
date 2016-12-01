using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLog:ILog
    {
        public void writeMessage(string message)
        {
            ConsoleColor oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Message: {0}", message);
            Console.Out.Flush();
            Console.BackgroundColor = oldColor;
        }
        public void writeAlert(string message)
        {
            ConsoleColor oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Alert: {0}", message);
            Console.Out.Flush();
            Console.BackgroundColor = oldColor;
        }
    }
}
