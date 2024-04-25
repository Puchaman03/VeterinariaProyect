using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.VETE
{
    public class Mascota
    {
        [Range(0, int.MaxValue, ErrorMessage = "Error en el registro de dueños")]
        [Display(Name = "Codigo de Dueño")]
        public int IdMascotaDueño { get; set; }

        [Required(ErrorMessage = "Debe poner el nombre de la mascota")]
        [Display(Name = "Nombre de la Mascota")]
        public string MNombre { get; set; }= string.Empty;


        [Required(ErrorMessage = "Debe poner la especie de la mascota")]
        [Display(Name = "Especie")]
        public string Especie { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe poner la raza de la mascota")]
        [Display(Name = "Raza")]
        public string Raza { get; set; } = string.Empty;

    }
}
