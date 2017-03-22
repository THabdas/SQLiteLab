using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLiteWeb.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SQLiteWeb.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext _context;
        public StudentController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Edit(int? id)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            /*var student = _context.Students.FirstOrDefault(t => t.Id == id);
            if (student != null)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }*/
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(student);
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
