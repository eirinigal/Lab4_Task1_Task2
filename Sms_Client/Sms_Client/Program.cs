using SMS_Task2.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sms_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SendSms().Wait();
        }

        //Async method to communicate with the Post API
        private static async Task SendSms()
        {
            //1. Class HTTP Client to talk to restFul API
            HttpClient client = new HttpClient();

            //2.  Base URL for API controller eg. restFull service
            client.BaseAddress = new Uri("http://localhost:52322/");

            //3. Adding a accept header eg. application/json
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            //4. Creating a new entry from the body 
            Sms newSms = new Sms() { ID = 0, SenderNum = "0830492724", RecipientNum = "085783924", Message = "All good?" };

            //5. HTTP response from the GET API -- async call, await suspends until task finished
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Sms", newSms);

            try
            {
                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Sms logged!");

                }
                else
                {
                    Console.WriteLine("Status Code: " + response.StatusCode + "-- ReasonPhrase: " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }


        }
    }
}
