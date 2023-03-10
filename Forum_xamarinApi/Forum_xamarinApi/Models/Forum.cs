//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forum_xamarinApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Forum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Forum()
        {
            this.Like = new HashSet<Like>();
            this.Message = new HashSet<Message>();
        }
    
        public int IdForum { get; set; }
        public string Sujet { get; set; }
        public System.DateTime DatePublication { get; set; }
        public string MotsClefs { get; set; }
        public int Popularite { get; set; }
        public int IdCategorie { get; set; }
        public int IdStatut { get; set; }
        public int IdAcces { get; set; }
        public int IdLangue { get; set; }
        public int IdAuteur { get; set; }

        [JsonIgnore]
        public virtual Acces Acces { get; set; }
        [JsonIgnore]
        public virtual Categorie Categorie { get; set; }
        [JsonIgnore]
        public virtual Utilisateur Utilisateur { get; set; }
        [JsonIgnore]
        public virtual Langue Langue { get; set; }
        [JsonIgnore]
        public virtual Statut Statut { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Like> Like { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Message> Message { get; set; }
    }
}
