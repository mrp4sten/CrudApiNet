﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CrudApiSomee.Models;

namespace CrudApiSomee.Controllers
{
    public class ProvidersController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Providers
        public IQueryable<Provider> GetProviders()
        {
            return db.Providers;
        }

        // GET: api/Providers/5
        [ResponseType(typeof(Provider))]
        public IHttpActionResult GetProvider(int id)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            return Ok(provider);
        }

        // PUT: api/Providers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProvider(int id, Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provider.id)
            {
                return BadRequest();
            }

            db.Entry(provider).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
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

        // POST: api/Providers
        [ResponseType(typeof(Provider))]
        public IHttpActionResult PostProvider(Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Providers.Add(provider);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = provider.id }, provider);
        }

        // DELETE: api/Providers/5
        [ResponseType(typeof(Provider))]
        public IHttpActionResult DeleteProvider(int id)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            db.Providers.Remove(provider);
            db.SaveChanges();

            return Ok(provider);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProviderExists(int id)
        {
            return db.Providers.Count(e => e.id == id) > 0;
        }
    }
}