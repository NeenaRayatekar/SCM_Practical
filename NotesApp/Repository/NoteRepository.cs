using NotesApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NotesApp.Repository
{
    public class NoteRepository : INotes
    {
        NotesDetailsEntities objNotesDetails;

        public NoteRepository()
        {
            objNotesDetails = new NotesDetailsEntities();
        }

        public NoteRepository(NotesDetailsEntities objNotesDetails)
        {
            objNotesDetails = this.objNotesDetails;
        }

        public void Add(Note note)
        {
            objNotesDetails.Notes.Add(note);
        }

        public void Delete(Note note)
        {
            objNotesDetails.Notes.Remove(note);
        }

        public IEnumerable<Note> GetAllNotes()
        {            
            return  objNotesDetails.Notes.ToList();
        }

        public Note GetById(int? id)
        {
            return objNotesDetails.Notes.Single(model => model.Note_ID == id);
        }

        public void Save()
        {
            objNotesDetails.SaveChanges();
        }

        public void Update(Note note)
        {
            objNotesDetails.Entry(note).State = EntityState.Modified;
        }
    }
}