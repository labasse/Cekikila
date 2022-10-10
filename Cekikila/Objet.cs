using System.Diagnostics.CodeAnalysis;

namespace Cekikila 
{
    public class Objet
    {
        public Objet(string nom)
        {
            Nom = nom;
        }

        public string Nom { get; set; }

        public string? Description { get; set; }

        public DateTime Debut { get; set; }

        public DateTime? Fin { get; set; }

        public double Valeur { get; set; } = 1.0;
    }
}
