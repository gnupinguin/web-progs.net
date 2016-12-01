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
            var container = new UnityContainer();
            container.RegisterType<ILog, ConsoleLog>();
            var log1 = container.Resolve<ILog>();
            log1.writeAlert("Hello, World!");         

            container.RegisterType<ILog, FileLog>();
            var log2 = container.Resolve<ILog>();

            getTree("C:\\Users\\iljap\\Documents\\My Web Sites", log2);

            Console.ReadKey();
        }

        public static void getTree(string path, ILog log)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo currentDir = new DirectoryInfo(path);
                foreach (var dir in currentDir.EnumerateDirectories())
                {
                    log.writeMessage("Dir: " + dir.FullName);
                    getTree(dir.FullName, log);
                }

                foreach(var file in currentDir.EnumerateFiles())
                {
                    log.writeMessage("File: "+ file.FullName);
                }

            }
        }
    }
}
