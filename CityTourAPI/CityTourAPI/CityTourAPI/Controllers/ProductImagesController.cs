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
    [RoutePrefix("ProductImages")]
    public class ProductImagesController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/ProductImages
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<ProductImagesDTO> GetProductImages()
        {
            return db.ProductImages.ToList()
                                    .Select(x => ToDTO(x));
        }

        //Get tHumbnails
        [Route ("FindThumbs/{id}")]
        [HttpGet]
        public IEnumerable<ProductImagesDTO> GetThumbNailImages( int id)
        {
            var ProductThumbs = (from x in db.ProductImages
                                 where x.ProductId == id
                                 select new ProductImagesDTO
                                 {
                                     Id = x.Id,
                                     ProductId = x.ProductId,
                                     Url = x.Url
                                 });

            return ProductThumbs;

        }

        // GET: api/ProductImages/5
        [Route("FindById")]
        [HttpGet]
        [ResponseType(typeof(ProductImage))]
        public IHttpActionResult GetProductImage(int id)
        {
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(productImage));
        }

        // PUT: api/ProductImages/5
        [Route("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductImage(int id, ProductImagesDTO modified)
        {
            if (!ProductImageExists(id))
            {
                return NotFound();
            }

            ProductImage prodIm = (from x in db.ProductImages
                                   where x.Id == id
                                   select x).First();

            prodIm.Id = modified.Id;
            prodIm.ProductId = modified.ProductId;
            prodIm.Url = modified.Url;

            //db.Entry(productImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductImages
        [Route("Create")]
        [HttpPost]
        [ResponseType(typeof(ProductImage))]
        public IHttpActionResult PostProductImage(ProductImagesDTO productImageInfo)
        {
            ProductImage newProdIm = ToEntity(productImageInfo);

            db.ProductImages.Add(newProdIm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newProdIm.Id }, newProdIm);
        }

        // DELETE: api/ProductImages/5
        [Route("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(ProductImage))]
        public IHttpActionResult DeleteProductImage(int id)
        {
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return NotFound();
            }

            db.ProductImages.Remove(productImage);
            db.SaveChanges();

            return Ok(productImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductImageExists(int id)
        {
            return db.ProductImages.Count(e => e.Id == id) > 0;
        }

        private ProductImagesDTO ToDTO(ProductImage pi)
        {
            return new ProductImagesDTO()
            {
                Id = pi.Id,
                Url = pi.Url,
                ProductId = pi.ProductId
            };
        }

        private ProductImage ToEntity(ProductImagesDTO pi)
        {
            return new ProductImage()
            {
                Id = pi.Id,
                Url = pi.Url,
                ProductId = pi.ProductId
            };
        }
    }
}