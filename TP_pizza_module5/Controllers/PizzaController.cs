using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using TP_pizza_module5.Models;
using PizzaClassLibrary.Entities;
using PizzaClassLibrary.Utils;

namespace TP_pizza_module5.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM vm = new PizzaVM();
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Pates = FakeDb.Instance.Pates;

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM vm)
        {
            if(this.OtherValidations(ModelState, vm))
            {
                try
                {
                    vm.Pizza.Pate = FakeDb.Instance.Pates.SingleOrDefault(x => x.Id == vm.Pizza.Pate.Id);
                    vm.Pizza.Ingredients = FakeDb.Instance.Ingredients.Where(x => vm.IngredientIds.Contains(x.Id)).ToList();

                    if (FakeDb.Instance.Pizzas.Count <= 0)
                    {
                        vm.Pizza.Id = 1;
                    }
                    else
                    {
                        vm.Pizza.Id = FakeDb.Instance.Pizzas.Max(x => x.Id) + 1;
                    }


                    FakeDb.Instance.Pizzas.Add(vm.Pizza);

                    return RedirectToAction("Index");
                }
                catch
                {
                    vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    vm.Pates = FakeDb.Instance.Pates;
                    return View(vm);
                }
            }
            else
            {
                vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                vm.Pates = FakeDb.Instance.Pates;
                return View(vm);
            }
            
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaVM vm = new PizzaVM();
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Pates = FakeDb.Instance.Pates;
            vm.Pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);

            if (vm.Pizza.Ingredients != null && vm.Pizza.Ingredients.Count > 0)
            {
                vm.IngredientIds = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaVM vm)
        {
            if(this.OtherValidations(ModelState, vm))
            {
                try
                {
                    Pizza toUpdate = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == vm.Pizza.Id);

                    toUpdate.Pate = FakeDb.Instance.Pates.SingleOrDefault(x => x.Id == vm.Pizza.Pate.Id);
                    toUpdate.Ingredients = FakeDb.Instance.Ingredients.Where(x => vm.IngredientIds.Contains(x.Id)).ToList();
                    toUpdate.Nom = vm.Pizza.Nom;

                    return RedirectToAction("Index");
                }
                catch
                {
                    vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    vm.Pates = FakeDb.Instance.Pates;
                    return View(vm);
                }
            }
            else
            {
                vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem() { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                vm.Pates = FakeDb.Instance.Pates;
                return View(vm);
            }
            
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
                FakeDb.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(x => x.Id == id);
                return View(pizza);
            }
        }

        private bool OtherValidations(ModelStateDictionary modelState, PizzaVM vm)
        {
            if (FakeDb.Instance.Pizzas.Any(x => x.Nom.Equals(vm.Pizza.Nom) && vm.Pizza.Id != x.Id))
            {
                modelState.AddModelError("Pizza.Nom", "Le nom de existe déjà");
            }

            return modelState.IsValid;
        }
    }
}
