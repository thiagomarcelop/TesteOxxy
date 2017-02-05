using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Xml.Serialization;

namespace CadastroVeiculos.Core.Model
{

    [Table("Veiculo")]
    public partial class Veiculo
    {
        public Veiculo()
        {
            VeiculoImagem = new HashSet<VeiculoImagem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Placa { get; set; }

        [Required]
        [StringLength(12)]
        public string Renavam { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Nome do Proprietário")]
        public string NomeProprietario { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        public bool Bloqueado { get; set; }

        [Display(Name = "Carregar Imagens")]
        public virtual IEnumerable<string> PathImagens { get; set; }

        public virtual ICollection<VeiculoImagem> VeiculoImagem { get; set; }
    }
}
