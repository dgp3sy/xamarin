using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NotePage.Models;
using NotePage.Views;
using NotePage.ViewModels;

namespace NotePage.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        //public Note Note { get; set; }
        //public IList<String> CourseList { get; set; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            // cast to note 
            var note = args.SelectedItem as Note;
            // make sure not is not null
            if (note == null)
                return;

            // passing selected note into item detail view model - push hierarchical navigation: navigating within the existing navigation page
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(new ItemDetailViewModel(note))));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        
        async void AddItem_Clicked(object sender, EventArgs e)
        { // what happens when we create a new item
            // push modal async - take the user to a page and makke the user perform a specific navigation in order to leave
            // Modal navigation - moving outside of that navigation page
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
        }   

        protected override void OnAppearing()
        {
            // called just before the page is visible
            base.OnAppearing(); 

            if (viewModel.Notes.Count == 0)
                // if note collection is empty, populate it
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}