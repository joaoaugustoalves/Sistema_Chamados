using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.ViewModel
{
    public class ChamadoPostViewModel
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int IdColaborador { get; set; }
        public int IdEspecialista { get; set; }
        public bool Status { get; set; }
        public int Prioridade { get; set; }
    }

    public class ChamadoPutViewModel : ChamadoPostViewModel
    {
        public int IdChamado { get; set; }
    }
}
