using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_module3.BO
{
    public class Livre
    {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public Auteur Auteur { get; set; }
        public int NbPages { get; set; }

        public Livre (int id, string titre, string synopsis, Auteur auteur, int nbpages)
        {
            this.Id = id;
            this.Titre = titre;
            this.Synopsis = synopsis;
            this.Auteur = auteur;
            this.NbPages = nbpages;

        }
    }
}
