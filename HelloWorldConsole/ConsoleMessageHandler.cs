using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    public class ConsoleMessageHandler: IHelloWorldMessageHandler
    {
        /// <summary>
        /// Writes the message.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }
    }
}
