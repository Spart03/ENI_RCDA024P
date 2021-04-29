using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaClassLibrary.Entities;


namespace TP_pizza_module5.Models
{
    public class PizzaVM
    {
        
            public Pizza Pizza { get; set; }
            public List<Pate> Pates { get; set; }
            public List<SelectListItem> Ingredients { get; set; }

            
            public List<int> IngredientIds { get; set; }
        
    }
}