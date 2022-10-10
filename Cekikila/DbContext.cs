namespace Cekikila
{
    public class DbContext
    {
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
        public IEnumerable<Objet> Objets => objets;
    }
}
