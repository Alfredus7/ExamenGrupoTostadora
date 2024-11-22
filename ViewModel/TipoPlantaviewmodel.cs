using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGrupoTostadora.ViewModel
{
    [Table("TipoPlanta")]
    public class TipoPlantaviewmodel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoPlantaId { get; set; }
        public string Descripcion { get; set; }

    }

}
