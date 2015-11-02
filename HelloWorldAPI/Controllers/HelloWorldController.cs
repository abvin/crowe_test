using HelloWorld.Business;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorldAPI.Controllers
{
    public class HelloWorldController : ApiController
    {
        private IHelloWorldMessageFactory _messageFactory;
        public HelloWorldController(IHelloWorldMessageFactory messageFactory)
        {
            //Message Factory type is resolved using the Unity.config
            _messageFactory = messageFactory;
        }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        public string Get()
        {
            try
            {
                //Get the HelloWorld message using the factory instance that's configured in the Unity.config
                string message = _messageFactory.GetMessage();
                return message;
            }
            catch(Exception ex)
            {
                //Log ex
                throw new HttpResponseException(HttpStatusCode.InternalServerError); 
            }

        }
    }
}
