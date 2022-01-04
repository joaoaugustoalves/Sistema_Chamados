using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Domains
{
    public class Chamado
    {
        [Key]
        public int IdChamado { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int IdColaborador { get; set; }
        public int IdEspecialista { get; set; }
        public bool Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public int Prioridade { get; set; }

        public virtual ICollection<Usuario> IdUsuarios { get; set; }
    }
}
