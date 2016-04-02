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
    [RoutePrefix("Products")] //replaces api/products in the route

    public class ProductsController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Products
        [Route("GetAll")] // Added because these are custom functions now
        [HttpGet] // Added because these are custom functions now
        public IEnumerable<ProductDTO> GetProducts()
        {
            var Products = (from e in db.Products
                                join c in db.Categories
                                on e.CategoryId equals c.Id
                                select new ProductDTO
                                {
                                    Id = e.Id,
                                    CatagoryName = c.Name,
                                    ImageUrl = e.ImageUrl,
                                    Name = e.Name,
                                    Latitude = e.Latitude,
                                    Longitude = e.Longitude,
                                    Marker = e.Marker,
                                    Price = e.Price,
                                    Summary = e.Summary
                                }).ToList();

            return Products;
        }

        [Route("FindByName")]
        [HttpGet]
        public IEnumerable<ProductDTO> GetProductByName(string name)
        {
            return db.Products.Where(x => x.Name == name)
                                    .ToList().Select(x => ToDTO(x));
        }

        // GET: api/Products/5
        [Route("FindById/{id}")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(product));
        }

        //[Route("api/products/{id:int}/category/{categoryId:int}")] used for validation (if the signatures dont match)
        [Route("{id}/category/{categoryId}", Name = "FindByCategoryId")]
        [ActionName("FindByCategoryId")]
        [HttpGet]
        [ResponseType(typeof(ProductDTO))]
        public ProductDTO getProductByIdAndCategoryId(int id, int CategoryId)
        {
            return db.Products.Where(x => x.Id == id && x.CategoryId == CategoryId)
                     .ToList()
                     .Select(x => ToDTO(x))
                     .FirstOrDefault();
        }

        // PUT: api/Products/5
        [Route("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, ProductDTO modified)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }

            Product product = (from x in db.Products
                               where x.Id == id
                               select x).First();

            product.Id = modified.Id;
            product.ImageUrl = modified.ImageUrl;
            product.Price = modified.Price;
            product.Name = modified.Name;


            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [Route("Create")]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(ProductDTO productInfo)
        {
            Product prod = ToEntity(productInfo);

            db.Products.Add(prod);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prod.Id }, prod);
        }

        // DELETE: api/Products/5
        [Route("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }

        private ProductDTO ToDTO(Product p)
        {
            return new ProductDTO()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price,
                Summary = p.Summary,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                Marker = p.Marker
            };
        }

        private Product ToEntity(ProductDTO p)
        {
            return new Product()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price,
                Summary = p.Summary,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                Marker = p.Marker
            };

        }

    }
}