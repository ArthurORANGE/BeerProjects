using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ProjetMvcBeer.Data;


namespace ProjetMvcBeer.Models
{
    public class LigneDeVieDevis
    {
        public int LigneDeVieDevisID { get; set; }

        [Display(Name = "Quantité")]
        [Required]
        public int Quantity { get; set; }



        public int BeerID { get; set; }
        public int DevisID { get; set; }
        public Beer Beer { get; set; }
        public Devis Devis { get; set; }

    }
}