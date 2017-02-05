using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CadastroVeiculos.Core.DAL;
using CadastroVeiculos.Core.Model;

namespace CadastroVeiculos.Core.DAL
{
    public partial class CadastroVeiculosContexto : DbContext
    {
        public CadastroVeiculosContexto()
            : base("name=CadastroVeiculosConnection")
        {
        }

        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<VeiculoImagem> VeiculoImagem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Placa)
                .IsFixedLength();

            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Renavam)
                .IsFixedLength();

            modelBuilder.Entity<Veiculo>()
                .Property(e => e.CPF)
                .IsFixedLength();

            modelBuilder.Entity<Veiculo>()
                .HasMany(e => e.VeiculoImagem)
                .WithRequired(e => e.Veiculo)
                .HasForeignKey(e => e.IdVeiculo)
                .WillCascadeOnDelete(false);
        }
    }

    public class CadastroVeiculosDbInitializer : DropCreateDatabaseIfModelChanges<CadastroVeiculosContexto>
    {
        protected override void Seed(CadastroVeiculosContexto context)
        {
            base.Seed(context);
        }
    }
}
