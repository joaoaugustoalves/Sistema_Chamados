using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Domains
{
    public class Material
    {
        [Key]
        public int IdMaterial { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int  IdChamado { get; set; }

    }
}
