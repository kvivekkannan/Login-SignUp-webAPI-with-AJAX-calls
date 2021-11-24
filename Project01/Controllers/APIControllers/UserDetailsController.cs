using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Project01.Models;

namespace Project01.Controllers.APIControllers
{
    public class UserDetailsController : ApiController
    {
        private LoginDbContext db = new LoginDbContext();



        // GET: api/UserDetails
        //public IQueryable<UserDetails> Getuserdetails()
        //{
        //    return db.userdetails;
        //}

        //  GET: api/UserDetails
        [Route("api/UserDetails")]
        public IEnumerable<UserDetails> GetUserDetails()
        {
            return db.userdetails.ToList();
        }       


        // GET: api/UserDetails/5
        [ResponseType(typeof(UserDetails))]
        [Route("api/UserDetails/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserDetails(int id)
        {
            UserDetails userDetails = await db.userdetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

        // PUT: api/UserDetails/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutUserDetails(int id, UserDetails userDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userDetails.UserId)
            {
                return BadRequest();
            }

            db.Entry(userDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserDetails
        [ResponseType(typeof(UserDetails))]
        [HttpPost]
        public async Task<IHttpActionResult> PostUserDetails(UserDetails userDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userdetails.Add(userDetails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userDetails.UserId }, userDetails);
        }

        // DELETE: api/UserDetails/5
        [ResponseType(typeof(UserDetails))]
        [HttpPost]
        [Route("api/UserDetails/DeleteUserDetails/{id}")]
        public async Task<IHttpActionResult> DeleteUserDetails(int id)
        {
            UserDetails userDetails = await db.userdetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            db.userdetails.Remove(userDetails);
            await db.SaveChangesAsync();

            return Ok(userDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserDetailsExists(int id)
        {
            return db.userdetails.Count(e => e.UserId == id) > 0;
        }
    }
}