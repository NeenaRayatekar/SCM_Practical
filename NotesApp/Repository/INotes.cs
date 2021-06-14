using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApp.Context;
using NotesApp.Models;

namespace NotesApp.Repository
{
    public interface INotes
    {
        IEnumerable<Note> GetAllNotes();
        Note GetById(int? id);
        void Add(Note note);
        void Update(Note note);
        void Delete(Note note);
        void Save();
    }
}
