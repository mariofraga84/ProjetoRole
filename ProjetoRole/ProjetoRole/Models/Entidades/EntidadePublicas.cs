using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoRole.Models.Entidades
{
    public class EntidadePublicas
    {
        
    }

    public class EnidadePaginaIncial
    {
        public List<Role> listaFuturo { get; set; }
        public List<Role> listaPassado { get; set; }

    }

    public class EntidadeRole
    {
        public Role role { get; set; }
        
    }


}