using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Domains
{
    public class Setor
    {
        [Key]
        public int IdSetor { get; set; }

        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
