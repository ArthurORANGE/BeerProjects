using ProjetMvcBeer.Models;
using System;
using System.Linq;

namespace ProjetMvcBeer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjetMvcBeerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any devis.
            if (context.Devis.Any())
            {
                return;   // DB has been seeded
            }


            var devis = new Devis[]
            {
            new Devis{Title="Week-END ski",CreationDate=DateTime.Parse("2010-09-01"),ClientName="Hugo BLANC",},
            new Devis{Title="Gala ENSC",CreationDate=DateTime.Today,ClientName="McFLy et Carlito"},
            new Devis{Title="CALA'BAR",CreationDate=DateTime.Parse("2021-10-04"),ClientName="Loïc JACOB"},
            new Devis{Title="Soirée BDS",CreationDate=DateTime.Parse("2021-09-12"),ClientName="Président BDS"},
            new Devis{Title="Soirée Pyjama BDE",CreationDate=DateTime.Parse("2022-01-01"),ClientName="Président BDE"},
            new Devis{Title="Séminaire",CreationDate=DateTime.Parse("2021-06-21"),ClientName="Benoit Leblanc"},
            new Devis{Title="CALA'BAR",CreationDate=DateTime.Now,ClientName="Respo Foyer"},
            new Devis{Title="CALA'BAR",CreationDate=DateTime.Parse("2021-10-20"),ClientName="Respo Foyer"},
            new Devis{Title="Best Soirée de l'école",CreationDate=DateTime.Now,ClientName="Président BDS"},
            new Devis{Title="Trafic",CreationDate=DateTime.Now,ClientName="Johny Boy"},
            new Devis{Title="CALA'BAR",CreationDate=DateTime.Parse("2020-03-10"),ClientName="Respo Foyer"},
            };
            foreach (Devis d in devis)
            {
                context.Devis.Add(d);
            }
            context.SaveChanges();


            var beer = new Beer[]
            {
            new Beer{BeerID=1,Title = "Corona",Category = "Blonde",Price = (float)4.50,AlcoolDegree=(float)4.6,Size=33, Image="https://www.liquor.com/thmb/NTSanfXplDUgy_zXlV0wNxVQ8js=/735x0/single-bottle-reviews_Corona_main_720x720-29aca7643ea141ee97c2053561f3197e.jpg"},
            new Beer{BeerID=2,Title = "Leffe Ruby",Category = "Rouge",Price = (float)4.90,AlcoolDegree=(float)5.0,Size=75},
            new Beer{BeerID=3,Title = "Delirium",Category = "Blonde",Price = (float)2.80,AlcoolDegree=(float)8.5,Size=33},
            new Beer{BeerID=4,Title = "Chouffe",Category = "Blonde",Price = (float)2.10,AlcoolDegree=(float)8.0,Size=33},
            new Beer{BeerID=5,Title = "1664",Category = "Blonde",Price = (float)2.20,AlcoolDegree=(float)5.5,Size=33},
            new Beer{BeerID=6,Title = "3 Monts",Category = "Blonde",Price = (float)5.45,AlcoolDegree=(float)8.5,Size=75},
            new Beer{BeerID=7,Title = "Bavaria",Category = "Blonde",Price = (float)4.3,AlcoolDegree=(float)8.6,Size=75},
            new Beer{BeerID=8,Title = "Gifle",Category = "Brune",Price = (float)2.20,AlcoolDegree=(float)5.0,Size=33},
            new Beer{BeerID=9,Title = "Achel",Category = "Ambrée",Price = (float)3.20,AlcoolDegree=(float)8.6,Size=33},
            new Beer{BeerID=10,Title = "Affligem",Category = "Blonde",Price = (float)2.70,AlcoolDegree=(float)7.0,Size=33},
            new Beer{BeerID=11,Title = "Akerbeltz Blonde",Category = "Ambrée",Price = (float)3.20,AlcoolDegree=(float)7.0,Size=33},
            new Beer{BeerID=12,Title = "Akerbeltz Blanche",Category = "Blanche",Price = (float)3.0,AlcoolDegree=(float)4.0,Size=33},
            new Beer{BeerID=13,Title = "Aldaric",Category = "Brune",Price = (float)2.80,AlcoolDegree=(float)7.0,Size=33},
            new Beer{BeerID=14,Title = "Belzebuth",Category = "Blonde",Price = (float)4.10,AlcoolDegree=(float)13.0,Size=33},
            new Beer{BeerID=15,Title = "Chimay",Category = "Brune",Price = (float)3.20,AlcoolDegree=(float)9.0,Size=33},
            new Beer{BeerID=16,Title = "Gulden Draak",Category = "Ambrée",Price = (float)5.40,AlcoolDegree=(float)10.5,Size=33},
            new Beer{BeerID=17,Title = "Guiness Draught",Category = "Noire",Price = (float)3.20,AlcoolDegree=(float)4.2,Size=33},
            new Beer{BeerID=18,Title = "Kastel Blonde",Category = "Blonde",Price = (float)5.20,AlcoolDegree=(float)11.0,Size=33},
            new Beer{BeerID=19,Title = "Queue de Charrue",Category = "Brune",Price = (float)2.20,AlcoolDegree=(float)5.4,Size=33},
            new Beer{BeerID=20,Title = "Trois Pistoles",Category = "Brune",Price = (float)3.60,AlcoolDegree=(float)9.0,Size=33},

            };
            foreach (Beer b in beer)
            {
                context.Beer.Add(b);
            }
            context.SaveChanges();

            var ligneDeVieDevis = new LigneDeVieDevis[]
            {
            new LigneDeVieDevis{DevisID=1,BeerID=1,Quantity=40},
            new LigneDeVieDevis{DevisID=1,BeerID=2,Quantity=20},
            new LigneDeVieDevis{DevisID=1,BeerID=4,Quantity=35},
            new LigneDeVieDevis{DevisID=1,BeerID=5,Quantity=40},
            new LigneDeVieDevis{DevisID=2,BeerID=3,Quantity=56},
            new LigneDeVieDevis{DevisID=2,BeerID=4,Quantity=40},
            new LigneDeVieDevis{DevisID=2,BeerID=5,Quantity=78},
            new LigneDeVieDevis{DevisID=3,BeerID=20,Quantity=25},
            new LigneDeVieDevis{DevisID=3,BeerID=2,Quantity=40},
            new LigneDeVieDevis{DevisID=3,BeerID=3,Quantity=11},
            new LigneDeVieDevis{DevisID=3,BeerID=4,Quantity=9},
            new LigneDeVieDevis{DevisID=4,BeerID=7,Quantity=9},
            new LigneDeVieDevis{DevisID=4,BeerID=7,Quantity=9},
            new LigneDeVieDevis{DevisID=4,BeerID=9,Quantity=19},
            new LigneDeVieDevis{DevisID=4,BeerID=12,Quantity=6},
            new LigneDeVieDevis{DevisID=4,BeerID=1,Quantity=4},
            new LigneDeVieDevis{DevisID=4,BeerID=5,Quantity=22},
            new LigneDeVieDevis{DevisID=5,BeerID=13,Quantity=9},
            new LigneDeVieDevis{DevisID=5,BeerID=20,Quantity=2},
            new LigneDeVieDevis{DevisID=5,BeerID=19,Quantity=30},
            new LigneDeVieDevis{DevisID=6,BeerID=19,Quantity=30},
            new LigneDeVieDevis{DevisID=6,BeerID=7,Quantity=30},
            new LigneDeVieDevis{DevisID=6,BeerID=14,Quantity=8},
            new LigneDeVieDevis{DevisID=6,BeerID=11,Quantity=22},
            new LigneDeVieDevis{DevisID=6,BeerID=17,Quantity=51},
            new LigneDeVieDevis{DevisID=7,BeerID=16,Quantity=30},
            new LigneDeVieDevis{DevisID=7,BeerID=13,Quantity=100},
            new LigneDeVieDevis{DevisID=7,BeerID=2,Quantity=340},
            new LigneDeVieDevis{DevisID=7,BeerID=9,Quantity=200},
            new LigneDeVieDevis{DevisID=8,BeerID=1,Quantity=50},
            new LigneDeVieDevis{DevisID=8,BeerID=7,Quantity=40},
            new LigneDeVieDevis{DevisID=8,BeerID=14,Quantity=80},
            new LigneDeVieDevis{DevisID=8,BeerID=18,Quantity=76},
            new LigneDeVieDevis{DevisID=8,BeerID=5,Quantity=29},
            new LigneDeVieDevis{DevisID=8,BeerID=8,Quantity=48},
            new LigneDeVieDevis{DevisID=9,BeerID=11,Quantity=20},
            new LigneDeVieDevis{DevisID=9,BeerID=6,Quantity=10},
            new LigneDeVieDevis{DevisID=10,BeerID=1,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=3,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=20,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=7,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=9,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=11,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=13,Quantity=30},
            new LigneDeVieDevis{DevisID=10,BeerID=15,Quantity=30},
            new LigneDeVieDevis{DevisID=11,BeerID=20,Quantity=130},
            new LigneDeVieDevis{DevisID=11,BeerID=18,Quantity=320},
            
            };
            foreach (LigneDeVieDevis l in ligneDeVieDevis)
            {
                context.LigneDeVieDevis.Add(l);
            }
            context.SaveChanges();


            var compte = new MonCompte[]
            {
            new MonCompte{Nom="Stanley",Prenom="Clyde",Email="clyde.stanley@gmail.com",Age=22, Adresse="24 rue rene goblet TALENCE"},
            
            
            };
            foreach (MonCompte c in compte)
            {
                context.MonCompte.Add(c);
            }
            context.SaveChanges();



    
        }
    }
}