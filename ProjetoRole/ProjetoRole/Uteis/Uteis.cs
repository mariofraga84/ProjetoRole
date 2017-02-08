using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Security.Cryptography;

namespace ProjetoRole.Uteis
{
    public class funcoesUteis
    {
        const string senha = "projetoRole741$#";

        public static string RemoverAcentos(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            else
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(input);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }

        public static string DeixaSoNumeros(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            else
            {
                return String.Join("", System.Text.RegularExpressions.Regex.Split(input, @"[^\d]"));
            }
        }


        public static string Criptografar(string texto)
        {

            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;

            TDESAlgorithm.Mode = CipherMode.ECB;

            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToEncrypt = UTF8.GetBytes(texto);

            try

            {

                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();

                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

            }

            finally

            {

                TDESAlgorithm.Clear();

                HashProvider.Clear();

            }
            return Convert.ToBase64String(Results);
        }

        public static string Descriptografar(string texto)

        {

            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;

            TDESAlgorithm.Mode = CipherMode.ECB;

            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToDecrypt = Convert.FromBase64String(texto);

            try

            {

                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();

                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);

            }

            finally

            {

                TDESAlgorithm.Clear();

                HashProvider.Clear();

            }

            return UTF8.GetString(Results);

        }

        public static string recuperaIpUsuario()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
            {
                // Conexão sem utilizar proxy 
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

        }

        public static string acentosJavaScript(string mensagem)
        {
            mensagem = mensagem.Replace('á', '\u00e1');
            mensagem = mensagem.Replace('à', '\u00e0');
            mensagem = mensagem.Replace('â', '\u00e2');
            mensagem = mensagem.Replace('ã', '\u00e3');
            mensagem = mensagem.Replace('ä', '\u00e4');
            mensagem = mensagem.Replace('Á', '\u00c1');
            mensagem = mensagem.Replace('À', '\u00c0');
            mensagem = mensagem.Replace('Â', '\u00c2');
            mensagem = mensagem.Replace('Ã', '\u00c3');
            mensagem = mensagem.Replace('Ä', '\u00c4');
            mensagem = mensagem.Replace('é', '\u00e9');
            mensagem = mensagem.Replace('è', '\u00e8');
            mensagem = mensagem.Replace('ê', '\u00ea');
            mensagem = mensagem.Replace('ê', '\u00ea');
            mensagem = mensagem.Replace('É', '\u00c9');
            mensagem = mensagem.Replace('È', '\u00c8');
            mensagem = mensagem.Replace('Ê', '\u00ca');
            mensagem = mensagem.Replace('Ë', '\u00cb');
            mensagem = mensagem.Replace('í', '\u00ed');
            mensagem = mensagem.Replace('ì', '\u00ec');
            mensagem = mensagem.Replace('î', '\u00ee');
            mensagem = mensagem.Replace('ï', '\u00ef');
            mensagem = mensagem.Replace('Í', '\u00cd');
            mensagem = mensagem.Replace('Ì', '\u00cc');
            mensagem = mensagem.Replace('Î', '\u00ce');
            mensagem = mensagem.Replace('Ï', '\u00cf');
            mensagem = mensagem.Replace('ó', '\u00f3');
            mensagem = mensagem.Replace('ò', '\u00f2');
            mensagem = mensagem.Replace('ô', '\u00f4');
            mensagem = mensagem.Replace('õ', '\u00f5');
            mensagem = mensagem.Replace('ö', '\u00f6');
            mensagem = mensagem.Replace('Ó', '\u00d3');
            mensagem = mensagem.Replace('Ò', '\u00d2');
            mensagem = mensagem.Replace('Ô', '\u00d4');
            mensagem = mensagem.Replace('Õ', '\u00d5');
            mensagem = mensagem.Replace('Ö', '\u00d6');
            mensagem = mensagem.Replace('ú', '\u00fa');
            mensagem = mensagem.Replace('ù', '\u00f9');
            mensagem = mensagem.Replace('û', '\u00fb');
            mensagem = mensagem.Replace('ü', '\u00fc');
            mensagem = mensagem.Replace('Ú', '\u00da');
            mensagem = mensagem.Replace('Ù', '\u00d9');
            mensagem = mensagem.Replace('Û', '\u00db');
            mensagem = mensagem.Replace('ç', '\u00e7');
            mensagem = mensagem.Replace('Ç', '\u00c7');
            mensagem = mensagem.Replace('ñ', '\u00f1');
            mensagem = mensagem.Replace('Ñ', '\u00d1');
            mensagem = mensagem.Replace('&', '\u0026');
            mensagem = mensagem.Replace('\'', '\u0027');
            return mensagem;
        }
    }
}
