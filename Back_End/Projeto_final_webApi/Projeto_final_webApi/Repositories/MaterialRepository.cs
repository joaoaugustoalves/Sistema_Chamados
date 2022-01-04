using projeto_final_webApi.database;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        internal DtechContext ctx;

        public MaterialRepository(DtechContext context)
        {
            ctx = context;
        }

        public List<Material> Listar()
        {
            return ctx.Material.ToList();
        }

        public void Deletar(int id)
        {
            ctx.Material.Remove(BuscarPorId(id));


            ctx.SaveChanges();
        }

        public Material BuscarPorId(int id)
        {
            return ctx.Material.FirstOrDefault(e => e.IdMaterial == id);
        }

        public void Cadastrar(Material novoMaterial)
        {
            ctx.Material.Add(novoMaterial);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Material MaterialAtualizado)
        {
            Material MaterialBuscado = ctx.Material.FirstOrDefault(identificar => identificar.IdMaterial == id);

            if (MaterialAtualizado.Nome != null)
            {
                MaterialBuscado.Nome = MaterialAtualizado.Nome;
            }
        }
    }
}

