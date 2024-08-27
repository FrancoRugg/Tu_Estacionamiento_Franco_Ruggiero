using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tu_Estacionamiento.Models
{
    public class Places
    {
        public int Id { get; set; }
        public int Place_number { get; set; }
        public int Client_id { get; set; }
        public string Plate_number { get; set; }
        public string Pay_day { get; set; }
        public string Observation { get; set; }
        public string Active { get; set; }
    }
}
