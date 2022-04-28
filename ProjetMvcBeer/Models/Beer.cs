using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProjetMvcBeer.Models
{
    public class Beer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeerID { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Titre")]
        [Required]
        public string Title { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "Catégorie")]
        [StringLength(30)]
        public string Category { get; set; }

        [Display(Name = "Image")]
        public string Image {get; set;}

        
        [Display(Name = "Prix")]
        [DataType(DataType.Currency)]
        [Required]
        public float Price { get; set; }


        [Display(Name = "Degrée d'alcool")]
        [Required]
        public float AlcoolDegree { get; set; }

        [Display(Name = "Quantité (en cl)")]
        [Required]
        public int Size { get; set; }


        
        public List<LigneDeVieDevis> ListLigneDeVieDevis { get; set; }


    }



}