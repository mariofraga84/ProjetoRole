﻿using System;
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
using ProjetoRole.Models.Entidades;

namespace ProjetoRole.Controllers
{
    public class MotoesController : Controller
    {
        private BancoDeDados db = new BancoDeDados();

        // GET: Motoes
        public async Task<ActionResult> Index()
        {
            CAUsuario usuario;
            if (Session["usuario"] == null)
            {              
                return RedirectToAction("Login", "CAUsuarios", new { urlRetorno= Request.Url.AbsolutePath });
            }
            else
            {
                usuario = (CAUsuario)Session["usuario"];
            }
            var moto = db.Moto.Where(o => o.fkUsuario == usuario.pkUsuario).Include(m => m.Marca);
            return View(await moto.ToListAsync());
        }

        // GET: Motoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto moto = await db.Moto.FindAsync(id);
            if (moto == null)
            {
                return HttpNotFound();
            }
            return View(moto);
        }

        // GET: Motoes/Create
        public ActionResult Create(int? fkRole)
        {
            ViewBag.fkMarca = new SelectList(db.Marca, "pkMarca", "DescricaoMarca");
            ViewBag.fkRole = fkRole.ToString();
            return View();
        }

        // POST: Motoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Moto moto, HttpPostedFileBase FotoMoto, String fkRole)
        {
            CAUsuario usuario;
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Login", "CAUsuarios", new { urlRetorno = Request.Url.AbsolutePath });
            }
            else
            {
                usuario = (CAUsuario)Session["usuario"];
            }

            moto.fkUsuario = usuario.pkUsuario;

            if (ModelState.IsValid)
            {
                ImageUpload imageUpload = new ImageUpload { Width = 800 };
                if (FotoMoto != null && FotoMoto.FileName != null)
                {
                    ImageResult imageResult = imageUpload.RenameUploadFile(FotoMoto);
                    if (!imageResult.Success)
                    {
                        ModelState.AddModelError("FotoMoto", "Ocorreu um erro no Envio de Foto, Verifique o Arquivo.");
                        return View();
                    }
                    else
                    {
                        moto.foto = imageResult.ImageName;
                    }
                }


                db.Moto.Add(moto);
                await db.SaveChangesAsync();

                if (fkRole != null)
                {
                    return RedirectToAction("Details", "Roles", new { id = fkRole });
                }

                return RedirectToAction("Index");
            }

            ViewBag.fkMarca = new SelectList(db.Marca, "pkMarca", "DescricaoMarca", moto.fkMarca);
            return View(moto);
        }

        // GET: Motoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            CAUsuario usuario;
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Login", "CAUsuarios");
            }
            else
            {
                usuario = (CAUsuario)Session["usuario"];
            }


            Moto moto = await db.Moto.FindAsync(id);
            ViewBag.fkMarca = new SelectList(db.Marca, "pkMarca", "DescricaoMarca", moto.fkMarca);

            if (moto.fkUsuario != usuario.pkUsuario)
            {
                return RedirectToAction("index", "Motoes"); // alertar que nao tem acesso a esta moto.

            }

            if (moto == null)
            {
                return HttpNotFound();
            }

            return View(moto);
        }

        // POST: Motoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Moto moto, HttpPostedFileBase FotoMoto)
        {
            try
            {

                CAUsuario usuario;
                if (Session["usuario"] == null)
                {
                    return RedirectToAction("Login", "CAUsuarios");
                }
                else
                {
                    usuario = (CAUsuario)Session["usuario"];
                }

                Moto motovalida = await db.Moto.FindAsync(moto.pkMoto);

                if (motovalida.fkUsuario != usuario.pkUsuario)
                {
                    return RedirectToAction("index", "Motoes"); // alertar que nao tem acesso a esta moto.
                }

                motovalida.nomeMoto = moto.nomeMoto;
                motovalida.modeloMoto = moto.modeloMoto;
                motovalida.fkMarca = moto.fkMarca;
                motovalida.ativa = moto.ativa;




                if (ModelState.IsValid)
                {

                    ImageUpload imageUpload = new ImageUpload { Width = 800 };
                    if (FotoMoto != null && FotoMoto.FileName != null)
                    {
                        ImageResult imageResult = imageUpload.RenameUploadFile(FotoMoto);
                        if (!imageResult.Success)
                        {
                            ModelState.AddModelError("FotoMoto", "Ocorreu um erro no Envio de Foto, Verifique o Arquivo.");
                            return View();
                        }
                        else
                        {
                            motovalida.foto = imageResult.ImageName;
                        }
                    }
                    

                    db.Entry(motovalida).State = EntityState.Modified;

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception er)
            {
                ViewBag.Error = "Erro no Upload da Imagem";
                ViewBag.fkMarca = new SelectList(db.Marca, "pkMarca", "DescricaoMarca", moto.fkMarca);
                return View();
            }

            ViewBag.fkMarca = new SelectList(db.Marca, "pkMarca", "DescricaoMarca", moto.fkMarca);
            return View(moto);
        }

        // GET: Motoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto moto = await db.Moto.FindAsync(id);
            if (moto == null)
            {
                return HttpNotFound();
            }
            return View(moto);
        }

        // POST: Motoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Moto moto = await db.Moto.FindAsync(id);
            db.Moto.Remove(moto);
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

        // GET: Motoes
        public List<Moto> ListaMotosUsuario(int pkUsuario)
        {
            try
            {
                List<Moto> motos = db.Moto.Where(o => o.fkUsuario == pkUsuario && o.ativa == true).ToList();
                return motos;
            }
            catch (Exception)
            {
                return new List<Moto>();
            }            
        }


        public List<EntidadeMoto> carregaEntidadeMoto(List<Moto> motos)
        {
            List<EntidadeMoto> listaRetorno = new List<EntidadeMoto>();
            EntidadeMoto moto;
            foreach (var item in motos)
            {
                moto = new EntidadeMoto();
                moto.pkMoto = item.pkMoto;
                moto.foto = item.foto;
                moto.descricao = item.nomeMoto + " - " + item.Marca.DescricaoMarca + " - " + item.modeloMoto;
                listaRetorno.Add(moto);
            }
            return listaRetorno;
        }


    }
}
