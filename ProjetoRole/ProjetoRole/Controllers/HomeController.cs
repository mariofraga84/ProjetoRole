using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoRole.Models;
using ProjetoRole.Models.Entidades;
using ProjetoRole.Uteis;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjetoRole.Models.Entidades;

namespace ProjetoRole.Controllers
{
    public class HomeController : Controller
    {
        private BandoDeDados db = new BandoDeDados();

        public async Task<ActionResult> Index()
        {
            EnidadePaginaIncial ep = new EnidadePaginaIncial();
            List<Role> role = db.Role.Where(o=>o.ativo == true).Include(r => r.CAUsuario).Include(r => r.TipoRole).ToList();
            ep.listaFuturo = role;

            return View(ep);
        }

        public async Task<ActionResult> IndexInterno()
        {
            EnidadePaginaIncial ep = new EnidadePaginaIncial();
            List<Role> role = db.Role.Where(o => o.ativo == true).Include(r => r.CAUsuario).Include(r => r.TipoRole).ToList();
            ep.listaFuturo = role;

            return View(ep);
        }


        public async Task<ActionResult> View(int id)
        {
            EntidadeRole entRole = new EntidadeRole();

            try
            {
            Role role = db.Role.Where(o => o.ativo == true && o.pkRole == id).First();
            entRole.role = role;

        

            return View(entRole);
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}