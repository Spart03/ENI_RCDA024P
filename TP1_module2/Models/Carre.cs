using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_module2.Models
{
    public class Carre : Rectangle
    {
        public override int Largeur => Longueur;

        public override string ToString()
        {
            return $"Carré de coté={Longueur}" + Environment.NewLine + base.ToString();
        }
    }
}
