using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProjetMvcBeer.Models
{
    public class BeerCategoryViewModel
    {
        public List<Beer> Beers { get; set; }
        
        public SelectList Category { get; set; }
        public string BeerCategory { get; set; }


        public SelectList Alcools { get; set; }
        public float BeerAlcoolDegree { get; set; }

        public SelectList Images {get; set;}
        public string BeerImage {get; set;}


        public string SearchString { get; set; }
    }
}