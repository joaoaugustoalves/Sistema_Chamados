using projeto_final_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Interfaces
{
    public interface IMaterialRepository
    {
        List<Material> Listar();

        void Cadastrar(Material MaterialChamado);

        void Atualizar(int id, Material MaterialAtualizado);
        void Deletar(int id);
    }
}
