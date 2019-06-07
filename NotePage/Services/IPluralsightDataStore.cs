using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotePage.Models;

namespace NoteKeeper.Services
{
    public interface IPluralsightDataStore // individual platform creates implementation of the interface
    {
        Task<String> AddNoteAsync(Note courseNote);
        Task<bool> UpdateNoteAsync(Note courseNote);
        Task<Note> GetNoteAsync(String id);
        Task<IList<Note>> GetNotesAsync(); // Interface - different platforms use different data stores
        Task<IList<String>> GetCoursesAsync();  // method for getting list of courses
    }
}
