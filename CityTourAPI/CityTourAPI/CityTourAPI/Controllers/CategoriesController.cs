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
    public class CategoriesController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Categories
        [ActionName("GetAll")]
        [HttpGet]
        public IEnumerable<CategoryDTO> GetCategories()
        {
            return db.Categories.ToList()
                                .Select(x => ToDTO(x));
        }

        // GET: api/Categories/5
        [ActionName("FindById")]
        [HttpGet]
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(category));
        }

        // PUT: api/Categories/5
        [ActionName("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, CategoryDTO category)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }

            Category catUpdatable = (from x in db.Categories
                                 where x.Id == id
                                 select x).FirstOrDefault();

            catUpdatable.Id = category.Id;
            catUpdatable.Name = category.Name;




            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ActionName("Create")]
        [HttpPost]
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(CategoryDTO categoryInfo)
        {
          
            Category NewCategory = ToEntity(categoryInfo);

            db.Categories.Add(NewCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoryInfo.Id }, categoryInfo);
        }

        // DELETE: api/Categories/5
        [ActionName("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }

        private CategoryDTO ToDTO (Category c)
        {
            return new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name
            };
        }

        private Category ToEntity (CategoryDTO c)
        {
            return new Category()
            {
                Id = c.Id,
                Name = c.Name
            };
        }
    }
}