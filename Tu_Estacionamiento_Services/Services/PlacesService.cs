using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tu_Estacionamiento.Models;
using Tu_Estacionamiento_Services.Handlers;

namespace Tu_Estacionamiento_Services.Services
{
    public class PlacesService
    {
        public List<Places> TraerLugares()
        {
            List<Places> lugares = new List<Places>();

            DataTable dt = SqliteHandler.GetDt("SELECT * from Places;");

            //Console.WriteLine($"Número de filas obtenidas: {dt.Rows.Count}");

            foreach (DataRow row in dt.Rows)
            {
                Places lugar = new Places
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Place_number = Convert.ToInt32(row["Place_number"]),
                    Client_id = Convert.ToInt32(row["Client_id"]),
                    Plate_number = row["Plate_number"].ToString(),
                    Pay_day = row["Pay_day"].ToString(),
                    Observation = row["Observation"].ToString(),
                    Active = row["Active"].ToString()
                };

                lugares.Add(lugar);
            }

            return lugares;
        }

        public Places TraerLugar(string placeNumber)
        {
            DataTable dt = SqliteHandler.GetDt($"SELECT * FROM Places WHERE Place_number = {placeNumber};");

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Places lugar = new Places
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Place_number = Convert.ToInt32(row["Place_number"]),
                    Client_id = Convert.ToInt32(row["Client_id"]),
                    Plate_number = row["Plate_number"].ToString(),
                    Pay_day = row["Pay_day"].ToString(),
                    Observation = row["Observation"].ToString(),
                    Active = row["Active"].ToString()
                };

                return lugar;
            }

            return null;
        }

        public bool EditarLugar(Places places)
        {
            string query = $"update Places set Place_number = {places.Place_number}, Client_id = {places.Client_id},Plate_number = '{places.Plate_number}',Pay_day='{places.Pay_day}',Observation='{places.Observation}',Active = {places.Active} WHERE Place_number = {places.Place_number};";
            return SqliteHandler.Exec(query);
        }

        public Places GetOldChanges(int Place_number)
        {
            string query = $"select * from Places where Place_number = '{Place_number}'";

            DataTable result = SqliteHandler.GetDt(query);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                Places lugar = new Places
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Place_number = Convert.ToInt32(row["Place_number"]),
                    Client_id = Convert.ToInt32(row["Client_id"]),
                    Plate_number = row["Plate_number"].ToString(),
                    Pay_day = row["Pay_day"].ToString(),
                    Observation = row["Observation"].ToString(),
                    Active = row["Active"].ToString()
                };

                return lugar;
            }

            return null;
        }
        public string CountLibre()
        {
            string query = $"select count (*) as Total from Places where Plate_number = '-'";

            string result = SqliteHandler.GetScalar(query);

            return result;
        }
        public string CountOcupados()
        {
            string query = $"select count (*) as Total from Places where Plate_number <> '-'";

            string result = SqliteHandler.GetScalar(query);

            return result;
        }
        public DataTable GetAllPlaces()
        {
            return SqliteHandler.GetDt("SELECT p.Place_number as Lugar,u.Usuario as Usuario,p.Plate_number as Num_Patente,p.Pay_day as Dia_de_Pago,p.Observation as Observacion from Places as p INNER JOIN Users as u on U.Id = P.Client_id;");
        }
    }
}
