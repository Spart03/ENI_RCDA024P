using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DojoClassLibrary.Entities;

namespace TP_dojo_module6.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? ArmeId { get; set; }

    }
}