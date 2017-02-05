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
using System.IO;

namespace CadastroVeiculos.Site.Controllers
{
    public class VeiculoController : Controller
    {
        private CadastroVeiculosContexto db = new CadastroVeiculosContexto();
        
        // GET: Veiculo
        public async Task<ActionResult> Index()
        {
            return View(await db.Veiculo.ToListAsync());
        }

        // GET: Veiculo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Placa,Renavam,NomeProprietario,CPF,Bloqueado")] Veiculo veiculo, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                db.Veiculo.Add(veiculo);
                await db.SaveChangesAsync();

                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var arquivo = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var pathArquivo = Path.Combine(Server.MapPath("/uploads"), arquivo);
                        file.SaveAs(pathArquivo);

                        VeiculoImagem imagem = new VeiculoImagem() { 
                            IdVeiculo = veiculo.Id,
                            Arquivo = arquivo,
                            Path = pathArquivo
                        };

                        db.VeiculoImagem.Add(imagem);
                        await db.SaveChangesAsync();
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Placa,Renavam,NomeProprietario,CPF,Bloqueado")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Veiculo veiculo = await db.Veiculo.FindAsync(id);
            db.Veiculo.Remove(veiculo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
