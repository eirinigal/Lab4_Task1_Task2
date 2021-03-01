using Lab4_Task1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab4_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private static List<PhoneBook> pList = new List<PhoneBook>()
        {
            new PhoneBook(){Number=0839292724, Name="Eirini", Address = "Dublin"},
            new PhoneBook(){Number=0858382955, Name="Dean", Address = "Dublin"},
            new PhoneBook(){Number=0353031461, Name="Sofia", Address = "Greece"},
            new PhoneBook(){Number=0976710037, Name="Eirini", Address = "Greece"}
        };


        // GET: api/<PhoneBookController>
        [HttpGet]
        public List<PhoneBook> Get()
        {
            return pList;
        }

        // GET api/<PhoneBookController>/0858382955
        //Return the name and address of a specified number
        [HttpGet("{number}")]
        public PhoneBook GetNameAddress(int number)
        {
            return pList.SingleOrDefault(pb=> pb.Number== number);
        }

        // GET api/<PhoneBookController>/GetNumbers/Eirini
        //Return numbers and addresses for a specified name 
        [HttpGet("GetNumbers/{name}")]
        public List<PhoneBook> GetNumbers(string name)
        {
            return pList.Where(pb => pb.Name.ToUpper() == name.ToUpper()).Select(pb => pb).ToList();
        }

 
    }
}
