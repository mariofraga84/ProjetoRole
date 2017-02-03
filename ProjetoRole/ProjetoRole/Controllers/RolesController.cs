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
using ProjetoRole.Models.Entidades;
using ProjetoRole.Uteis;

namespace ProjetoRole.Controllers
{
    public class RolesController : Controller
    {
        private BandoDeDados db = new BandoDeDados();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            var role = db.Role.Include(r => r.CAUsuario).Include(r => r.TipoRole);
            return View(await role.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            ViewBag.fkUsuario = new SelectList(db.CAUsuario, "pkUsuario", "nome");
            ViewBag.fkTipoRole = new SelectList(db.TipoRole, "pkTipoRole", "descricao");
            return View();
        }

        // POST: Roles/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormulariosRoles form, HttpPostedFileBase FotoPerfil)
        {
            try
            {
                Role role = form.role;
                role.fkUsuario = 1;
                role.dataHoraCadastro = DateTime.Now;
                role.fkTipoRole = form.fkTipoRole;




                LocalidadesController loc = new LocalidadesController();
                role.fkLocalidade = loc.carregaLocalidadeGoogle(form.administrative_area_level_2, form.country, form.administrative_area_level_1, form.longitude.ToString(), form.latitude.ToString(), form.autocomplete.ToString());

                ImageUpload imageUpload = new ImageUpload { Width = 800 };
                if (FotoPerfil != null && FotoPerfil.FileName != null)
                {
                    ImageResult imageResult = imageUpload.RenameUploadFile(FotoPerfil);
                    if (!imageResult.Success)
                    {
                        ViewBag.Error = "Erro no Upload da Imagem";
                        return View(ViewBag);
                    }
                    else
                    {
                        role.capa = imageResult.ImageName;
                    }
                }


                if (ModelState.IsValid)
                {
                    db.Role.Add(role);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.fkUsuario = new SelectList(db.CAUsuario, "pkUsuario", "nome", role.fkUsuario);
                ViewBag.fkTipoRole = new SelectList(db.TipoRole, "pkTipoRole", "descricao", role.fkTipoRole);

                return RedirectToAction("../Roles/Index");
            }
            catch (Exception er)
            {

                return View(form);
            }

            return RedirectToAction("../Roles/Index");
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkUsuario = new SelectList(db.CAUsuario, "pkUsuario", "nome", role.fkUsuario);
            ViewBag.fkTipoRole = new SelectList(db.TipoRole, "pkTipoRole", "descricao", role.fkTipoRole);
            return View(role);
        }

        // POST: Roles/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pkRole,fkUsuario,fkTipoRole,dataHoraCadastro,titulo,descricaoRole,capa,totalKM,localPartida,localDestino,dataRole,horaRole")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fkUsuario = new SelectList(db.CAUsuario, "pkUsuario", "nome", role.fkUsuario);
            ViewBag.fkTipoRole = new SelectList(db.TipoRole, "pkTipoRole", "descricao", role.fkTipoRole);
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Role role = await db.Role.FindAsync(id);
            db.Role.Remove(role);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
