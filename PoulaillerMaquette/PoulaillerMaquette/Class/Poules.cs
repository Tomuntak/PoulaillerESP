using System;
using System.Collections.Generic;


namespace PoulaillerMaquette.Class
{
    public partial class Poules
    {
        public Poules()
        {
            
        }
    
        public int IDPoule { get; set; }

        public string Nom { get; set; }

        public DateTime DateArrivee { get; set; }

        public DateTime DateDepart { get; set; }

        public double Poids { get; set; }

    }
}

