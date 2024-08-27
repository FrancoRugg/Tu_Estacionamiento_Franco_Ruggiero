using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tu_Estacionamiento_Franco_Ruggiero.Handlers
{
    public class DatosGlobales
    {
        public static string UsuarioLogeado = string.Empty;
        public static string RolUsuario = string.Empty;
        
        public static List<string> VistasPermitidas { get; set; } = new List<string>();
    }
}
