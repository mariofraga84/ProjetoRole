using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetoRole.Uteis
{
    public class Erros
    {

        /// <summary>
        ///  Metodos que grava log de erro. ex: Uteis.Erros.SalvaErro(erro);
        /// </summary>
        /// <param name="erroInfoObj"></param>
        public static void SalvaErro(Object erroInfoObj)
        {
            try
            {
                HandleErrorInfo erroInfo = (HandleErrorInfo)erroInfoObj;
                string caminho = "~/Logs/" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";
                if (!File.Exists(HttpContext.Current.Request.MapPath(caminho)))
                {
                    using (File.Create(HttpContext.Current.Request.MapPath(caminho))) ;
                }
                FileInfo arq = new FileInfo(HttpContext.Current.Request.MapPath(caminho));
                StringBuilder conteudo = new StringBuilder();
                using (StreamReader re = File.OpenText(HttpContext.Current.Request.MapPath(caminho)))
                {
                    conteudo.Append(re.ReadToEnd());
                }
                using (StreamWriter tx = arq.CreateText())
                {

                    tx.WriteLine(DateTime.Now.ToString());
                    tx.Write(tx.NewLine);
                    tx.Write("Controller: " + erroInfo.ControllerName + " - Action: " + erroInfo.ActionName);
                    tx.Write(tx.NewLine);
                    tx.Write("Exception: " + erroInfo.Exception.GetType().FullName + " - Mensagem: " + erroInfo.Exception.Message.ToString());
                    tx.Write(tx.NewLine);
                    tx.Write("StackTrace: " + erroInfo.Exception.StackTrace.ToString());
                    tx.Write(tx.NewLine);
                    tx.Write(conteudo);
                    tx.Write(tx.NewLine);
                }
            }
            catch (Exception)
            {
                Exception erro = (Exception)erroInfoObj;
                string caminho = "~/Logs/" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";
                if (!File.Exists(HttpContext.Current.Request.MapPath(caminho)))
                {
                    using (File.Create(HttpContext.Current.Request.MapPath(caminho))) ;
                }
                FileInfo arq = new FileInfo(HttpContext.Current.Request.MapPath(caminho));
                StringBuilder conteudo = new StringBuilder();
                using (StreamReader re = File.OpenText(HttpContext.Current.Request.MapPath(caminho)))
                {
                    conteudo.Append(re.ReadToEnd());
                }
                using (StreamWriter tx = arq.CreateText())
                {

                    tx.WriteLine(DateTime.Now.ToString());
                    tx.Write(tx.NewLine);
                    tx.Write("Classe: " + erro.TargetSite.DeclaringType.DeclaringType.FullName.ToString());
                    tx.Write(tx.NewLine);
                    tx.Write("Exception: " + erro.GetType().FullName + " - Mensagem: " + erro.Message.ToString());
                    tx.Write(tx.NewLine);
                    tx.Write("StackTrace: " + erro.StackTrace.ToString());
                    tx.WriteLine(conteudo.ToString());
                    tx.Write(tx.NewLine);
                }

            }


        }

    }

}

