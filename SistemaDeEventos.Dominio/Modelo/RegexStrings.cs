using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaDeEventos.Dominio.Modelo {
    public class RegexStrings {
        static public Regex regMail = new Regex(@".*@(.*(\.|))*", RegexOptions.IgnoreCase);
        static public Regex regSenha = new Regex(@"[a-zA-z0-9]{6,}", RegexOptions.IgnoreCase);
    }
}
