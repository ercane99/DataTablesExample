using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataTablesExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataTablesExample.Controllers
{
    public class StudentsController : Controller
    {
        public static List<Student> StudentList { get; set; }
        // GET: Students
        public ActionResult Index()
        {
            if (StudentList == null)
            {
                StudentList = new List<Student>();
            }
            return View(StudentList);
        }

        public ActionResult CreateSampleStudents()
        {

            int maxId = 0;
            if (StudentList.Count > 0)
            {
                maxId = StudentList.Max<Student>(a => a.Id);
            }
            for (int i = 0; i < 5; i++)
            {
                int newId = maxId + i + 1;
                Student s = new Student
                {
                    Id = newId,
                    Firstname = "Sample firstname " + newId,
                    Lastname = "Sample lastname " + newId,
                    CreatedDate = DateTime.Now
                };
                StudentList.Add(s);
                //Wait 1 second to create students in different times to be able to see ordering in data table
                Thread.Sleep(800);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}