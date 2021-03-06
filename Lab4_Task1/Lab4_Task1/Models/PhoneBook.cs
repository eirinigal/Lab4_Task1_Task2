﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Lab4_Task1.Models
{
    public class PhoneBook
    {
        //Properties
        [Key]
        public int Number { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        //ToString
        public override string ToString()
        {
            return String.Format("Number: {0} - Name: {1} - Address: {2}", Number, Name, Address);
        }
    }
}
