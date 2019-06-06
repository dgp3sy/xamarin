using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieStockApp.Model;
using Xamarin.Forms;

namespace BethanysPieStockApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //very often we will define the pie as a property on the class level
        public Pie CherryPie { get; set; } // Note: Pie class must be public

        public MainPage()
        {
            InitializeComponent();
            //Source Object (1)
            CherryPie = new Pie
            {
                Id = 1,
                PieName = "Cherry Pie",
                Price = 20
            };

            MainGrid.BindingContext = CherryPie;



/*            Binding pieNameBinding = new Binding();
            pieNameBinding.Source = pie; // source
            pieNameBinding.Path = "PieName"; // soource path
            NameEntry.SetBinding(Entry.TextProperty, pieNameBinding); // target property

            Binding priceBinding = new Binding();
            priceBinding.Source = pie;
            priceBinding.Path = "Price";
            PriceEntry.SetBinding(Entry.TextProperty, priceBinding);
            */
        }
    }
}
