using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using HelloWorldConsole;

namespace HelloWorldAPI.Tests
{
    [TestClass]
    public class ConsoleMessageHandlerTest
    {
        [TestMethod]
        public void WriteMessage_Writes()
        {
            string testMessage = "HelloWorld";

            IHelloWorldMessageHandler messageHandler = new ConsoleMessageHandler();
            StringWriter sWriter = new StringWriter();
            Console.SetOut(sWriter);

            messageHandler.WriteMessage(testMessage);
 
            string messageWritten = sWriter.ToString();

            Assert.IsTrue(messageWritten.Contains(testMessage));
        }
    }
}
