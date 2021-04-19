using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_module2.Models
{
    public class Rectangle : Forme
    {

        public virtual int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double Aire => Largeur * Longueur;

        public override double Perimetre => 2 * Largeur + 2 * Longueur;

        public override string ToString()
        {
            return ToString(false);
        }

        protected string ToString(bool fromCarre)
        {
            if (fromCarre)
                return base.ToString();
            return $"Rectangle de longueur={Longueur} et largeur={Largeur}" + Environment.NewLine + base.ToString();
        }
    }
}
