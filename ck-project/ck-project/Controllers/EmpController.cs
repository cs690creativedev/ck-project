﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ck_project.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }


        //Creating the DB connecton
        ckdatabase db = new ckdatabase();



        // GET: Employees
        public ActionResult ListEmp()
        {
            List<employee> Employees_list = db.employees.ToList();
            ViewBag.Employeeslist = Employees_list;
            return View();
        }
        

        // read from the DB
        public ActionResult Edit(int id)
        {
            List<employee> Employees_list = db.employees.Where(d => d.emp_number == id).ToList();
            ViewBag.Customerslist = Employees_list;
            employee target = Employees_list[0];
              return View(target);

           
        }


        // Write to the DB that is why we use POST
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection fo)
        {
            List<employee> Employees_list = db.employees.Where(d => d.emp_number == id).ToList();
            ViewBag.Customerslist = Employees_list;
            employee target = Employees_list[0];
            TryUpdateModel(target, new string[] { "emp_firstname", "emp_middlename", "emp_lastname", "emp_username", "user_type_number", "branch_number", "emp_number", "phone_number" }, fo.ToValueProvider());
            db.SaveChanges();
            return View(target);
        }





        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(FormCollection form)
        {
            //setting dropdown list for forgern key
            var utype = new List<SelectListItem> {
                new SelectListItem{ Text="---select---",Selected=true,Value=""}
            };
            utype.AddRange(db.users_types.Select(a => new SelectListItem
            {
                Text = a.user_type_name,
                Selected = false,
                Value = a.user_type_number.ToString()
            }));

            var branchtypes = new List<SelectListItem> {
                new SelectListItem{ Text="---select---",Selected=true,Value=""}
            };
            branchtypes.AddRange(db.branches.Select(b => new SelectListItem
            {
                Text = b.branch_name,
                Selected = false,
                Value = b.branch_number.ToString()
            }));
            //setting variable passing
            ViewBag.utype = utype;
            ViewBag.branch = branchtypes;
            //create instance
            employee target = new employee();
            //get property
            TryUpdateModel(target, new string[] { "emp_firstname", "emp_middlename", "emp_lastname", "emp_username", "user_type_number", "branch_number", "emp_number", "phone_number" }, form.ToValueProvider());
            //validate
            if (string.IsNullOrEmpty(target.emp_firstname))
                ModelState.AddModelError("firstname", "firstname is required");

            if (ModelState.IsValid)
            {
                db.employees.Add(target);
                db.SaveChanges();
            }

            return View(target);
        }

        public ActionResult Add()
        {
            var utype = new List<SelectListItem> {
                new SelectListItem{ Text="---select---",Selected=true,Value=""}
            };
            utype.AddRange(db.users_types.Select(a => new SelectListItem
            {
                Text = a.user_type_name,
                Selected = false,
                Value = a.user_type_number.ToString()
            }));

            var branchtypes = new List<SelectListItem> {
                new SelectListItem{ Text="---select---",Selected=true,Value=""}
            };
            branchtypes.AddRange(db.branches.Select(b => new SelectListItem
            {
                Text = b.branch_name,
                Selected = false,
                Value = b.branch_number.ToString()
            }));

            ViewBag.utype = utype;
            ViewBag.branch = branchtypes;
            return View();
        }


    }
}