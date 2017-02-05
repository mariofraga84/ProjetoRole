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
using System.Data.Entity.Spatial;
using ProjetoRole.Uteis;
using System.Runtime.Remoting.Contexts;

namespace ProjetoRole.Controllers
{
    public class CAUsuariosController : Controller
    {
        private BandoDeDados db = new BandoDeDados();

        // GET: CAUsuarios
        public async Task<ActionResult> Index()
        {
            var cAUsuario = db.CAUsuario.Include(c => c.CAInstancia).Include(c => c.CAPerfil).Include(c => c.Localidade);
            return View(await cAUsuario.ToListAsync());
        }

        // GET: CAUsuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUsuario cAUsuario = await db.CAUsuario.FindAsync(id);
            if (cAUsuario == null)
            {
                return HttpNotFound();
            }
            return View(cAUsuario);
        }



        // GET: CAUsuarios/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: CAUsuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormularioUsuarios form, HttpPostedFileBase FotoPerfil)
        {
            try
            {
                CAUsuario usuario = form.usuario;
                usuario.fkInstancia = 1;
                usuario.fkPerfil = 1;


                if (usuario.nome == null)
                    ModelState.AddModelError("usuario.nome", "Digite seu nome!");

                if (usuario.apelido == null)
                    ModelState.AddModelError("usuario.apelido", "Digite seu apelido!");

                if (usuario.email == null)
                    ModelState.AddModelError("usuario.email", "Digite seu email!");

                if (usuario.senha == null)
                {
                    ModelState.AddModelError("usuario.senha", "Digite sua Senha!");
                }
                else
                {

                    if (usuario.senha.Equals(form.senhaConfirmacao))
                    {
                        usuario.senha = funcoesUteis.Criptografar(usuario.senha);

                    }
                    else
                    {
                        ModelState.AddModelError("senhaConfirmacao", "A Senha e Confirmação da Senha não Conferem!");
                        return View(ViewBag);
                    }
                }

                if (form.autocomplete == null)
                {
                    ModelState.AddModelError("autocomplete", "Digite sua Cidade!");
                }

                if (!ModelState.IsValid)
                {
                    return View();
                }

                LocalidadesController loc = new LocalidadesController();
                usuario.fkLocalidade = loc.carregaLocalidadeGoogle(form.administrative_area_level_2, form.country, form.administrative_area_level_1, form.longitude.ToString(), form.latitude.ToString(), form.autocomplete.ToString());

                usuario.coordenadas = DbGeography.FromText(string.Format("POINT({0} {1})", form.latitude.Replace(",", "."), form.longitude.Replace(",", ".")), 4326);

                ImageUpload imageUpload = new ImageUpload { Width = 800 };
                if (FotoPerfil != null && FotoPerfil.FileName != null)
                {
                    ImageResult imageResult = imageUpload.RenameUploadFile(FotoPerfil);
                    if (!imageResult.Success)
                    {
                        ModelState.AddModelError("usuario.foto", "Ocorreu um erro no Envio de Foto, Verifique o Arquivo.");
                        return View();
                    }
                    else
                    {
                        usuario.foto = imageResult.ImageName;
                    }
                }

                db.CAUsuario.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("../CAUsuarios/Index");
            }
            catch (Exception er)
            {
                ViewBag.administrative_area_level_2 = form.administrative_area_level_2;
                ViewBag.administrative_area_level_1 = form.administrative_area_level_1;
                ViewBag.country = form.country;
                ViewBag.autocomplete = form.autocomplete;
                ViewBag.longitude = form.longitude;
                ViewBag.latitude = form.latitude;
                ViewBag.Erro = er.Message.ToString();
                return View();
            }

            return View();
        }
        


        // GET: CAUsuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUsuario cAUsuario = await db.CAUsuario.FindAsync(id);
            if (cAUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkInstancia = new SelectList(db.CAInstancia, "pkInstancia", "nome", cAUsuario.fkInstancia);
            ViewBag.fkPerfil = new SelectList(db.CAPerfil, "pkPerfil", "nomePerfil", cAUsuario.fkPerfil);
            ViewBag.fkLocalidade = new SelectList(db.Localidade, "pkLocalidade", "cidade", cAUsuario.fkLocalidade);
            return View(cAUsuario);
        }

        // POST: CAUsuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pkUsuario,fkPerfil,fkLocalidade,fkInstancia,nome,apelido,email,senha,fone,ativo,foto")] CAUsuario cAUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fkInstancia = new SelectList(db.CAInstancia, "pkInstancia", "nome", cAUsuario.fkInstancia);
            ViewBag.fkPerfil = new SelectList(db.CAPerfil, "pkPerfil", "nomePerfil", cAUsuario.fkPerfil);
            ViewBag.fkLocalidade = new SelectList(db.Localidade, "pkLocalidade", "cidade", cAUsuario.fkLocalidade);
            return View(cAUsuario);
        }

        // GET: CAUsuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAUsuario cAUsuario = await db.CAUsuario.FindAsync(id);
            if (cAUsuario == null)
            {
                return HttpNotFound();
            }
            return View(cAUsuario);
        }

        // POST: CAUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CAUsuario cAUsuario = await db.CAUsuario.FindAsync(id);
            db.CAUsuario.Remove(cAUsuario);
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


        // GET: CAUsuarios/Login
        public async Task<ActionResult> LoginTesteAsync()
        {
            CAUsuario usuario = db.CAUsuario.Where(o=> o.pkUsuario == 1).First();
            Session.Add("usuario", usuario);
            return RedirectToAction("Index");
        }

        // GET: CAUsuarios/Login
        public ActionResult Login(string urlRetorno)
        {
            FormularioLogin form = new FormularioLogin();
            form.urlRetorno = urlRetorno;
            return View(form);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(FormularioLogin form)
        {
            CAUsuario usuario = null;

            try
            {
                string senhaC = funcoesUteis.Criptografar(form.usuario.senha);

                if (db.CAUsuario.Where(o => o.email.Equals(form.usuario.email) && o.senha.Equals(senhaC)).Any())
                {
                    usuario = await db.CAUsuario.Where(o => o.email.Equals(form.usuario.email) && o.senha.Equals(senhaC)).FirstAsync();
                    if (usuario != null)
                    {
                        CALogAcesso log = new CALogAcesso();
                        log.fkUsuario = usuario.pkUsuario;
                        log.dataHora = DateTime.Now;
                        log.ip = funcoesUteis.recuperaIpUsuario();
                        db.CALogAcesso.Add(log);
                        await db.SaveChangesAsync();
                        Session.Add("usuario", usuario);

                        if (!string.IsNullOrEmpty(form.urlRetorno) && Url.IsLocalUrl(form.urlRetorno))
                        {
                            return Redirect(form.urlRetorno);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }                  
                    }                    
                }
                else
                {

                    ModelState.AddModelError("usuario.senha", "Usuário ou senha não conferem!");
                    return View();
                }

            }
            catch (Exception er)
            {
                ModelState.AddModelError("usuario.senha", "Usuário ou senha não conferem!");
                return View();
            }
            return View();
        }


        public async Task<ActionResult> MeusDados()
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("../CAUsuarios/Login");
                return View();
            }


            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } */



            CAUsuario usuairo = (CAUsuario)Session["usuario"];
            if (usuairo == null)
            {
                return HttpNotFound();
            }

            FormularioUsuarios form = new FormularioUsuarios();

            usuairo.Localidade = await db.Localidade.FindAsync(usuairo.fkLocalidade);

            form.usuario = usuairo;


            ViewBag.usuario = usuairo;

            form.administrative_area_level_2 = usuairo.Localidade.cidade;
            form.administrative_area_level_1 = usuairo.Localidade.uf;
            form.country = usuairo.Localidade.pais;
            form.autocomplete = usuairo.Localidade.nomeCompletoLocal;
            form.longitude = usuairo.Localidade.coordenadas.Longitude.ToString();
            form.latitude = usuairo.Localidade.coordenadas.Latitude.ToString();

            return View(form);
        }


        // POST: CAUsuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MeusDados(FormularioUsuarios form, HttpPostedFileBase FotoPerfil)
        {
            try
            {
                CAUsuario usuario;
                if (Session["usuario"] == null)
                {
                    RedirectToAction("Login", "CAUsuarios");
                    return View();
                } else
                {
                    usuario = (CAUsuario)Session["usuario"];
                }


                if (form.usuario.nome == null)
                {
                    ModelState.AddModelError("usuario.nome", "Digite seu nome!");
                } else
                {
                    usuario.nome = form.usuario.nome;
                }

                if (form.usuario.apelido == null) { 
                    ModelState.AddModelError("usuario.apelido", "Digite seu apelido!");
                }
                else
                {
                    usuario.apelido = form.usuario.apelido;
                }

                usuario.fone = form.usuario.fone;

                if (form.usuario.senha != null)
                {                  

                    if (form.usuario.senha.Equals(form.senhaConfirmacao))
                    {
                        usuario.senha = funcoesUteis.Criptografar(form.usuario.senha);
                    }
                    else
                    {
                        ModelState.AddModelError("senhaConfirmacao", "A Senha e Confirmação da Senha não Conferem!");
                        return View();
                    }
                }

                if (form.autocomplete == null)
                {
                    ModelState.AddModelError("autocomplete", "Digite sua Cidade!");
                }

                if (!ModelState.IsValid)
                {
                    return View();
                }

                LocalidadesController loc = new LocalidadesController();
                usuario.fkLocalidade = loc.carregaLocalidadeGoogle(form.administrative_area_level_2, form.country, form.administrative_area_level_1, form.longitude.ToString(), form.latitude.ToString(), form.autocomplete.ToString());

                usuario.coordenadas = DbGeography.FromText(string.Format("POINT({0} {1})", form.latitude.Replace(",", "."), form.longitude.Replace(",", ".")), 4326);

                ImageUpload imageUpload = new ImageUpload { Width = 800 };
                if (FotoPerfil != null && FotoPerfil.FileName != null)
                {
                    ImageResult imageResult = imageUpload.RenameUploadFile(FotoPerfil);
                    if (!imageResult.Success)
                    {
                        ModelState.AddModelError("usuario.foto", "Ocorreu um erro no Envio de Foto, Verifique o Arquivo.");
                        return View();
                    }
                    else
                    {
                        usuario.foto = imageResult.ImageName;
                    }
                }

                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("../CAUsuarios/Index");
            }
            catch (Exception er)
            {
                ViewBag.administrative_area_level_2 = form.administrative_area_level_2;
                ViewBag.administrative_area_level_1 = form.administrative_area_level_1;
                ViewBag.country = form.country;
                ViewBag.autocomplete = form.autocomplete;
                ViewBag.longitude = form.longitude;
                ViewBag.latitude = form.latitude;
                ViewBag.Erro = er.Message.ToString();
                return View();
            }

            return View();
        }



        public async Task<ActionResult> LogOff()
        {
            if (Session["usuario"] != null)
            {
                Session.RemoveAll();
            }
            Response.Redirect("../");
            return View();
        }

    }
}
