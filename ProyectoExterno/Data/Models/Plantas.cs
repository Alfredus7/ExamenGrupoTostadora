using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Planta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoPlantaId { get; set; }

        [ForeignKey("TipoPlantaId")]
        public virtual TipoPlanta? TipoPlanta { get; set; }
    }

}
