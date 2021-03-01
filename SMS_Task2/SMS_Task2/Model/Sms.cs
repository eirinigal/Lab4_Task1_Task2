using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Task2.Model
{
    public class Sms
    {
        //Properties
        [Key]
        public int ID { get; set; }

        public string SenderNum { get; set; }
        public string RecipientNum { get; set; }

        [MaxLength(140, ErrorMessage ="Max 140 characters")]
        public string Message { get; set; }

        //Override ToString()
        public override string ToString()
        {
            return String.Format("SMS Details \nFrom: {0} \nTo: {1} \nMessage: {2}", SenderNum, RecipientNum, Message);
        }
    }
}
