using System.Diagnostics;

namespace Cekikila
{
    public class DbContext
    {
        private readonly Dictionary<string, Tag> tags = new()
        {
            { "Jardin", new Tag(IdTag: 1, "Jardin", Ordre: 1) },
            { "Sport" , new Tag(IdTag: 2, "Sport" , Ordre: 2) },
            { "Electrique", new Tag(IdTag: 3, "Electrique", Ordre: 3) }
        };
        private readonly List<Objet> objets = new()
        {
            new Objet("Broyeur de végétaux", 1) { 
                Description = "Broyeur électrique d'une puissance de 2800W et d'un diamètre de coupe maximum de 45 mm convient parfaitement à un usage régulier."
            },
            new Objet("Paddle gonflable", 4) {
                Description = "Idéal pour amener partout avec soit, les planches de paddle gonflable vous surprendront par leur rigidité une fois gonflée et leur compacité dans leur sac de rangement."
            },
            new Objet("Taille haies électrique", 3) {
                Description = "Taille haies filaire idéal pour tailler de grandes haies avec facilité et en silence."
            }
        };
        public DbContext()
        {
            objets[0].Tags.Add(tags["Jardin"]);
            objets[0].Tags.Add(tags["Electrique"]);
            objets[1].Tags.Add(tags["Sport" ]);
            objets[2].Tags.Add(tags["Jardin"]);
            objets[2].Tags.Add(tags["Electrique"]);
        }
        public IEnumerable<Objet> Objets => objets;
    }
}
