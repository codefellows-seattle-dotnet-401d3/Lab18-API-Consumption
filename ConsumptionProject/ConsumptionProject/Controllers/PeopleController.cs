using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConsumptionProject.Models;

namespace ConsumptionProject.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();


        public PeopleController()
        {
            people.Add(new Person { FirstName = "Tiger", LastName = "H", Id = 1 });
        }

        
        // GET: api/People//passes all persons
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5/passes all personswith.ID
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
