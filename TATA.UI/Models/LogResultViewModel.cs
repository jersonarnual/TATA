using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TATA.Infraestructure.DTO;

namespace TATA.UI.Models
{
    public class LogResultViewModel
    {
        [Display(Name ="Cadena de texto")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Sentence { get; set; }

        public List<DetailsLogDTO> details { get; set; }
    }
}
