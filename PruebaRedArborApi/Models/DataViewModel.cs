using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaRedArborApi.Models
{
    public class DataViewModel
    {
        public int Id_Empleado { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        [MaxLength(100)]
        public string Contraseña { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string Ultimo_Login { get; set; }

        public string Fecha_Creacion { get; set; }

        public string Fecha_Actualiza { get; set; }

        public string Fecha_Elimina { get; set; }

        public int Id_Rol { get; set; }

        public int Id_Estado { get; set; }

       
    }
}
