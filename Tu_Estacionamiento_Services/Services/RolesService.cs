using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tu_Estacionamiento_Services.Handlers;

namespace Tu_Estacionamiento_Services.Services
{
    public class RolesService
    {
        public string GetRolName(string rol)
        {
            string query = $"select RoleName from Roles where Id = {rol}";
            string result = SqliteHandler.GetScalar(query);

            return result;
        }
        public DataTable GetRoles()
        {
            return SqliteHandler.GetDt("SELECT * from Roles WHERE Active = '1';");
        }
        public string CountAdmin()
        {
            string query = $"select count (*) as Total from Roles where RoleName = 'Admin'";

            string result = SqliteHandler.GetScalar(query);

            return result;
        }
    }
}
