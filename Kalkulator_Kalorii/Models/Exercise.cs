using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalkulator_Kalorii.Models
{
    public class Exercise
    {
        [Key]
        [ScaffoldColumn(false)]
        public int exerciseID { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name ="Ćwiczenie")]
        public string name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name ="Spalone kalorie (kcal w 60 min)")]
        public int calories { get; set; }
    }
}