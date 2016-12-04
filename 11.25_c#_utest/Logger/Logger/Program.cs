using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*var container = new UnityContainer();
             container.RegisterType<ILog, ConsoleLog>();
             var log1 = container.Resolve<ILog>();
             log1.writeAlert("Hello, World!");       

             container.RegisterType<ILog, FileLog>();
             var log = container.Resolve<ILog>();*/
            ILog log = new FileLog(@"C:\Users\iljap\Documents\Projects\htmls.csv");

            List<string> list = new List<string>();
            string path = @"C:\Users\iljap\Documents\Projects\web-progs.net\";
            getHtmlFiles(path, list);
            foreach(var s in list)
            {
                log.writeMessage(s);
            }

            Console.ReadKey();
        }

        public static void getHtmlFiles(string path, List<string> files)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo currentDir = new DirectoryInfo(path);
                foreach (var dir in currentDir.EnumerateDirectories())
                {
                    //log.writeMessage("Dir: " + dir.FullName);
                    getHtmlFiles(dir.FullName, files);
                }

                foreach(var file in currentDir.EnumerateFiles())
                {
                    //log.writeMessage("File: "+ file.FullName);
                    if (file.FullName.Contains(".html"))
                        files.Add(string.Format("{0};{1};{2};", file.Name,
                            file.DirectoryName, file.CreationTime));
                }

            }
        }
    }
}
