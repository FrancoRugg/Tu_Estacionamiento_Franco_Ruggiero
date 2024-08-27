using Abm.Builder.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tu_Estacionamiento_Services.Handlers;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SqliteHandler.ConnectionString = "Data Source=" + Application.StartupPath + "\\Database\\TuEstacionamiento.db";
            SqlBuilderHandler.ConnectionString = SqliteHandler.ConnectionString;
            Application.EnableVisualStyles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUserLogin());
        }
    }
}
