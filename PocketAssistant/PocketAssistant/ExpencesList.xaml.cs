using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace PocketAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpencesList : ContentPage
    {
        
        public ExpencesList()
        {
            InitializeComponent();
            expencesList.RefreshCommand = new Command(() =>
            {
                RefreshData();
                expencesList.IsRefreshing = false;

            });
           
        }
        public void RefreshData()
        {
            expencesList.ItemsSource = null;
            expencesList.ItemsSource = App.Database.GetItems();
        }
        protected override void OnAppearing()
        {
            
            expencesList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void SwipeItem_OnInvoked(object sender, EventArgs e)
        {
            bool a = await DisplayAlert("Delete item", "Are you sure you want to delete ? ", "Yes", "Cancel");
            if (a == true)
            {
                var curExp = sender as SwipeItem;
                var expense = curExp.CommandParameter as Expences;
                App.Database.DeleteItem(expense.Id);
                Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) + Convert.ToDecimal(expense.AmountExp);
                await DisplayAlert("Succesfully", "Item is Deleted", "Ok");

            }


        }


    }
}