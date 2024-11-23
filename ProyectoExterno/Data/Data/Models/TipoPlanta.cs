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
    public class TipoPlanta
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoPlantaId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Planta>? Plantas { get; set; }



    }

}
