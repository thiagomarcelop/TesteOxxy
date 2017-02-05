using CadastroVeiculos.Core.DAL;
using CadastroVeiculos.Core.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroVeiculos.SOAPService
{
    public class ServiceVeiculos : IServiceVeiculos
    {
        private CadastroVeiculosContexto db = new CadastroVeiculosContexto();

        public IEnumerable<Veiculo> ListarVeiculos(string placa = null)
        {
            db.Configuration.ProxyCreationEnabled = false;

            if (!string.IsNullOrEmpty(placa))
                return db.Veiculo.Where(a => a.Placa == placa);
            else
                return db.Veiculo.ToList();
        }
    }
}
