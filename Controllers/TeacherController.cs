using NEW_MVC.Models;
using NEW_MVC;
using Microsoft.EntityFrameworkCore;


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }
        // public IActionResult Index()
        // {
        //     IEnumerable<Teacher> listofsubjects = _db.Teacher;
        //     return View(listofsubjects);
        // }

        
        public async Task<IActionResult> Index(string SearchString) 
        {
            var teachers = from t in _db.Teacher select t;
            if(!string.IsNullOrEmpty(SearchString)){
                teachers = teachers.Where(s => s.Subject_Name!.Contains(SearchString));
            }
            return View(await teachers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Edit(int teacherid)
        {
            var subobj = _db.Teacher.Find(teacherid);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Teacher updatedvaluesobj)
        {
            _db.Teacher.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        
        public IActionResult Delete(int teacherid) {
            var subobj = _db.Teacher.Find(teacherid);
            _db.Teacher.Remove(subobj);
            _db.SaveChanges();
            var updated_db = _db.Teacher;
            return RedirectToAction("Index",updated_db);
        }

         [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("name")]Teacher createdvaluesobj)
        {
            // _db.Teacher.create(createdvaluesobj);
            _db.Teacher.Add(createdvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}