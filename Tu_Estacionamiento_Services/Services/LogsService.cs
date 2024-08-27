using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tu_Estacionamiento_Services.Handlers;

namespace Tu_Estacionamiento_Services.Services
{
    public class LogsService
    {
        public bool CreateLog(string Create_by,string Description, string To,string Action)
        {
            string query = $"insert into Logs(Create_by,Description,`To`,`Action`,Active) values (" +
                $"'{Create_by}'," +
                $"'{Description}'," +
                $"'{To}'," +
                $"'{Action}'," +
                $"'1');";
            return SqliteHandler.Exec(query);
        }
        public DataTable GetLogs()
        {
            return SqliteHandler.GetDt("SELECT Create_by as Ejecutado_Por,Description as Descripcion,`To` as Usuario_Modificado,`Time` as Horario,`Action` as Accion_Realizada from Logs;");
        }
        public DataTable BuscarPorFiltro(string clave, string valor)
        {
            string query = $"select Create_by as Ejecutado_Por,Description as Descripcion,`To` as Usuario_Modificado,`Time` as Horario,`Action` as Accion_Realizada from Logs where {clave} like '%{valor}%';";
            return SqliteHandler.GetDt(query);
        }
    }
}
