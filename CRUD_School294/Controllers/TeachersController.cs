using CRUD_School294.Data;
using CRUD_School294.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public IActionResult Index(string searchString, string sortOrder)
        {
            var teachers = _db.Teachers.ToList();
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
                    break;
            }
            return View(teachers);
        }

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
