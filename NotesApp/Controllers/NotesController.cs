using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NotesApp.Context;
using NotesApp.Repository;

namespace NotesApp.Controllers
{
    [Authorize]
    //[Repository.ApplicationException]
    [AllowAnonymous]
    public class NotesController : Controller
    {     
        INotes notes = new NoteRepository();

        // GET: Notes
      
        public ActionResult Index()
        {            
            return View(notes.GetAllNotes());            
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
            Note note = notes.GetById(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Note_ID,Note1")] Note note)
        {
            if (ModelState.IsValid)
            {
                notes.Add(note);
                notes.Save();               
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Note note = notes.GetById(id);          
            if (note == null)
            {
                throw new Exception();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Note_ID,Note1")] Note note)
        {
            if (ModelState.IsValid)
            {
                notes.Update(note);
                notes.Save();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Note note = notes.GetById(id);
            if (note == null)
            {
                throw new Exception();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = notes.GetById(id);
            notes.Delete(note);
            notes.Save();           
            return RedirectToAction("Index");
        }

    }
}
