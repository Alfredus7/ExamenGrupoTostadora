using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("TipoPlanta")]
    public class TipoPlantaDTOS
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoPlantaId { get; set; }
        public string Nombre { get; set; }

        public string Caracteristicas { get; set; }
        public string Habitat { get; set; }
        public string ClimaIdeal { get; set; }
        public bool EsComestible { get; set; }


    }

}
