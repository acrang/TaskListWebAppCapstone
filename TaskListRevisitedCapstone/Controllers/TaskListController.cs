using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListRevisitedCapstone.Models;

namespace TaskListRevisitedCapstone.Controllers
{
    public class TaskListController : Controller
    {
        private readonly TaskListDBContext _db;
        public TaskListController(TaskListDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<TodoItem> Tasks = _db.TodoItem.ToList();
            return View(Tasks);
        }

        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TodoItem t)
        {
            if (ModelState.IsValid)
            {
                _db.TodoItem.Add(t);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteTask(TodoItem t)
        {
            _db.TodoItem.Remove(t);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult UpdateTask(int id)
        {
            TodoItem t = _db.TodoItem.Find(id);
            return View(t);
        }

        [HttpPost]
        public IActionResult UpdateTask(TodoItem t, string Description, DateTime DueDate)
        {
            t.Description = Description;
            t.DueDate = DueDate;

            _db.TodoItem.Update(t);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
