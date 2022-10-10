using System.Diagnostics.CodeAnalysis;

namespace Cekikila 
{
    public class Objet : IDisposable
    {
        private Dictionary<string, Tag> tags = new()
        {
            { "Jardin"    , new Tag(1, "Jardin", 0)},
            { "Electrique", new Tag(2, "Electrique", 1)}
        };

        // Type valeur : int, double, ..., struct, tuples

        // Type référence : string, class

        public Objet()
        {
            InitNom();
        }
        public Objet(string nom)
        {
            Nom = nom;
        }

        [MemberNotNull(nameof(Nom))]
        private void InitNom()
        {
            Nom = "";
        }

        // Solution 1 : public string Nom { get; set; } = "(Sans nom)";
        public string Nom { get; set; } // = null!; // Le cas échéant

        public string? Description { get; set; } = @"c:\toto.txt";

        public DateTime Debut { get; set; }

        public DateTime? Fin { get; set; }

        public double Valeur { get; set; }

        public IEnumerable<Tag> TagsAvecOrdre
        {
            get
            {
                foreach(var t in tags)
                {
                    if(t.Value.Ordre>=0)
                    {
                        yield return t.Value;
                    }
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
