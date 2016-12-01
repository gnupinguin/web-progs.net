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
            Console.WriteLine("Message: {0}", message);
        }
        public void writeAlert(string message)
        {
            Console.WriteLine("Alert: {0}", message);
        }
    }
}
