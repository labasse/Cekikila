using CekikilaBack.Models;
using CekikilaShared.Dto;
using Microsoft.EntityFrameworkCore;

namespace CekikilaBack.Controllers.TypeConverter
{
    public static class EntityDtoConverter
    {
        public static ObjetDto ToDto(this Objet entite) => new ObjetDto(entite.Nom)
        {
            IdObjet = entite.IdObjet,
            Description = entite.Description,
            Debut = entite.Debut,
            Fin = entite.Fin,
            Valeur = (double)entite.Valeur,
            Tags = entite.IdTags.Select(t => t.Label).ToList()
        };

        public async static Task<Objet> FromDto(this ObjetDto dto, SqlDbContext db)
        {
            var tags = new List<Tag>();

            foreach (var tag in dto.Tags)
            {
                var entite = await db.Tags.FirstOrDefaultAsync(t => t.Label == tag);

                if(entite is null)
                {
                    throw new ArgumentException("Tag inexistant");
                }
                tags.Add(entite);
            }
            return new Objet()
            {
                IdObjet = dto.IdObjet ?? 0,
                Nom = dto.Nom,
                Description = dto.Description,
                Debut = dto.Debut,
                Fin = dto.Fin,
                Valeur = (decimal)dto.Valeur,
                IdTags = tags
            };
        }
    }
}
