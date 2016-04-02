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
    public class UsersController : ApiController
    {
        private CityTourContainer db = new CityTourContainer();

        // GET: api/Users
        [ActionName("GetAll")]
        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return db.Users.ToList()
                                    .Select(x => ToDTO(x));
        }

        // GET: api/Users/5
        [ActionName("FindById")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(ToDTO(user));
        }

        // PUT: api/Users/5
        [ActionName("UpdateById")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDTO modified)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            
            User  UserContent = (from x in db.Users
                                where x.Id == id
                                select x).First();

            UserContent.Id = modified.Id;
            UserContent.Email = modified.Email;
            UserContent.Password = modified.Password;
            UserContent.Username = modified.Username;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ActionName("Create")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(UserDTO userInfo)
        {
            User newUser = ToEntity(userInfo);

            db.Users.Add(newUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newUser.Id }, newUser);
        }

        // DELETE: api/Users/5
        [ActionName("DeleteById")]
        [HttpDelete]
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }

        private UserDTO ToDTO(User u)
        {
            return new UserDTO()
            {
                Id = u.Id,
                Username = u.Username,
                Password = u.Password,
                Email = u.Email,
                CustomerId = u.CustomerId
            };
        }

        private User ToEntity(UserDTO u)
        {
            return new User()
            {
                Id = u.Id,
                Username = u.Username,
                Password = u.Password,
                Email = u.Email,
                CustomerId = u.CustomerId
            };
        }
    }
}