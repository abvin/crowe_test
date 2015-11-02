using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    public interface IHelloWorldMessageHandler
    {
        void WriteMessage(string message);
    }
}
