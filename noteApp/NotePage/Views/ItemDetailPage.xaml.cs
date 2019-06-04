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
        public IList<String> CourseList { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();

            BindingContext = Note; // note property is the binding context
            NoteCourse.BindingContext = this; 
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            InitializeData();


            BindingContext = Note;
            NoteCourse.BindingContext = this;
        }
        async void InitializeData()
        {
            var pluralsightDataStore = new MockPluralsightDataStore();
            CourseList = await pluralsightDataStore.GetCoursesAsync(); // course list property will contain the list of courses every time we create a detail page

            Note = new Note
            {
                Heading = "Test note",
                Text = "Text for a test note",
                Course=CourseList[0]
            };
        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Cancel Option", "Cancel was selected", "Button 2", "Button 1");
        }

        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Save Option", "Save was selected", "Button 2", "Button 1");
        }
    }
}