using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ProjetMvcBeer.Data;

namespace ProjetMvcBeer.Models
{
    public class MonCompte
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Nom")]
        [Required]
        public string Nom { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "prénom")]
        [StringLength(30)]
        public string Prenom { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        
        [Display(Name = "Age")]
        [Required]
        public int Age { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "Adresse")]
        [StringLength(100)]
        public string Adresse { get; set; }

    }
}