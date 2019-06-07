using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NotePage.Models;
using NotePage.ViewModels;
using NoteKeeper.Services;
using System.Collections.Generic;

namespace NotePage.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Note Note { get; set; }
        //public IList<String> CourseList { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            //InitializeData();

            this.viewModel = viewModel;
            BindingContext = this.viewModel; // note property is the binding context
            NoteCourse.BindingContext = this; 
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            //InitializeData();


            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
            NoteCourse.BindingContext = this;
        }
/*        async void InitializeData()
        {
            var pluralsightDataStore = new MockPluralsightDataStore();
            CourseList = await pluralsightDataStore.GetCoursesAsync(); // course list property will contain the list of courses every time we create a detail page

            Note = new Note
            {
                Heading = "Test note",
                Text = "Text for a test note",
                Course=CourseList[0]
            };
        }*/

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {

            //TODO : Look at after version of module code for NoteText and NoteCourrse Properties - implement this same logic for NoteText and NoteCourse

            // NoteHeading property is consistantly acting as a intermediary between UI and data model
            //    - any changes to this value is made through the view model
            /*            viewModel.NoteHeading = "XXXXX"; 
                        DisplayAlert("Cancel Option", 
                            "Heading Value is: " + viewModel.Note.Heading, 
                            "Button 2", 
                            "Button 1");*/

            //Pop the item details page off the stack and return to the items page
            Navigation.PopModalAsync();
        }


        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            // indicates that the save note action has occured to the messaging center - determines if we are updating existing note or saving a new one
            var message = viewModel.IsNewNote ? "SaveNote" : "UpdateNote";

            // MessagingEnter.Send(reference to sender, string ID of message, data about message);
            MessagingCenter.Send(this, message, viewModel.Note);

            //Connect to SQL Database
            //string dbPath = "C:\\Users\\danny.perkins\\source\\repos\\NotePage\\NotePage\\NotePage\\Resources\\my_table.db";
            //string database = new SQLiteAsyncConnection(dbPath);

            // Pop the item details page off the stack and return to the items page
            Navigation.PopModalAsync();

            //DisplayAlert("Save Option", "Save was selected", "Button 2", "Button 1");
        }
    }
}