using System;
using System.Collections.Generic;

namespace CekikilaBack.Models
{
    public partial class Objet
    {
        public Objet()
        {
            Emprunts = new HashSet<Emprunt>();
            IdTags = new HashSet<Tag>();
        }

        public int IdObjet { get; set; }
        public string Nom { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Debut { get; set; }
        public DateTime? Fin { get; set; }
        public byte DureeMax { get; set; }
        public decimal Valeur { get; set; }

        public virtual ICollection<Emprunt> Emprunts { get; set; }

        public virtual ICollection<Tag> IdTags { get; set; }
    }
}
