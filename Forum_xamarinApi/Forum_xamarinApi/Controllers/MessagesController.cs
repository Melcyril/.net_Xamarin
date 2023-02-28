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
    public class MessagesController : ApiController
    {
        private MasterCodeEntities db = new MasterCodeEntities();
        List<Message> messages = new List<Message>();


        // GET: api/Messages
        public IQueryable<Message> GetMessage()
        {
            return db.Message;
        }

        // GET: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> GetMessage(int id)
        {
            Message message = await db.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.IdMessage)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Message.Add(message);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = message.IdMessage }, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> DeleteMessage(int id)
        {
            Message message = await db.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Message.Remove(message);
            await db.SaveChangesAsync();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return db.Message.Count(e => e.IdMessage == id) > 0;
        }


        // Afficher les messages d'un utilisateurs
        public async Task<List<MessagesForum>> GetMessage(int idForum, string global, string flag)
        {
            List<Message> messages = await (from m in db.Message where m.IdForum == idForum orderby m.DatePublication descending select m).ToListAsync();
            if (messages == null)
            {
                return null;
            }
            List<MessagesForum> listeMessages = new List<MessagesForum>();


            foreach (Message item in messages)
            {
                MessagesForum messageForum = new MessagesForum();
                messageForum.IdMessage = item.IdMessage;
                messageForum.IdForum = item.IdForum;
                //messageForum.IdMessageParent = item.IdMessageParent;
                messageForum.TypeStatutMessage = item.Statut.typeStatut;
                messageForum.IdAuteur = item.IdAuteur;
                messageForum.AuteurAvatar = "https://reseaudentreprise.com//images/profils/profil.jpg";
                try
                {
                    messageForum.AuteurAvatar = (from m in db.Media where m.IdAuteur == item.IdAuteur && m.TypeMedia.Type == "Avatar" orderby m.IdMedia descending select m.Chemin).First();
                }
                catch (Exception)
                {
                }

                messageForum.Texte = item.Texte;
                messageForum.DatePublication = item.DatePublication;
                Utilisateur utilisateur = (from u in db.Utilisateur where u.IdUtilisateur == item.IdAuteur select u).First();
                messageForum.AuteurEmail = utilisateur.Email;
                messageForum.AuteurPseudo = utilisateur.Pseudo;
                messageForum.AuteurAcces = utilisateur.Acces.typeAcces;
                messageForum.AuteurStatut = utilisateur.Statut.typeStatut;
                // messageForum.AuteurTrophee = utilisateur.Trophee.typeTrophee;
                messageForum.AuteurPopularite = utilisateur.Popularite;


                int numLike = 0;

                try
                {
                    numLike = (from l in db.Like where l.IdMessage == item.IdMessage select l).Count();
                }
                catch (Exception)
                {
                }

                messageForum.NumLikeMessage = numLike;
                listeMessages.Add(messageForum);
            }
            return listeMessages;
        }
    }
}