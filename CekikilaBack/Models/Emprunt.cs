using System;
using System.Collections.Generic;

namespace CekikilaBack.Models
{
    public partial class Emprunt
    {
        public int IdEmprunt { get; set; }
        public int IdObjet { get; set; }
        public string MailEmprunteur { get; set; } = null!;
        public DateTime Debut { get; set; }
        public int Duree { get; set; }
        public DateTime? FinEffective { get; set; }
        public byte? Note { get; set; }

        public virtual Objet IdObjetNavigation { get; set; } = null!;
    }
}
