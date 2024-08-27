using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tu_Estacionamiento.Models
{
    public class Logs
    {
        public int Id { get; set; }
        public string Create_by { get; set; }
        public string Description { get; set; }
        public string To { get; set; }
        public string Time { get; set; }
        public string Active { get; set; }
    }
}
