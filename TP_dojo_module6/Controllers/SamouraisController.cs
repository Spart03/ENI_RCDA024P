using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DojoClassLibrary.Entities;
using TP_dojo_module6.Data;
using TP_dojo_module6.Models;

namespace TP_dojo_module6.Controllers
{
    public class SamouraisController : Controller
    {
        private TP_dojo_module6Context db = new TP_dojo_module6Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var vm = new SamouraiVM();
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.ArmeId.HasValue)
                {
                     vm.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == vm.ArmeId.Value);
                }

                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            SamouraiVM vm = new SamouraiVM();
            vm.Armes = db.Armes.Where(x => !db.Samourais.Where(y => y.Id != id).Select(y => y.Arme.Id).Contains(x.Id)).ToList();
            vm.Samourai = samourai;
            vm.ArmeId = samourai.Arme?.Id;

            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Find(vm.Samourai.Id);
                samourai.Nom = vm.Samourai.Nom;
                samourai.Force = vm.Samourai.Force;
                samourai.Arme = null;
                if (vm.ArmeId.HasValue)
                {
                    samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == vm.ArmeId.Value);
                }


                    db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
