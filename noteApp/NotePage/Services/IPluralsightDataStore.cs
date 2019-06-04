using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotePage.Models;

namespace NoteKeeper.Services
{
    public interface IPluralsightDataStore
    {
        Task<String> AddNoteAsync(Note courseNote);
        Task<bool> UpdateNoteAsync(Note courseNote);
        Task<Note> GetNoteAsync(String id);
        Task<IList<Note>> GetNotesAsync(); // Interface - different platforms use different data stores
        Task<IList<String>> GetCoursesAsync(); 
    }
}
