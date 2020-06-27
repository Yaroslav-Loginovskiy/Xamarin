using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomesListxaml : ContentPage
    {
        public IncomesListxaml()
        {
            InitializeComponent();
            incomesList.RefreshCommand = new Command(() =>
            {
                RefreshData();
                incomesList.IsRefreshing = false;

            });

        }

        public void RefreshData()
        {
            incomesList.ItemsSource = null;
            incomesList.ItemsSource = App.IncDatabase.GetItems();
        }
        protected override void OnAppearing()
        {

            incomesList.ItemsSource = App.IncDatabase.GetItems();
            base.OnAppearing();
        }

        private async void SwipeItem_OnInvoked(object sender, EventArgs e)
        {
            bool a = await DisplayAlert("Delete item", "Are you sure you want to delete ? ", "Yes", "Cancel");
            if (a == true)
            {
                var curInc = sender as SwipeItem;
                var income = curInc.CommandParameter as Incomes;
                App.IncDatabase.DeleteItem(income.Id);
                Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) - Convert.ToDecimal(income.AmountInc);
                await DisplayAlert("Succesfully", "Item is Deleted", "Ok");

            }


        }


    }
}