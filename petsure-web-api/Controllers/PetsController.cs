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
using petsure_web_api.Models;
using Newtonsoft.Json;
namespace petsure_web_api.Controllers
{
    [RoutePrefix("api/pets")]
    public class PetsController : ApiController
    {
        private petsureEntities db = new petsureEntities();

        // GET: api/Pets
        [HttpGet]
        [Route("getpets")]
        [ResponseType(typeof(petsTable))]
        public HttpResponseMessage GetpetsTables()
        {
            var serializedata = JsonConvert.SerializeObject(db.petsTables.ToList());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializedata);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }
        [HttpGet]
        [Route("petlist")]
        [ResponseType(typeof(petsTable))]
        public IQueryable GetPetsTables() {
            return db.petsTables;
        }
        // GET: api/Pets/5
        [ResponseType(typeof(petsTable))]
        public async Task<IHttpActionResult> GetpetsTable(int id)
        {
            petsTable petsTable = await db.petsTables.FindAsync(id);
            if (petsTable == null)
            {
                return NotFound();
            }

            return Ok(petsTable);
        }

        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutpetsTable(int id, petsTable petsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petsTable.Id)
            {
                return BadRequest();
            }

            db.Entry(petsTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!petsTableExists(id))
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

        // POST: api/Pets
        [ResponseType(typeof(petsTable))]
        public async Task<IHttpActionResult> PostpetsTable(petsTable petsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.petsTables.Add(petsTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = petsTable.Id }, petsTable);
        }

        // DELETE: api/Pets/5
        [ResponseType(typeof(petsTable))]
        public async Task<IHttpActionResult> DeletepetsTable(int id)
        {
            petsTable petsTable = await db.petsTables.FindAsync(id);
            if (petsTable == null)
            {
                return NotFound();
            }

            db.petsTables.Remove(petsTable);
            await db.SaveChangesAsync();

            return Ok(petsTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool petsTableExists(int id)
        {
            return db.petsTables.Count(e => e.Id == id) > 0;
        }
    }
}