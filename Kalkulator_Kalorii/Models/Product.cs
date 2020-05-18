using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalkulator_Kalorii.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int productID { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name ="Produkt")]
        public string name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name ="Kalorie [kcal] w 100g")]
        public int calories { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(0, 100, ErrorMessage =" Składnik powiniem wynosić od 0 do 100")]
        [Display(Name ="Białko [g]")]
        public float protein { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(0, 100, ErrorMessage = " Składnik powiniem wynosić od 0 do 100")]
        [Display(Name ="Węglowodany [g]")]
        public float carbs { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Range(0, 100, ErrorMessage = " Składnik powiniem wynosić od 0 do 100")]
        [Display(Name ="Tłuszcze [g]")]
        public float fats { get; set; }
    }
}