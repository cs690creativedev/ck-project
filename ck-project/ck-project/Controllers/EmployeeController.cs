using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ck_project.Controllers
{
    public class EmployeeController : Controller
    {
        ckdatabase db = new ckdatabase();
        // GET: Employee
        public ActionResult Index()
        {
            List<employee> list_employees_db = db.employees.ToList();
            ViewBag.list_employees_vb = list_employees_db;
            return View();
            
        }

        public ActionResult Getemployee(int id)
        {
            List<employee> list_employees_db = db.employees.Where(d => d.emp_number == id).ToList();
            ViewBag.list_employees_vb = list_employees_db;

            return View("Index");
        }

        public ActionResult Modifyemployee(int id)
        {
            employee target_edit = db.employees.Where(a => a.emp_number == id).FirstOrDefault();
            var dropdown_list_con = new List<SelectListItem> {
                new SelectListItem{ Text="---select---",Selected=true,Value=""}
            };

            dropdown_list_con.AddRange(db.users_types.Select(a => new SelectListItem
            {
                Text = a.user_type_name,
                Selected = false,
                Value = a.user_type_number.ToString()
            }));

            var branch_con = new List<SelectListItem> {
                new SelectListItem{ Text="---select---",Selected=true,Value=""}
            };
            branch_con.AddRange(db.branches.Select(b => new SelectListItem
            {
                Text = b.branch_name,
                Selected = false,
                Value = b.branch_number.ToString()
            }));

            ViewBag.dropdown_list_view = dropdown_list_con;
            ViewBag.branch_view = branch_con;
            return View(target_edit);
        }

    }
}