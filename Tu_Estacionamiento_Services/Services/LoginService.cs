using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tu_Estacionamiento.Models;
using Tu_Estacionamiento.Models.DTO;
using Tu_Estacionamiento_Services.Handlers;

namespace Tu_Estacionamiento_Services.Services
{
    public class LoginService
    {
		public bool Login(UserDTO login)
		{
			string query = $"select count (*) as Total from Users where Usuario = " +
				$"'{login.Usuario}' and Password = " +
				$"'{login.Password}' and Active = '1'";

			string result = SqliteHandler.GetScalar(query);

			if (result == "0")
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public string CountUsers()
		{
			string query = $"select count (*) as Total from Users where Active = '1'";

			string result = SqliteHandler.GetScalar(query);

			return result;
		}
		public string CountAdmin()
		{
			string query = $"select count (*) as Total from Users where Rol= '1'";

			string result = SqliteHandler.GetScalar(query);

			return result;
		}
		public string CountBasic()
		{
			string query = $"select count (*) as Total from Users where Rol= '2'";

			string result = SqliteHandler.GetScalar(query);

			return result;
		}
		public bool CheckRegister(UserDTO login)
		{
			string query = $"select count (*) as Total from Users where Usuario = " +
				$"'{login.Usuario}' and Active = '1'";

			string result = SqliteHandler.GetScalar(query);

			if (result == "0")
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public string GetUserRol(string User)
		{
			string query = $"select Rol from Users where Usuario = '{User}'";
			string result = SqliteHandler.GetScalar(query);

			return result;
		}
		public string GetUserById(int Client_id)
		{
			string query = $"select Usuario from Users where Id = '{Client_id}'";
			string result = SqliteHandler.GetScalar(query);

			return result;
		}
		public Login GetUserInfo(string Id)
		{
			string query = $"select * from Users where Id = '{Id}'";
            DataTable result = SqliteHandler.GetDt(query);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                Login lugar = new Login
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Usuario = row["Usuario"].ToString(),
                    Password = row["Password"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Dni = row["Dni"].ToString(),
                    Rol = Convert.ToInt32(row["Rol"]),
                    Active = row["Active"].ToString()
                };

                return lugar;
            }

            return null;
		}
		public bool EliminarUsuario(string id)
		{
			return SqliteHandler.Exec($"delete from Users where Id =" + id);
		}
		public DataTable TraerUsuarios()
		{
			return SqliteHandler.GetDt("SELECT * from Users;");
		}

		public bool EditarUsuario(Login login)
		{
			string query = $"update Users set Usuario = '{login.Usuario}', Password = '{login.Password}',Nombre = '{login.Nombre}',Apellido='{login.Apellido}',Dni= '{login.Dni}',Rol='{login.Rol}',Active = '{login.Active}' WHERE Id = {login.Id};";
			return SqliteHandler.Exec(query);
		}
		public bool CrearUsuario(Login nuevoUsuario)
		{
			UserDTO userDTO = new UserDTO();
			userDTO.Usuario = nuevoUsuario.Usuario;
			userDTO.Password = nuevoUsuario.Password;

			bool existe = CheckRegister(userDTO);

			if (!existe)
			{
				string query = $"insert into Users values (null," +
					$"'{nuevoUsuario.Usuario}'," +
					$"'{EncriptHandler.Base64Encode(nuevoUsuario.Password)}'," +
					$"'{nuevoUsuario.Nombre}'," +
					$"'{nuevoUsuario.Apellido}'," +
					$"'{nuevoUsuario.Dni}'," +
					$"'{nuevoUsuario.Rol}'," +
					$"'{nuevoUsuario.Active}')";

				bool result = SqliteHandler.Exec(query);

				if (!result)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		}
	}
}
