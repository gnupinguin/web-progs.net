using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILog
    {
        void writeMessage(string message);
        void writeAlert(string message);
    }
}
