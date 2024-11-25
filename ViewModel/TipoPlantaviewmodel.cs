using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGrupoTostadora.ViewModel
{
    public class TipoPlantaviewmodel
    {
        public int TipoPlantaId { get; set; }
        public string Nombre { get; set; }
        public string Caracteristicas { get; set; }
        public string Habitat { get; set; }
        public string ClimaIdeal { get; set; }
        public bool EsComestible { get; set; }

    }

}
