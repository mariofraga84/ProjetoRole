using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjetoRole.Models.Entidades
{
    public class FormularioUsuarios
    {
        public ProjetoRole.Models.CAUsuario usuario { get; set; }

        public string senhaConfirmacao { get; set; }

        public string administrative_area_level_2 { get; set; }
        public string administrative_area_level_1 { get; set; }
        public string country { get; set; }

        public string longitude { get; set; }
        public string latitude { get; set; }

        public string autocomplete { get; set; }

        public string msgErro { get; set; }

      //  public object ViewBag { get; set; }


    }

    public class FormulariosRoles
    {
        public ProjetoRole.Models.Role role { get; set; }

        public int fkTipoRole { get; set; }

        public string administrative_area_level_2 { get; set; }
        public string administrative_area_level_1 { get; set; }
        public string country { get; set; }

        public string longitude { get; set; }
        public string latitude { get; set; }

        public string autocomplete { get; set; }

        public string msgErro { get; set; }
    }
    public class FormularioLogin
    {
        public ProjetoRole.Models.CAUsuario usuario { get; set; }
        public Boolean lembrarSenha { get; set; }
        public string Erro { get; set; }
        public string urlRetorno { get; set; }

    }
}