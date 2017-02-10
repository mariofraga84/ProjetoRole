using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoRole.Models;
using ProjetoRole.Uteis;
using System.Data.Entity.Spatial;

namespace ProjetoRole.Controllers
{
    public class LocalidadesController : Controller
    {
        private BancoDeDados db = new BancoDeDados();

        // GET: Localidades
        public async Task<ActionResult> Index()
        {
            return View(await db.Localidade.ToListAsync());
        }

        // GET: Localidades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidade localidade = await db.Localidade.FindAsync(id);
            if (localidade == null)
            {
                return HttpNotFound();
            }
            return View(localidade);
        }

        // GET: Localidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pkLocalidade,cidade,uf,pais,idFBLocalidade,nomeCompletoLocal,coordenadas")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                db.Localidade.Add(localidade);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(localidade);
        }

        // GET: Localidades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidade localidade = await db.Localidade.FindAsync(id);
            if (localidade == null)
            {
                return HttpNotFound();
            }
            return View(localidade);
        }

        // POST: Localidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pkLocalidade,cidade,uf,pais,idFBLocalidade,nomeCompletoLocal,coordenadas")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidade).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(localidade);
        }

        // GET: Localidades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidade localidade = await db.Localidade.FindAsync(id);
            if (localidade == null)
            {
                return HttpNotFound();
            }
            return View(localidade);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Localidade localidade = await db.Localidade.FindAsync(id);
            db.Localidade.Remove(localidade);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /*
        public int carregaLocalidade(long idFBLocalidade, string cidade, string pais, string uf, string latitude, string longitude, string nomeCompleto)
        {
            Localidade local;
            if (cidade.Trim().Equals("") || cidade == null)
            {
                if (!uf.Trim().Equals(""))
                {
                    cidade = uf;
                    uf = "";
                }
            }
            cidade = funcoesUteis.RemoverAcentos(cidade.ToLower());
            if (uf == null)
            {
                uf = "";
            }
            uf = funcoesUteis.RemoverAcentos(uf.ToLower());
            pais = funcoesUteis.RemoverAcentos(pais.ToLower());
            try
            {
                local = db.Localidade.Where(o => o.idFBLocalidade == idFBLocalidade).First();

                if (local.pais == null || local.pais.Equals(""))
                {
                    local.pais = funcoesUteis.RemoverAcentos(pais.ToLower());
                    local.uf = funcoesUteis.RemoverAcentos(uf.ToLower());
                    local.nomeCompletoLocal = nomeCompleto;
                    local.coordenadas = DbGeography.FromText(string.Format("POINT({0} {1})", latitude, longitude), 4326);
                    db.Entry(local).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return local.pkLocalidade;
            }
            catch (InvalidOperationException er)
            {
                local = new Localidade();
                local.idFBLocalidade = idFBLocalidade;
                local.cidade = cidade;
                local.uf = uf;
                local.pais = pais;
                local.coordenadas = DbGeography.FromText(string.Format("POINT({0} {1})", latitude, longitude), 4326); ;
                local.nomeCompletoLocal = nomeCompleto;
                db.Localidade.Add(local);
                db.SaveChanges();
                return local.pkLocalidade;
            }
        }
        */

        public int carregaLocalidadeGoogle(string cidade, string pais, string uf, string longitude, string latitude, string nomeCompleto)
        {
            Localidade local;
            try
            {
                if (cidade.Trim().Equals("") || cidade == null)
                {
                    if (!uf.Trim().Equals(""))
                    {
                        cidade = uf;
                        uf = "";
                    }
                }

                cidade = funcoesUteis.RemoverAcentos(cidade.ToLower());
                if (uf == null)
                {
                    uf = "";
                }
                uf = funcoesUteis.RemoverAcentos(uf.ToLower());
                pais = funcoesUteis.RemoverAcentos(pais.ToLower());

                local = db.Localidade.Where(o => o.cidade.Equals(cidade) && o.uf.Equals(uf)).First();
                if (local.pais == null || local.pais.Equals(""))
                {
                    local.pais = funcoesUteis.RemoverAcentos(pais.ToLower());
                    local.uf = funcoesUteis.RemoverAcentos(uf.ToLower());
                    local.coordenadas = DbGeography.FromText(string.Format("POINT({0} {1})", latitude, longitude), 4326);
                    local.nomeCompletoLocal = nomeCompleto;
                    db.Entry(local).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return local.pkLocalidade;
            }
            catch (InvalidOperationException er)
            {
                local = new Localidade();
                local.cidade = cidade;
                local.uf = uf;
                local.pais = pais;
                local.nomeCompletoLocal = nomeCompleto;
                local.coordenadas = DbGeography.FromText(string.Format("POINT({0} {1})", latitude, longitude), 4326);
                db.Localidade.Add(local);
                db.SaveChanges();
                return local.pkLocalidade;
            }
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
