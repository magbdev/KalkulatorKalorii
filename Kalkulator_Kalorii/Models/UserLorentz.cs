using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalkulator_Kalorii.Models
{
    public class UserLorentz
    {
        [Display(Name = "Wzrost (w cm)")]
        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1, 250, ErrorMessage = "Wzrost powinien być w przedziale 1-250")]
        public float growth { get; set; }

        [Display(Name = "Płeć")]
        public _gender gender { get; set; }

        [Display(Name = "Należna masa ciała")]
        public float lorentz { get; set; }
    }

}