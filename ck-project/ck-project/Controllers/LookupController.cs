﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ck_project.Controllers
{
    public class LookupController : Controller
    {
        // GET: Lookup
        //connecting db
        ckdatabase db = new ckdatabase();
        //Main Index Page for Look Ups
        public ActionResult Index(string id, string name)
        {
            ViewBag.LookupList = new List<string>()
            {
                "Project Class",
                "Project Type",
                "Project Status",
                "Lead Source",
                "Delivery Type"

            };
            return View();
        }

        //View Project Status Look Up
        public ActionResult ProjectStatus()
        {
            List<project_status> project_status_list = db.project_status.ToList();
            ViewBag.project_status_list = project_status_list;
            return View();

          
        }

        //Post Values into Project Status Look Up
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectStatusAdd(FormCollection form)
        {

            project_status target = new project_status();
            //get property
            TryUpdateModel(target, new string[] { "project_status_name" }, form.ToValueProvider());
            //validate
            if (string.IsNullOrEmpty(target.project_status_name))
                ModelState.AddModelError("project_status_name", "Project Status is required");

            if (ModelState.IsValid)
            {
                db.project_status.Add(target);
                db.SaveChanges();
            }

            return View(target);
        }

        //Add Project Status Look Up Page

        public ActionResult ProjectStatusAdd()
        {
            
            return View();


        }

        //Delete Project Status Look Up
        public ActionResult ProjectStatusDelete(int id)
        {
            //find target by uid
            project_status target = db.project_status.First(s => s.project_status_number == id);
            //delete
            db.project_status.Remove(target);
            db.SaveChanges();

            return RedirectToAction("ProjectStatus");
        }

        //View Project Class Look Up

        public ActionResult ProjectClass()
        {
            List<project_class> project_class_list = db.project_class.ToList();
            ViewBag.project_class_list = project_class_list;
            return View();


        }

        //Post Values into Project Class Look Up
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectClassAdd(FormCollection form)
        {

            project_class target = new project_class();
            //get property
            TryUpdateModel(target, new string[] { "class_name" }, form.ToValueProvider());
            //validate
            if (string.IsNullOrEmpty(target.class_name))
                ModelState.AddModelError("project_class_name", "Project class is required");

            if (ModelState.IsValid)
            {
                db.project_class.Add(target);
                db.SaveChanges();
            }

            return View(target);
        }
        //Add Project Class Look Up Page

        public ActionResult ProjectClassAdd()
        {

            return View();


        }

        // Delete Project Class Look Up Page
        public ActionResult ProjectClassDelete(int id)
        {
            //find target by uid
            project_class target = db.project_class.First(s => s.class_number == id);
            //delete
            db.project_class.Remove(target);
            db.SaveChanges();

            return RedirectToAction("ProjectClass");
        }



        // Lead Source list view
        public ActionResult LeadSource()
        {
            List<lead_source> lead_source_list = db.lead_source.ToList();
            ViewBag.lead_source_list = lead_source_list;
            return View();


        }

        //Post Values into Lead Source Look Up
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LeadSourceAdd(FormCollection form)
        {

            lead_source target = new lead_source();
            //get property
            TryUpdateModel(target, new string[] { "source_name" }, form.ToValueProvider());
            //validate
            if (string.IsNullOrEmpty(target.source_name))
                ModelState.AddModelError("source_name", "Project class is required");

            if (ModelState.IsValid)
            {
                db.lead_source.Add(target);
                db.SaveChanges();
            }

            return View(target);
        }
        //Add lead_source Look Up Page

        public ActionResult LeadSourceAdd()
        {

            return View();


        }

        // Delete lead_source Look Up Page
        public ActionResult LeadSourceDelete(int id)
        {
            //find target by uid
            lead_source target = db.lead_source.First(s => s.source_number == id);
            //delete
            db.lead_source.Remove(target);
            db.SaveChanges();

            return RedirectToAction("LeadSource");
        }
    }
}