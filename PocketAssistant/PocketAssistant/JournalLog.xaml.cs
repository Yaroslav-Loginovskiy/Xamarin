using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace PocketAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalLog : ContentPage
    {

        public JournalLog()
        {
            InitializeComponent();
            

        }

        

        protected override void OnAppearing()
        {
            List<Expences> expences = App.Database.GetItems();
            List<Incomes> incomes = App.IncDatabase.GetItems();
            List<Object> listObj = expences.Cast<Object>()
                .Concat(incomes)
                .ToList();
            
            JournalList.ItemsSource = listObj;
            base.OnAppearing();
        }

        //private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        
        //}
    }
}