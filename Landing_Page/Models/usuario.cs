using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landing_Page.Models
{
    public class usuario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "EL nombre es obligatorio")]
        [MinLength(10, ErrorMessage = "EL nombre de usuario debe tener al menos 10 caracteres")]
        public string Nombre { get; set; }
       

        [Required(ErrorMessage = "Es obligatorio el Email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un Email valido")]

        public string Email { get; set; }

        
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatoria la Ciudad")]
        public string Ciudad { get; set; }

      




    }
}

  