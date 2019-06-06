using System;
using System.Collections.Generic;
using NotePage.Models;

namespace NotePage.ViewModels
{
    // Inherits from the baseviewmodel class, which provides helper code for alot of the vommon things we need to do for the view model
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }
        //True when adding new note, false when editing existing note
        public bool IsNewNote { get; set; }
        public String NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                Note.Heading = value;
                //provide change notification - call base model classes
                OnPropertyChanged(); // fires a property changed notification - infers the name of the property that called it
            }
        }
        public ItemDetailViewModel(Note note = null)
        {
            IsNewNote = note == null;
            Title = IsNewNote ? "Add Note" : "Edit Note"; // title is inherited from baseViewModel
            InitializeCourseList();
            Note = note ?? new Note();

            // Test note which we do not need
/*            Note = new Note
            {
                Heading = "Test note",
                Text = "Text for note in ViewModel",
                Course = CourseList[0]
            };*/
        }
        async void InitializeCourseList()
        {
            CourseList = await PluralSightDataStore.GetCoursesAsync();
        }
    }
}
