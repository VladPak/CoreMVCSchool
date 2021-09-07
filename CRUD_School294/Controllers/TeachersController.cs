using CRUD_School294.Data;
using CRUD_School294.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_School294.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeachersController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index(string searchString, string sortOrder, int pg=1)
        {
            const int pageSize = 10;

            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = _db.Teachers.Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var teachers = _db.Teachers.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //var teachers = _db.Teachers.ToList();
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(x => x.teacherSurname.Contains(searchString) || x.teacherName.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    teachers = teachers.OrderByDescending(s => s.teacherName).ToList();
                    break;
                case "Date":
                    teachers = teachers.OrderBy(s => s.teacherDob).ToList();
                    break;
                case "date_desc":
                    teachers = teachers.OrderByDescending(s => s.teacherDob).ToList();
                    break;
                default:
                    teachers = teachers.OrderBy(s => s.teacherName).ToList();
                    break;
            }
            return View(teachers);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            var file = Request.Form.Files["fileToImport"];

            if (file == null)
            {
                ViewBag.Result = "File is missing";
                return View();
            }

            return View(); ;
        }

        //private List<string> SaveTeachersToDb(List<Teachers> model, List<string> errors)
        //{
        //    try
        //    {
        //        _db.Teachers.Add();
        //        _db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        errors.Add("Errors inserting employees : " + ex.Message);
        //    }
        //    return errors;
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(teachers);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers);
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var objToEdit = _db.Teachers.Find(id);
            if (objToEdit == null)
            {
                return NotFound();
            }
            return View(objToEdit);
        }

        [HttpPost]
        public IActionResult EditTeacher(Teachers teachers)
        {
            if (teachers == null)
            {
                return NotFound();
            }
            _db.Teachers.Update(teachers);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var objToDelete = _db.Teachers.Find(id);

            if (objToDelete == null)
            {
                return NotFound();
            }

            _db.Teachers.Remove(objToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
