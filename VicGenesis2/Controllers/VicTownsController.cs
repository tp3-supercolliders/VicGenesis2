﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VicGenesis2.Models;

namespace VicGenesis2.Controllers
{
    public class VicTownsController : Controller
    {
        private ModelForRank db = new ModelForRank();

        public static string Style;
        public static string Style1;

        public static string Style2;
        public static VicTown[] listOfArea = new VicTown[3];



        // GET: VicTowns
        public ActionResult Index()
        {
            return View(db.VicTowns.ToList());
        }

        // GET: VicTowns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicTown vicTown = db.VicTowns.Find(id);
            if (vicTown == null)
            {
                return HttpNotFound();
            }
            return View(vicTown);
        }

        // GET: VicTowns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VicTowns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,COMM_CODE,Community_Name,Funded_services,HACC_services,Health_or_Human_services,Dental_sites,Primary_schools,Distance_Service,Number_of_households,Rank_funded,Rank_HACC,Rank_HH_services,Rank_dental,Rank_school,Rank_distance,Rank_household")] VicTown vicTown)
        {
            if (ModelState.IsValid)
            {
                db.VicTowns.Add(vicTown);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vicTown);
        }

        // GET: VicTowns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicTown vicTown = db.VicTowns.Find(id);
            if (vicTown == null)
            {
                return HttpNotFound();
            }
            return View(vicTown);
        }

        // POST: VicTowns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,COMM_CODE,Community_Name,Funded_services,HACC_services,Health_or_Human_services,Dental_sites,Primary_schools,Distance_Service,Number_of_households,Rank_funded,Rank_HACC,Rank_HH_services,Rank_dental,Rank_school,Rank_distance,Rank_household")] VicTown vicTown)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vicTown).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vicTown);
        }

        // GET: VicTowns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicTown vicTown = db.VicTowns.Find(id);
            if (vicTown == null)
            {
                return HttpNotFound();
            }
            return View(vicTown);
        }

        // POST: VicTowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VicTown vicTown = db.VicTowns.Find(id);
            db.VicTowns.Remove(vicTown);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Compare()
        {
            List<SelectListItem> selection = new List<SelectListItem>();
            List<SelectListItem> selection1 = new List<SelectListItem>();

            selection.Add(new SelectListItem() { Text = "---Please Select---", Value = "", Selected = true });
            selection1.Add(new SelectListItem() { Text = "---Please Select---", Value = "", Selected = true });

            foreach (VicTown item in db.VicTowns.ToList())
            {
                selection.Add(new SelectListItem() { Text = item.Community_Name, Value = item.Community_Name, Selected = false });
                selection1.Add(new SelectListItem() { Text = item.Community_Name, Value = item.Community_Name, Selected = false });
            }




            ViewBag.Culture = selection;
            ViewBag.Culture1 = selection1;
            
            return View();
        }


        //[HttpGet]
        public ActionResult CompareExist(int? id)
        {
            List<SelectListItem> selection = new List<SelectListItem>();
            List<SelectListItem> selection1 = new List<SelectListItem>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VicTown vicTown = db.VicTowns.Find(id);
          
            if (vicTown == null)
            {
                return HttpNotFound();
            }
           

            selection.Add(new SelectListItem() { Text = vicTown.Community_Name, Value = vicTown.Community_Name, Selected = true });
            selection1.Add(new SelectListItem() { Text = "---Please Select---", Value = "", Selected = true });

            foreach (VicTown item in db.VicTowns.ToList())
            {
                selection.Add(new SelectListItem() { Text = item.Community_Name, Value = item.Community_Name, Selected = false });
                selection1.Add(new SelectListItem() { Text = item.Community_Name, Value = item.Community_Name, Selected = false });
            }


            ViewBag.Culture = selection;
            ViewBag.Culture1 = selection1;

            return View();
        }


        [HttpPost]
        public ActionResult Compare(FormCollection form)
        {
            Style = form["Culture"];
            Style1 = form["Culture1"];
           
                return RedirectToAction("Result");
            
        }

        [HttpPost]
        public ActionResult CompareExist(FormCollection form)
        {
            Style = form["Culture"];
            Style1 = form["Culture1"];

            return RedirectToAction("Result");

        }


        public ActionResult Result()
        {
            ViewBag.Culture = Style;
            ViewBag.Culture1 = Style1;
            return View(db.VicTowns.ToList());
        }


        [HttpGet]
        public ActionResult Select()
        {
            List<SelectListItem> selection = new List<SelectListItem>();
            List<SelectListItem> selection1 = new List<SelectListItem>();

            List<SelectListItem> selection2 = new List<SelectListItem>();


            selection.Add(new SelectListItem() { Text = "Funded services", Value = "A", Selected = true });
            selection.Add(new SelectListItem() { Text = "Humanitarian Assistance  Center", Value = "B", Selected = false });
            selection.Add(new SelectListItem() { Text = "Health and medicine services", Value = "C", Selected = false });
            selection.Add(new SelectListItem() { Text = "Dental sites", Value = "D", Selected = false });
            selection.Add(new SelectListItem() { Text = "Number of schools", Value = "E", Selected = false });
            selection.Add(new SelectListItem() { Text = "Distance to nearst health service", Value = "F", Selected = false });
            selection.Add(new SelectListItem() { Text = "Number of households", Value = "G", Selected = false });

            selection1.Add(new SelectListItem() { Text = "Funded services", Value = "A", Selected = false });
            selection1.Add(new SelectListItem() { Text = "Humanitarian Assistance Center", Value = "B", Selected = false });
            selection1.Add(new SelectListItem() { Text = "Health and medicine services", Value = "C", Selected = true });
            selection1.Add(new SelectListItem() { Text = "Dental sites", Value = "D", Selected = false });
            selection1.Add(new SelectListItem() { Text = "Number of schools", Value = "E", Selected = false });
            selection1.Add(new SelectListItem() { Text = "Distance to nearst health service", Value = "F", Selected = false });
            selection1.Add(new SelectListItem() { Text = "Number of households", Value = "G", Selected = false });

            selection2.Add(new SelectListItem() { Text = "Funded services", Value = "A", Selected = false });
            selection2.Add(new SelectListItem() { Text = "Humanitarian Assistance Center", Value = "B", Selected = false });
            selection2.Add(new SelectListItem() { Text = "Health and medicine services", Value = "C", Selected = false });
            selection2.Add(new SelectListItem() { Text = "Dental sites", Value = "D", Selected = false });
            selection2.Add(new SelectListItem() { Text = "Number of schools", Value = "E", Selected = false });
            selection2.Add(new SelectListItem() { Text = "Distance to nearst health service", Value = "F", Selected = false });
            selection2.Add(new SelectListItem() { Text = "Number of households", Value = "G", Selected = true });

            ViewBag.Culture = selection;
            ViewBag.Culture1 = selection1;

            ViewBag.Culture2 = selection2;
            return View();
        }

        [HttpPost]
        public ActionResult Select(FormCollection form)
        {
            Style = form["Culture"];
            Style1 = form["Culture1"];
            Style2 = form["Culture2"];

            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            

            ViewBag.Culture = Style;
            ViewBag.Culture1 = Style1;
            ViewBag.Culture2 = Style2;

            foreach (VicTown item in db.VicTowns.ToList())

            {
                int i = 0;
                int score = 0;
                int a = 0;
                int b = 0;
                int c = 0;
                int.TryParse(item.Rank_distance, out a);
                int.TryParse(item.Rank_funded, out b);
                int.TryParse(item.Rank_HACC, out c);
                if (Style.Equals("A")) { int.TryParse(item.Rank_funded, out a); }
                if (Style.Equals("B")) { int.TryParse(item.Rank_HACC, out a); }
                if (Style.Equals("C")) { int.TryParse(item.Rank_HH_services, out a); }
                if (Style.Equals("D")) { int.TryParse(item.Rank_dental, out a); }
                if (Style.Equals("E")) { int.TryParse(item.Rank_school, out a); }
                if (Style.Equals("F")) { int.TryParse(item.Rank_distance, out a); }
                if (Style.Equals("G")) { int.TryParse(item.Rank_household, out a); }
                
                if (Style1.Equals("A")) { int.TryParse(item.Rank_funded, out b); }
                if (Style1.Equals("B")) { int.TryParse(item.Rank_HACC, out b); }
                if (Style1.Equals("C")) { int.TryParse(item.Rank_HH_services, out b); }
                if (Style1.Equals("D")) { int.TryParse(item.Rank_dental, out b); }
                if (Style1.Equals("E")) { int.TryParse(item.Rank_school, out b); }
                if (Style1.Equals("F")) { int.TryParse(item.Rank_distance, out b); }
                if (Style1.Equals("G")) { int.TryParse(item.Rank_household, out b); }
                
                if (Style2.Equals("A")) { int.TryParse(item.Rank_funded, out c); }
                if (Style2.Equals("B")) { int.TryParse(item.Rank_HACC, out c); }
                if (Style2.Equals("C")) { int.TryParse(item.Rank_HH_services, out c); }
                if (Style2.Equals("D")) { int.TryParse(item.Rank_dental, out c); }
                if (Style2.Equals("E")) { int.TryParse(item.Rank_school, out c); }
                if (Style2.Equals("F")) { int.TryParse(item.Rank_distance, out c); }
                if (Style2.Equals("G")) { int.TryParse(item.Rank_household, out c); }
             
                

                score = a * 5 + b * 3 + c * 2;
                foreach (VicTown item1 in db.VicTowns.ToList())
                {
                    int a1 = 0;
                    int b1 = 0;
                    int c1 = 0;
                    int.TryParse(item1.Rank_distance, out a1);
                    int.TryParse(item1.Rank_funded, out b1);
                    int.TryParse(item1.Rank_HACC, out c1);

                    if (Style.Equals("A")) { int.TryParse(item1.Rank_funded, out a1); }
                    if (Style.Equals("B")) { int.TryParse(item1.Rank_HACC, out a1); }
                    if (Style.Equals("C")) { int.TryParse(item1.Rank_HH_services, out a1); }
                    if (Style.Equals("D")) { int.TryParse(item1.Rank_dental, out a1); }
                    if (Style.Equals("E")) { int.TryParse(item1.Rank_school, out a1); }
                    if (Style.Equals("F")) { int.TryParse(item1.Rank_distance, out a1); }
                    if (Style.Equals("G")) { int.TryParse(item1.Rank_household, out a1); }

                    if (Style1.Equals("A")) { int.TryParse(item1.Rank_funded, out b1); }
                    if (Style1.Equals("B")) { int.TryParse(item1.Rank_HACC, out b1); }
                    if (Style1.Equals("C")) { int.TryParse(item1.Rank_HH_services, out b1); }
                    if (Style1.Equals("D")) { int.TryParse(item1.Rank_dental, out b1); }
                    if (Style1.Equals("E")) { int.TryParse(item1.Rank_school, out b1); }
                    if (Style1.Equals("F")) { int.TryParse(item1.Rank_distance, out b1); }
                    if (Style1.Equals("G")) { int.TryParse(item1.Rank_household, out b1); }

                    if (Style2.Equals("A")) { int.TryParse(item1.Rank_funded, out c1); }
                    if (Style2.Equals("B")) { int.TryParse(item1.Rank_HACC, out c1); }
                    if (Style2.Equals("C")) { int.TryParse(item1.Rank_HH_services, out c1); }
                    if (Style2.Equals("D")) { int.TryParse(item1.Rank_dental, out c1); }
                    if (Style2.Equals("E")) { int.TryParse(item1.Rank_school, out c1); }
                    if (Style2.Equals("F")) { int.TryParse(item1.Rank_distance, out c1); }
                    if (Style2.Equals("G")) { int.TryParse(item1.Rank_household, out c1); }

                    if (score < a1 * 5 + b1 * 3 + c1 * 2) { i = i + 1; }
                }
                if (i == 0) { listOfArea[0] = item; }
                if (i == 1) { listOfArea[1] = item; }
                if (i == 2) { listOfArea[2] = item; }
            }

            return View(listOfArea);
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
