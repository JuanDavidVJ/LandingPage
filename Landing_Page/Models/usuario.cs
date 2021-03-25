using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landing_Page.Models
{
    public class usuario
    {
        public string nombre { get; set; }

        public string celular { get; set; }


        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string email { get; set; }

        public string ciudad { get; set; }

      

    }
}