using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ProjetMvcBeer.Data;


namespace ProjetMvcBeer.Models
{
    public class Devis
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Titre")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Date de publication")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }


        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Nom du client")]
        [Required]
        public string ClientName { get; set; }
        
        [Display(Name = "Les bières de votre commande : ")]
        public List<LigneDeVieDevis> ListeLigneDeVieDevis { get; set; }

        public float calculTotalPrice ()
        {
            float totalPrice=0;
            foreach (LigneDeVieDevis l in ListeLigneDeVieDevis)
            {
                totalPrice+=(l.Beer.Price)*(l.Quantity);
            }
            return totalPrice;
        }

    }
}