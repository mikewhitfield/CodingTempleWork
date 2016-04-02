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
    [RoutePrefix("CartItems")]
    public class CartItemsController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/CartItems
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<CartItemDTO> GetCartItems()
        {
            var CartItems = (from p in db.Products
                            join c in db.CartItems
                            on p.Id equals c.ProductId
                             select new CartItemDTO
                            {
                                Id = c.Id,
                                ImageUrl = p.ImageUrl,
                                ProductName = p.Name,
                                Total = c.Total
                            }).ToList();

            return CartItems;
        }

        // GET: api/CartItems/5
        [Route ("FindById")]
        [HttpGet]
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult GetCartItem(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(cartItem));
        }

        // PUT: api/CartItems/5
        [Route("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartItem(int id, CartItemDTO modified)
        {
            if (!CartItemExists(id))
            {
                return NotFound();
            }

            CartItem CartI = (from x in db.CartItems
                               where x.Id == id
                               select x).First();

            CartI.Id = modified.Id;
            CartI.CartId = modified.CartId;
            CartI.ProductId = modified.ProductId;
            CartI.Total = modified.Total;
            CartI.Quantity = modified.Quantity;

//            db.Entry(cartItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CartItems
        [Route("Create")]
        [HttpPost]
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult PostCartItem(CartItemDTO cartItemInfo)
        {
            CartItem newCartItem = ToEntity(cartItemInfo);

            db.CartItems.Add(newCartItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newCartItem.Id }, newCartItem);
        }

        // DELETE: api/CartItems/5
        [Route("DeleteById/{id}")]
        [HttpDelete]
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult DeleteCartItem(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            db.CartItems.Remove(cartItem);
            db.SaveChanges();

            return Ok(cartItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartItemExists(int id)
        {
            return db.CartItems.Count(e => e.Id == id) > 0;
        }

        private CartItemDTO ToDTO (CartItem ci)
        {
            return new CartItemDTO()
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                CartId = ci.CartId,
                Total = ci.Total,
                Quantity = ci.Quantity
            };
        }

        private CartItem ToEntity (CartItemDTO ci)
        {
            return new CartItem()
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                CartId = ci.CartId,
                Total = ci.Total,
                Quantity = ci.Quantity
            };
        }
    }
}