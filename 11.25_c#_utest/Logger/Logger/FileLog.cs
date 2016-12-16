using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public class FileLog: ILog
    {
        //private string pathToLogFile = ;
        private StreamWriter log;
        public FileLog(string pathToLogFile = "log.txt")
        {
            log = new StreamWriter(pathToLogFile);
        }
       
        public void writeMessage(string message)
        {
            //log.WriteLine("Message: {0}", message);
            log.WriteLine(message);
            log.Flush();
        }

        public void writeAlert(string message)
        {
            log.WriteLine("Alert: {0}", message);
            log.Flush();
        }
    }
}
