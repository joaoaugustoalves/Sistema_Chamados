using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.ViewModel
{
    public class TipoUsuarioPostViewModel
    {
        public string Nome { get; set; }

    }
    public class TipoUsuarioPutViewModel : TipoUsuarioPostViewModel
    {
        public int IdTipoUsuario { get; set; }
    }
}
