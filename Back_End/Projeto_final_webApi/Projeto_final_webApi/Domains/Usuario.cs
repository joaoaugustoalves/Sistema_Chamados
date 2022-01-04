using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Domains
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public int Telefone { get; set; }
        public int IdSetor { get; set; }
        public int IdTipoUsuario { get; set; }

        public Setor Setor { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
    }

    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasOne(e => e.Setor)
            .WithMany(s => s.Usuarios)
            .HasForeignKey(m => m.IdSetor)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

            builder.HasOne(e => e.TipoUsuario)
            .WithMany(s => s.Usuarios)
            .HasForeignKey(m => m.IdTipoUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

            builder.Property(s => s.Nome).HasMaxLength(200).IsRequired();
        }
    }
}
