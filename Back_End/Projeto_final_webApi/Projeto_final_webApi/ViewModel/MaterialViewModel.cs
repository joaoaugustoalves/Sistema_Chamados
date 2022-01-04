using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.ViewModel
{
    public class MaterialPostViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int IdChamado { get; set; }
    }

        public class MaterialPutViewModel : MaterialPostViewModel
    {
        public int IdMaterial { get; set; }
    }

}
