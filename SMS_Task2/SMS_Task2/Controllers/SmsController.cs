using Microsoft.AspNetCore.Mvc;
using SMS_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS_Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        //List of Sms
        private static List<Sms> smsList = new List<Sms>();

        // POST api/<SmsController>
        [HttpPost]
        public string Post([FromBody] Sms sendSms)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    int id;
                    if(smsList.Count == 0)
                    {
                        id = 0;
                    }
                    else
                    {
                        id = smsList[smsList.Count - 1].ID + 1;
                    }
                    Sms newSms = new Sms() { ID=id, SenderNum= sendSms.SenderNum, RecipientNum = sendSms.RecipientNum, Message = sendSms.Message };
                    smsList.Add(newSms);

                    //Writing to a log file
                    string time = DateTime.Now.ToString();

                    StreamWriter sw = new StreamWriter("C:\\Users\\pirin\\log.txt", true);
                    sw.WriteLine("\nTimeStamp: " + time + "\n" + newSms.ToString());
                    sw.Close();


                    return "Sms is logged!";
                }
                else
                {
                    return "Message was not send";
                }

            
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

    }
}
