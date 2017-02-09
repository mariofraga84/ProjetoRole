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
        public bool inscritoRole { get; set; }
        public String descricaoMotoInscrita { get; set; }
        public List<Participamente> participantes { get; set; }
        public List<Comentario> comentarios { get; set; }
        public bool eAdm { get; set; }
    }

    public class EntidadeErro
    {
        public bool erro { get; set; }
        public String msgTitulo { get; set; }
        public String msgErro { get; set; }
        public String msgTipo { get; set; }
        public String erroException { get; set; }
        public String erroArquivo { get; set; }
    }


    public class EntidadeMoto
    {
        public int pkMoto { get; set; }
        public string descricao { get; set; }
        public string foto { get; set; }

    }

}