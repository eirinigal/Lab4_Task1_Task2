using Lab4_Task1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab4_Task1_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetListOfNameAddress().Wait();
            Console.WriteLine();

            GetNameAddress().Wait();


        }


        //Async methods to communicate with the RestFul APIs
        //GET api/<PhoneBookController>/GetNumbers/Eirini
        private static async Task GetListOfNameAddress()
        {
            try 
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://localhost:60661/");

                //3. Adding a accept header eg. application/json
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //4. HTTP response from the GET API -- async call, await suspends until task finished
                HttpResponseMessage response = await client.GetAsync("api/PhoneBook/GetNumbers/Eirini");

                response.EnsureSuccessStatusCode();
                List<PhoneBook> pList = await response.Content.ReadAsAsync<List<PhoneBook>>();

                foreach (PhoneBook pb in pList)
                {
                    Console.WriteLine("\n" + pb.ToString());
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }



        //GET api/<PhoneBookController>/0858382955
        private static async Task GetNameAddress()
        {
            try
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://localhost:60661/");

                //3. Adding a accept header eg. application/json
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //4. HTTP response from the GET API -- async call, await suspends until task finished
                HttpResponseMessage response = await client.GetAsync("api/PhoneBook/0858382955");

                response.EnsureSuccessStatusCode();
                PhoneBook pb = await response.Content.ReadAsAsync<PhoneBook>();

                Console.WriteLine("\n" + pb.ToString());
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }
    }
}
