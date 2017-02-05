using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CadastroVeiculos.Core.Model
{
    
    [Table("VeiculoImagem")]
    public partial class VeiculoImagem
    {
        public int Id { get; set; }

        public int IdVeiculo { get; set; }

        public string Arquivo { get; set; }

        public string Path { get; set; }

        public virtual Veiculo Veiculo { get; set; }
    }
}
