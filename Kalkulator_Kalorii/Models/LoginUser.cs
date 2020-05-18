using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalkulator_Kalorii.Models
{
    public class LoginUser
    {
        [Key]
        [Display(Name = "ID")]
        public int LoginID { get; set; }

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        [Display(Name ="Nazwa użytkownika")]
        public string username { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [Display(Name ="Hasło")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage ="Hasło należy powtórzyć.")]
        [Display(Name = "Powtórz hasło")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Hasło i potwierdzenie hasła nie pasują do siebie")]
        public string confirmPassword { get; set; }
    }
}