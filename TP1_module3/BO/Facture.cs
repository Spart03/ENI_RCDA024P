using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_module3.BO
{
    public class Facture
    {
        public Decimal Montant { get; set; }
        public Auteur Auteur { get; set; }

        public Facture(Decimal montant, Auteur auteur)
        {
            this.Montant = montant;
            this.Auteur = auteur;
        }
    }
}
