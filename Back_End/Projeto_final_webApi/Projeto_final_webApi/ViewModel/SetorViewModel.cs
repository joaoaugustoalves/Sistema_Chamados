using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.ViewModel
{
    public class SetorPostViewModel
    {
        public string Nome { get; set; }
    }

    public class SetorPutViewModel : SetorPostViewModel
    {
        public int IdSetor { get; set; }
    }
}
