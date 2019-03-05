﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using GestionDesCourses.Models;

namespace GestionDesCourses.Controllers
{
    public class RacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private static List<Category> lesCategoriesDispo;

        public RacesController()
        {
            if(lesCategoriesDispo == null)
            {
                lesCategoriesDispo = db.Categories.ToList();
            }          
        }

        // GET: Races
        public ActionResult Index()
        {

            return View(db.Races.Include(c => c.Category));
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RaceViewModel raceVM = new RaceViewModel();
            raceVM.Race = db.Races.Include(c => c.Category).SingleOrDefault(c => c.Id == id);

            return View(raceVM);
        }

        // GET: Races/Create
        [Authorize]
        public ActionResult Create()
        {
            // création du ViewModel nécessaire pour porter la liste des catégories et l'id de la categorie choisie en plus de la course
            var raceVM = new RaceViewModel();
            raceVM.Categories = lesCategoriesDispo;

            return View(raceVM);
        }

        // POST: Races/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceViewModel raceVM)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    // on vérifie la validité des données
                    if (!CheckRules(raceVM))
                    {
                        throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une création de course");
                    }

                    // on vérifie qu'une catégorie ai été choisie
                    if (raceVM.IdSelectedCategory.HasValue)
                    {
                        // on assigne la catégorie dont l'Id à été choisi pour la course
                        raceVM.Race.Category = db.Categories.FirstOrDefault(a => a.Id == raceVM.IdSelectedCategory.Value);
                    }

                    // On ajoute la nouvelle course au DbSet, puis on enregistre les changements en base
                    db.Races.Add(raceVM.Race);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
                }
                
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    // Si nous avons rencontré une erreur, il faut recharger la page de création, de ce fait il nous faut ré-alimenter le Viewmodel avant de le passer à la vue
                    raceVM.Categories = lesCategoriesDispo;
                    return View(raceVM);
                }
            }
            raceVM.Categories = lesCategoriesDispo;
            return View(raceVM);  
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Race race = db.Races.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            if (race == null)
            {
                return HttpNotFound();
            }
            var raceVM = new RaceViewModel();
            raceVM.Categories = lesCategoriesDispo;
            raceVM.Race = race;

            if (race.Category != null)
            {
                // Si la course avait une catégorie, on affecte l'Id de cette catégorie à notre ViewModel, ansi elle sera préselectionnée dans notre liste de catégories
                raceVM.IdSelectedCategory = race.Category.Id;
            }
            return View(raceVM);
            
        }

        // POST: Races/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceViewModel raceVM)
        {
        /*    if (ModelState.IsValid)
            {
                
                db.Entry(raceVM.Race).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raceVM);
        */
            if (ModelState.IsValid)
            {
                try
                {
                    // on vérifie la validité des données
                    if (!CheckRules(raceVM))
                    {
                        throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une création de course");
                    }

                    var racedb = db.Races.Include(z => z.Category).FirstOrDefault(i => i.Id == raceVM.Race.Id);
                    racedb.Title = raceVM.Race.Title;
                    racedb.Category = null;
                    if (raceVM.IdSelectedCategory.HasValue)
                    {
                        racedb.Category = db.Categories.FirstOrDefault(a => a.Id == raceVM.IdSelectedCategory.Value);
                    }
                    racedb.DateStart = raceVM.Race.DateStart;
                    racedb.DateEnd = raceVM.Race.DateEnd;
                    racedb.Description = raceVM.Race.Description;
                    racedb.Price = raceVM.Race.Price;
                    racedb.ZipCode = raceVM.Race.ZipCode;
                    // pareil pour inscriptions etc...
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    // Si nous avons rencontré une erreur, il faut recharger la page de création, de ce fait il nous faut ré-alimenter le Viewmodel avant de le passer à la vue
                    raceVM.Categories = lesCategoriesDispo;
                    return View(raceVM);
                }
            }
            raceVM.Categories = lesCategoriesDispo;
            return View(raceVM);
            
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Include(c => c.Category).SingleOrDefault(c => c.Id == id);  //db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }


        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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

        private bool CheckRules(RaceViewModel raceVm)
        {
            var brokenRules = 0;
            // Rq : pour les champs obligatoires (tous en fait) c'est géré avec le "[Required]" dans les champs de la classe BO>Race
            // idem pour la taille des chaines de caractère

            // le titre doit etre unique
            List<Race> coursesExistantes = db.Races.ToList();
            if (coursesExistantes.Any(p => p.Title.ToUpper() == raceVm.Race.Title.ToUpper() && p.Id != raceVm.Race.Id))
            {
                ModelState.AddModelError("Race.Title", "Il existe déjà une course portant ce titre");
                brokenRules++;
            }

            // vérifier que la date de début soit bien antérieure à la date de fin
            if (raceVm.Race.DateStart > raceVm.Race.DateEnd)
            {
                ModelState.AddModelError("Race.DateEnd", "La date de fin doit etre postérieure à la date de début");
                ModelState.AddModelError("Race.DateStart", "La date de début doit etre antérieure à la date de fin");
                brokenRules++;
            }

            // vérifier que la date de début soit bien postérieure à la date du jour
            if (raceVm.Race.DateStart < DateTime.Now)
            {
                ModelState.AddModelError("Race.DateStart", "La date de début doit etre postérieure à la date du jour");
                brokenRules++;
            }

            // vérifier que la date de fin soit bien postérieure à la date du jour
            if (raceVm.Race.DateEnd < DateTime.Now)
            {
                ModelState.AddModelError("Race.DateEnd", "La date de fin doit etre postérieure à la date du jour");
                brokenRules++;
            }

            // il faut des POI (au moins deux : départ et arrivée)
            /*          if (raceVm.IdSelectedPois.Count < 2)
                        {
                            ModelState.AddModelError("", "Une course doit avoir au moins deux points d'interets");
                            brokenRules++;
                        }
            */

            return brokenRules == 0;
        }
    }
}
