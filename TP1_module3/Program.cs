﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_module3.BO;

namespace TP1_module3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitialiserDatas();

            //Afficher liste des prenoms des auteurs dont le nom commencant par G
            var prenoms = ListeAuteurs.Where(x => x.Nom.StartsWith("G")).Select(x => x.Prenom);
            Console.WriteLine("Afficher liste des prenoms des auteurs dont le nom commençant par G");
            foreach(var prenom in prenoms)
            {
                Console.WriteLine(prenom);
            }
            Console.WriteLine();

            //Auteur qui a écrit le plus de livres
            var auteurBcpLivres = ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).FirstOrDefault().Key;
            Console.WriteLine("Auteur qui a ecrit le plus de livres");
            Console.WriteLine($"{auteurBcpLivres.Prenom} {auteurBcpLivres.Nom}");
            Console.WriteLine();

            //Nombre moyen de pages par livres par auteur
            var livresParAuteur = ListeLivres.GroupBy(x => x.Auteur);
            Console.WriteLine("Nombre moyen de pages par livres par auteur");
            foreach(var item in livresParAuteur)
            {
                Console.WriteLine($"{item.Key.Prenom} {item.Key.Nom} moyennes des pages = {item.Average(x => x.NbPages) }");
            }
            Console.WriteLine();

            //Titre du livre avec le plus de pages
            var maxPage = ListeLivres.OrderByDescending(x => x.NbPages).First();
            Console.WriteLine("Titre du livre avec le plus de pages");
            Console.WriteLine(maxPage.Titre);
            Console.WriteLine();

            //Combien ont gagné les auteurs en moyenne
            var moyenne = ListeAuteurs.Where(x => x.Factures.Count > 0).Average(x => x.Factures.Average(y => y.Montant));
            Console.WriteLine("Combien ont gagné les auteurs en moyenne");
            Console.WriteLine(moyenne);
            Console.WriteLine();

            //Afficher les auteurs et la liste de leurs livres
            Console.WriteLine("Afficher les auteurs et la liste de leurs livres");
            var livresParAuteur2 = ListeLivres.GroupBy(x => x.Auteur);
            foreach (var livres in livresParAuteur2)
            {
                Console.WriteLine($"Auteur : {livres.Key.Prenom} {livres.Key.Nom} ");
                foreach (var livre in livres)
                {
                    Console.WriteLine($" - {livre.Titre}");
                }
            }
            Console.WriteLine();







            Console.ReadKey();
        }

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
