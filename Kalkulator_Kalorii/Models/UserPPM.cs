using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalkulator_Kalorii.Models
{
    public class UserPPM
    {
        [Display(Name ="Waga")]
        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1,300,ErrorMessage = "Waga powinna być w przedziale 1-300")]
        public int weight { get; set; }

        [Display(Name ="Wzrost (w cm)")]
        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1,250,ErrorMessage = "Wzrost powinien być w przedziale 1-250")]
        public float growth { get; set; }

        [Display(Name ="Wiek")]
        [Required(ErrorMessage = "Pole wymagane")]
        [Range(1,100,ErrorMessage = "Wiek powinien być w przedziale 1-100")]
        public int age { get; set; }

        [Display(Name ="Płeć")]
        public _gender gender { get; set; }

        [Display(Name ="Wskaźnik Podstawowej Przemiany Materii")]
        public float ppm { get; set; }
    }
    public enum _gender
    {
        kobieta,
        mężczyzna
    }
}