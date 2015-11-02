using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HelloWorldConsole
{
    public class Program
    {
        private static IUnityContainer _container;
        
        private static void LoadUnityContainer()
        {
            _container = new UnityContainer().LoadConfiguration();
        }

        public static void Main(string[] args)
        {
            LoadUnityContainer();

            //Creating an async task, for future enhancement of the main program to do more stuff in parallel
            //Start an async task to get the message
            var getMessageTask = GetMessage();


            //Do some stuff here in parallel.


            //Wait for the task to finish
            var message = getMessageTask.Result;

            //Can make this one async too. But there is no need for it in the current design.
            WriteMessage(message);

            Console.ReadKey();
        }


        /// <summary>
        /// Gets the Hello World message.
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetMessage()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("BaseURL"));

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(ConfigurationManager.AppSettings.Get("ApiPath")).Result;

                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    return message;
                }
                else
                {
                    throw new ApplicationException("Could not process this request.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void WriteMessage(string message)
        {
            IHelloWorldMessageHandler messageHandler = _container.Resolve<IHelloWorldMessageHandler>();
            messageHandler.WriteMessage(message);
        }
    }
}
