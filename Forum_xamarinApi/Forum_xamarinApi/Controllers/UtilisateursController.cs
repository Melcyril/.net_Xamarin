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
using Forum_xamarinApi.Models;

namespace Forum_xamarinApi.Controllers
{
    public class UtilisateursController : ApiController
    {
        private MasterCodeEntities db = new MasterCodeEntities();
        //Token cryptage = new Token();


        // GET: api/Utilisateurs
        public IQueryable<Utilisateur> GetUtilisateur()
        {
            //vérifier le token
            string token = Token.Create();
            string verif = Token.Decrypt(token);
            bool reponse;
            reponse = Token.Verify(token);
            return db.Utilisateur;
        }

        public string GetUtilisateur(string texte)
        {
            string token = Token.Create();

            string verif = Token.Decrypt(token);         

            bool reponse;
            reponse = Token.Verify(token);
            return token + "::" + verif + "::" + reponse;
        }

        // GET: api/Utilisateurs/5
        [ResponseType(typeof(Utilisateur))]
        public async Task<IHttpActionResult> GetUtilisateur(int id)
        {
            Utilisateur utilisateur = await db.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return Ok(utilisateur);
        }

        // PUT: api/Utilisateurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilisateur.IdUtilisateur)
            {
                return BadRequest();
            }

            db.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
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

        // POST: api/Utilisateurs
        [ResponseType(typeof(Utilisateur))]
        public async Task<IHttpActionResult> PostUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string token = Token.Create();
            string tokenDecrypt = Token.Decrypt(token);
            bool reponse;
            reponse = Token.Verify(token);

            if (reponse == true)
            {
                utilisateur.DateCreation = DateTime.Now;

                db.Utilisateur.Add(utilisateur);
                await db.SaveChangesAsync();
            }            

            return CreatedAtRoute("DefaultApi", new { id = utilisateur.IdUtilisateur }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [ResponseType(typeof(Utilisateur))]
        public async Task<IHttpActionResult> DeleteUtilisateur(int id)
        {
            Utilisateur utilisateur = await db.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            db.Utilisateur.Remove(utilisateur);
            await db.SaveChangesAsync();

            return Ok(utilisateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UtilisateurExists(int id)
        {
            return db.Utilisateur.Count(e => e.IdUtilisateur == id) > 0;
        }

        
        // Connexion utilisateur
        [ResponseType(typeof(Utilisateur))]
        public bool Connexion_utilisateur(string Email, string MotDePasse)
        {
            Utilisateur utilisateur = new Utilisateur();
            String token = Token.Create();
            string tokendecrypt = Token.Decrypt(token);
            bool reponse;
            reponse = Token.Verify(token);

            if (reponse == true)
            {
                var idUtilisateur = db.Utilisateur.Count(u => u.Email == Email && u.MotdePasse == MotDePasse);
                if (idUtilisateur > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }                      
            else
            {
                return false;
            }
        }                    

    }
}