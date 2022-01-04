using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using projeto_final_webApi.Domains;

namespace projeto_final_webApi.database
{
    public class DtechContext : DbContext
    {   
        public DtechContext(DbContextOptions<DtechContext> options) : base(options) { }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<Material> Material { get; set; }


        public  IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }
 
    }
}
