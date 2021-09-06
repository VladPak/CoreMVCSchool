using CRUD_School294.Data;
using CRUD_School294.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_School294.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GetAll from Students
        public IActionResult Index(string searchString)
        {
            var students = _db.Students.ToList();
            ViewData["CurrentFilter"] = searchString;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(x => x.studentName.Contains(searchString) || x.studentSurname.Contains(searchString)).ToList();
            }
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(students);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit student record
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditStudent(Students students)
        {
            if (students == null)
            {
                return NotFound();
            }
            _db.Students.Update(students);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
