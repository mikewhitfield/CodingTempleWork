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
    public class AddressesController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Addresses
        [ActionName("GetAll")]
        [HttpGet]
        public IEnumerable<AddressDTO> GetAddresses()
        {
            return db.Addresses.ToList()
                              .Select(x => ToDTO(x));
        }

        // GET: api/Addresses/5
        [ActionName("FindById")]
        [HttpGet]
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(address));
        }

        // PUT: api/Addresses/5
        [ActionName("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, AddressDTO modified)
        {

            if (!AddressExists(id))
            {
                return NotFound();
            }

            Address Addr = (from a in db.Addresses
                                where a.Id == id
                                select a).First();

            Addr.Address1 = modified.Address1;
            Addr.Address2 = modified.Address2;
            Addr.City = modified.City;
            Addr.Country = modified.Country;
            Addr.State = modified.State;
            Addr.Zipcode = modified.Zipcode;



            //db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ActionName("Create")]
        [HttpPost]
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(AddressDTO addressInfo)
        {

            Address NewAddress = ToEntity(addressInfo);

            db.Addresses.Add(NewAddress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = NewAddress.Id }, NewAddress);
        }

        // DELETE: api/Addresses/5
        [ActionName ("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.Id == id) > 0;
        }

        private AddressDTO ToDTO(Address a)
        {
            return new AddressDTO()
            {
                Id = a.Id,
                Address1 = a.Address1,
                Address2 = a.Address2,
                City = a.City,
                State = a.State,
                Zipcode = a.Zipcode,
                Country = a.Country
            };
        }

        private Address ToEntity (AddressDTO a)
        {
            return new Address ()
            {
                Id = a.Id,
                Address1 = a.Address1,
                Address2 = a.Address2,
                City = a.City,
                State = a.State,
                Zipcode = a.Zipcode,
                Country = a.Country

            };
        }

    }
}