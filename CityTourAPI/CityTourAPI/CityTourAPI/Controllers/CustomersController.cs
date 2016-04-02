using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CityTourAPI.Models;


namespace CityTourAPI.Data
{
    public class CustomersController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Customers
        [ActionName("GetAll")]
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return db.Customers.ToList()
                                        .Select(x => ToDTO(x));
        }

        // GET: api/Customers/5
        [ActionName("FindById")]
        [HttpGet]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(customer));
        }

        // PUT: api/Customers/5
        [ActionName("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, CustomerDTO modified)
        {
            if (!CustomerExists(id))
            {
                return NotFound();
            }

            Customer custo = (from x in db.Customers
                              where x.Id == id
                              select x).First();

            custo.Id = modified.Id;
            custo.Name = modified.Name;
            custo.Phone = modified.Phone;
            custo.Email = modified.Email;
            custo.AddressId = modified.AddressId;



            db.Entry(modified).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ActionName("Create")]
        [HttpPost]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(CustomerDTO customerInfo)
        {

            Customer NewCustomer = ToEntity(customerInfo);

            db.Customers.Add(NewCustomer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = NewCustomer.Id }, NewCustomer);
        }

        // DELETE: api/Customers/5
        [ActionName("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

        private CustomerDTO ToDTO(Customer c)
        {
            return new CustomerDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Email = c.Email,
                AddressId = c.AddressId
            };
        }

        private Customer ToEntity(CustomerDTO c)
        {
            return new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Email = c.Email,
                AddressId = c.AddressId
            };
        }
    }
}