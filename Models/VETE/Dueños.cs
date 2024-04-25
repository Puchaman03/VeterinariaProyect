using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.VETE
{
    public class Dueños
    {
        [Range(0, int.MaxValue, ErrorMessage = "Error en el registro de dueños")]
        [Display(Name = "Codigo de Dueño")]
        public int IdDueño { get; set; }

        [Required(ErrorMessage ="Debe poner el nombre del dueño")]
        [Display(Name = "Nombre del dueño")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe poner el apellido del dueño")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe poner la direccion del dueño")]
        [Display(Name = "Direccion")]

        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe poner el nombre del dueño")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; } = string.Empty;

        // propiedad de navegacion
        public Mascota? Mascota { get; set; }
    }
}
