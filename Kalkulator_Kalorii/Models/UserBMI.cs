using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalkulator_Kalorii.Models
{
    public class UserBMI
    {
        [Display(Name = "Waga")]
        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1, 300, ErrorMessage = "Waga powinna być w przedziale 1-300")]
        public int weight { get; set; }

        [Display(Name = "Wzrost (w m)")]
        [Required(ErrorMessage = "Pole wymagane")]
        [Range(0.01, 2.5, ErrorMessage = "Wzrost powinien być w przedziale 0,01-2,5")]
        public float growth { get; set; }

        [Display(Name = "Wskaźnik bmi")]
        public float bmi { get; set; }

    }
}