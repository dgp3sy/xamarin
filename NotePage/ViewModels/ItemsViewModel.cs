using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NotePage.Models;
using NotePage.Views;

namespace NotePage.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<type of the sender, type of the data you expect with the message>(reference to the class calling the subscribe method, 
            // string identifying the message, 
            // async lambda expression (reference to message sender, information sent with that message) => { work we want to get done when the message is sent}); 
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "SaveNote",
                async (sender, note) => {
                    // note appear in list view - add note to note collection
                    Notes.Add(note); // note collection is an observable selection - autommatically updates list view

                    //save this into the data store
                    await PluralSightDataStore.AddNoteAsync(note);

            });

            //Handle Note Updates
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "UpdateNote",
                async (sender, note) =>
                {
                    await PluralSightDataStore.UpdateNoteAsync(note);

                    // modifying a memeber within an ObservableCollection does not autoatically refresh data binding
                    // we must explicity repopulate the collection 
                    await ExecuteLoadItemsCommand();
                });

/*            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            // standard pattern to protect asynchronous functions
            if (IsBusy)
                return;

            // if the work has started - no further attempts of the work can occur
            IsBusy = true;

            try
            {
                // look up necessary data and populate
                Notes.Clear();
                var notes = await PluralSightDataStore.GetNotesAsync();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}