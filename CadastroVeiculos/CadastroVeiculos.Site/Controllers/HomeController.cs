using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroVeiculos.Core.DAL;
using CadastroVeiculos.Core.Model;

namespace CadastroVeiculos.Site.Controllers
{
    public class HomeController : Controller
    {
        private CadastroVeiculosContexto db = new CadastroVeiculosContexto();

        public async Task<ActionResult> Index()
        {
            return View(await db.Veiculo.ToListAsync());
        }
    }
}