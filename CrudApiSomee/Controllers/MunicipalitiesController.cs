using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CrudApiSomee.Models;
using CrudApiSomee.Services;

namespace CrudApiSomee.Controllers
{
    public class MunicipalitiesController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Municipalities
        MunicipalityService municipalityService = new MunicipalityService();
        [HttpGet]
        public List<Municipality> Index()
        {
            return municipalityService.EntityList();
        }

        // GET: api/Municipalities/5
        [ResponseType(typeof(Municipality))]
        public IHttpActionResult GetMunicipality(int id)
        {
            Municipality municipality = db.Municipalities.Find(id);
            if (municipality == null)
            {
                return NotFound();
            }

            return Ok(municipality);
        }

        // PUT: api/Municipalities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMunicipality(int id, Municipality municipality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != municipality.id)
            {
                return BadRequest();
            }

            db.Entry(municipality).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipalityExists(id))
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

        // POST: api/Municipalities
        [ResponseType(typeof(Municipality))]
        public IHttpActionResult PostMunicipality(Municipality municipality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Municipalities.Add(municipality);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = municipality.id }, municipality);
        }

        // DELETE: api/Municipalities/5
        [ResponseType(typeof(Municipality))]
        public IHttpActionResult DeleteMunicipality(int id)
        {
            Municipality municipality = db.Municipalities.Find(id);
            if (municipality == null)
            {
                return NotFound();
            }

            db.Municipalities.Remove(municipality);
            db.SaveChanges();

            return Ok(municipality);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MunicipalityExists(int id)
        {
            return db.Municipalities.Count(e => e.id == id) > 0;
        }
    }
}