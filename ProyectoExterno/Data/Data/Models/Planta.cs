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
    [Table("Planta")]
    public class Planta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string ImagenUrl { get; set; }
        public string Tamaño { get; set; } 
        public bool Disponible { get; set; } 

        public int TipoPlantaId { get; set; }

        [ForeignKey("TipoPlantaId")]
        public virtual TipoPlanta? TipoPlanta { get; set; }
    }

}
