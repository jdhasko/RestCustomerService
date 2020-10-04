using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCustomerService.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestCustomerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(1, "Ani", "Vlad", DateTime.Today),
            new Customer(2,"Kimon","Kramizas", new DateTime(2019)),
            new Customer(3,"Dominik", "Hasko", new DateTime(2018))
        };


        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> Get()
        {
            return cList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return cList.Find(x => x.Id == id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public bool Post([FromBody] Customer newCustomer)
        {
           newCustomer.Id =  cList.Last().Id + 1;
            cList.Add(newCustomer);
            return true;
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Customer newCustomer)
        {


            for (int i = 0; i < cList.Count; i++)
            {
                if (cList[i].Id == id)
                {
                    cList[i] = newCustomer;
                    return true;
                }
            }
            return false;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          Customer c =  cList.Find(x => x.Id == id);
          cList.Remove(c);
        }
    }
}
