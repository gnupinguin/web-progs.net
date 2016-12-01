using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void testFileLog()
        {
            string path = "C:\\";
            DirectoryInfo currentDir = new DirectoryInfo(path);
            ILog log = new FileLog();
            foreach (var dir in currentDir.EnumerateDirectories())
            {
                log.writeMessage("Dir: " + dir.FullName);
            }
            string content = File.ReadAllText("log.txt");
            Assert.IsTrue(content != null);
        }
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void testConsoleLog()
        {
            ILog log = new ConsoleLog();
            throw new IOException();
            log.writeAlert("Throw Examle Exception :)");
        }
    }
}
