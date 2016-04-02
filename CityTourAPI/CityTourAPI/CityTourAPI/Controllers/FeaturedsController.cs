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
    [RoutePrefix("Featured")]

    public class FeaturedsController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Featureds
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<FeaturedDTO> GetFeatureds()
        {
            var FeaturedProd = (from e in db.Featureds
                                join p in db.Products
                                on e.ProductId equals p.Id
                                join c in db.Categories
                                on p.CategoryId equals c.Id
                                select new FeaturedDTO
                                {
                                    Id = e.Id,
                                    ProductId = e.Id,
                                    CatagoryName = c.Name,
                                    ImageUrl = p.ImageUrl,
                                    Name = p.Name,
                                    Latitude = p.Latitude,
                                    Longitude = p.Longitude,
                                    Price  = p.Price,
                                    Summary = p.Summary,
                                    ProdId = p.Id
                                }).ToList();

            return FeaturedProd;
        }



        // GET: api/Featureds/5
        [Route("FindById")]
        [HttpGet]
        [ResponseType(typeof(Featured))]
        public IHttpActionResult GetFeatured(int id)
        {
            Featured featured = db.Featureds.Find(id);
            if (featured == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(featured));
        }

        // PUT: api/Featureds/5
        [Route("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeatured(int id, FeaturedDTO modified)
        {
            if (!FeaturedExists(id))
            {
                return NotFound();
            }

            Featured thisFeature = (from x in db.Featureds
                                    where x.Id == id
                                    select x).First();

            thisFeature.Id = modified.Id;
            thisFeature.ProductId = modified.ProductId;

            //db.Entry(featured).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Featureds
        [Route("Create")]
        [HttpPost]
        [ResponseType(typeof(Featured))]
        public IHttpActionResult PostFeatured(FeaturedDTO featuredInfo)
        {
            Featured NewFeatured = ToEntity(featuredInfo);

            db.Featureds.Add(NewFeatured);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = NewFeatured.Id }, NewFeatured);
        }

        // DELETE: api/Featureds/5
        [Route("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(Featured))]
        public IHttpActionResult DeleteFeatured(int id)
        {
            Featured featured = db.Featureds.Find(id);
            if (featured == null)
            {
                return NotFound();
            }

            db.Featureds.Remove(featured);
            db.SaveChanges();

            return Ok(featured);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeaturedExists(int id)
        {
            return db.Featureds.Count(e => e.Id == id) > 0;
        }

        private FeaturedDTO ToDTO(Featured f)
        {
            return new FeaturedDTO()
            {
                Id = f.Id,
                ProductId = f.ProductId                
            };
        }

        private Featured ToEntity (FeaturedDTO f)
        {
            return new Featured()
            {
                Id = f.Id,
                ProductId = f.ProductId
            };

        }
    }
}