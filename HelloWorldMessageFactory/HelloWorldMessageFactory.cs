using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Business
{
    public class HelloWorldMessageFactory : IHelloWorldMessageFactory
    {
        private const string MSG_HELLO_WORLD = "Hello beautiful World!";

        /// <summary>
        /// Gets the Hello World message.
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            return MSG_HELLO_WORLD;
        }
    }
}
