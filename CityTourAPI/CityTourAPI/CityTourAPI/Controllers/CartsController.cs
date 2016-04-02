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
    public class CartsController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Carts
        [ActionName("GetAll")]
        [HttpGet]
        public IEnumerable<CartDTO> GetCarts()
        {
            return db.Carts.ToList()
                                    .Select(x => ToDTO(x));
        }

        // GET: api/Carts/5
        [ActionName("FindById")]
        [HttpGet]
        [ResponseType(typeof(Cart))]
        public IHttpActionResult GetCart(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(cart));
        }

        // PUT: api/Carts/5
        [ActionName("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart(int id, CartDTO modified)
        {
            if (!CartExists(id))
            {
                return NotFound();
            }

            Cart cart = (from x in db.Carts
                         where x.Id == id
                         select x).First();

            cart.Id = modified.Id;
            cart.CustomerId = modified.CustomerId;


            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Carts
        [ActionName("Create")]
        [HttpPost]
        [ResponseType(typeof(Cart))]
        public IHttpActionResult PostCart(CartDTO cartInfo)
        {
            Cart NewCart = ToEntity(cartInfo);

            db.Carts.Add(NewCart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = NewCart.Id }, NewCart);
        }

        // DELETE: api/Carts/5
        [ActionName("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(Cart))]
        public IHttpActionResult DeleteCart(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            db.SaveChanges();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }

        private CartDTO ToDTO(Cart c)
        {
            return new CartDTO () {
                Id = c.Id,
                CustomerId = c.CustomerId
            };
        }

        private Cart ToEntity (CartDTO c) {
            return new Cart()
            {
                Id = c.Id,
                CustomerId = c.CustomerId
            };
        }
    }
}