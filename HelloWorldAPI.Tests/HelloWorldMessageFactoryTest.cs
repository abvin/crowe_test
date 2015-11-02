using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Business;

namespace HelloWorldAPI.Tests
{
    [TestClass]
    public class HelloWorldMessageFactoryTest
    {
        [TestMethod]
        public void GetMessage_Returns_NonEmptyString()
        {
            HelloWorldMessageFactory messageFactory = new HelloWorldMessageFactory();
            var message = messageFactory.GetMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
    }
}
