using System;
using System.Collections.Generic;

namespace CekikilaBack.Models
{
    public partial class Tag
    {
        public Tag()
        {
            IdObjets = new HashSet<Objet>();
        }

        public int IdTag { get; set; }
        public string Label { get; set; } = null!;
        public byte? Ordre { get; set; }

        public virtual ICollection<Objet> IdObjets { get; set; }
    }
}
