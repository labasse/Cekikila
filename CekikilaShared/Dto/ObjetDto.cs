using System.Diagnostics.CodeAnalysis;

namespace CekikilaShared.Dto
{

    public class ObjetDto
    {
        public ObjetDto(string nom, int? idObjet = null)
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

        public List<string> Tags { get; init; } = new ();
    }
}
