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
        public EntidadeErro erro { get; set; }

    }

    public class EntidadeErro
    {
        public bool erro { get; set; }
        public string msgTitulo { get; set; }
        public string msgErro { get; set; }
        public string msgTipo { get; set; }
        public string erroException { get; set; }
        public string erroArquivo { get; set; }
    }


    public class EntidadeMoto
    {
        public int pkMoto { get; set; }
        public string descricao { get; set; }
        public string foto { get; set; }

    }

}