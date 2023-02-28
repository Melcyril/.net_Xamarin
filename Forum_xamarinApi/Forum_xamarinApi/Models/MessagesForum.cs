using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_xamarinApi.Models
{
    public class MessagesForum
    {
        public int IdMessage { get; set; }
        //public Nullable IdMessageParent { get; set; }
        public int IdForum { get; set; }
        public string Texte { get; set; }
        public int PopulariteMessage { get; set; }
        public string TypeStatutMessage { get; set; }
        public int NumLikeMessage { get; set; }
        public System.DateTime DatePublication { get; set; }
        public int IdAuteur { get; set; }
        public string AuteurPseudo { get; set; }
        public string AuteurEmail { get; set; }
        public string AuteurAvatar { get; set; }
        public string AuteurStatut { get; set; }
        public string AuteurAcces { get; set; }
        //public string AuteurTrophee { get; set; }
        public int AuteurPopularite { get; set; }
    }
}