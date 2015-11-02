using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldConsole.Fakes;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.Practices.Unity.Fakes;
using HelloWorld.Business.Fakes;
using HelloWorldAPI.Controllers;
using HelloWorld.Business;

namespace HelloWorldAPI.Tests
{
    [TestClass]
    public class HelloWorldControllerTest
    {
        [TestMethod]
        public void Gets_HelloWorld_Message()
        {
            string testMessage = "Hello";
            bool isMethodInvoked = false;
            using (ShimsContext.Create())
            {
                //Create stub of the message factory interface
                IHelloWorldMessageFactory messageFactory = new StubIHelloWorldMessageFactory()
                {
                    GetMessage = () =>
                                    {
                                        isMethodInvoked = true;
                                        return testMessage;
                                    }
                };

                HelloWorldController controller = new HelloWorldController(messageFactory);
                string message = controller.Get();

                Assert.AreEqual(message, testMessage);
            }
            Assert.IsTrue(isMethodInvoked);
        }
    }
}
