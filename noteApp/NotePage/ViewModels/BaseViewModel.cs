using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using NotePage.Models;
using NotePage.Services;
using NoteKeeper.Services;

namespace NotePage.ViewModels
{
    // Implements INOTFIYPROPERYCHANGED interface
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Dependency service - allows the platform-specific projects to provide a feature implementation
        // Cross-platform code can then access that implementation using the dependency service
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        public IPluralsightDataStore PluralSightDataStore =>
            DependencyService.Get<IPluralsightDataStore>() ?? new MockPluralsightDataStore();
        // first check dependency service to see if there is a data store - if null we create a new instance

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        // Code related to INotifyPropertyChanged Interface
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // helper method handling the details for firing the event
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        { // this method can infer the name of the property that calls it (because of [CallerMemberName]
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
