using System.Diagnostics.CodeAnalysis;

namespace Cekikila 
{
    public class Objet
    {
        public Objet(string nom, int? idObjet = null)
        {
            Nom = nom;
            IdObjet = idObjet;
        }

        public int? IdObjet { get; init; }

        public string Nom { get; set; }

        public string? Description { get; set; }

        public DateTime Debut { get; set; }

        public DateTime? Fin { get; set; }

        public double Valeur { get; set; } = 1.0;
    }
}
