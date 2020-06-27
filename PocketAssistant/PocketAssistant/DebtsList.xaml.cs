using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebtsList : CarouselPage
    {
        public DebtsList()
        {
            InitializeComponent();
            BorrowList.RefreshCommand = new Command(() =>
            {
                RefreshDataInBorrow();
                BorrowList.IsRefreshing = false;
            });
            lentList.RefreshCommand = new Command(() => {
                //Do your stuff.
                RefreshDataInLent();
                lentList.IsRefreshing = false;
            });
           


        }
        public void RefreshDataInBorrow()
        {
            BorrowList.ItemsSource = null;
            BorrowList.ItemsSource = App.BorrowDatabase.GetItems();
        }
        public void RefreshDataInLent()
        {

            lentList.ItemsSource = null;
            lentList.ItemsSource = App.LentDatabase.GetItems();
        }
        private async void Lend_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateLend());
        }
        private  async void Borrow_Click(object sender , EventArgs e)
        {
            await Navigation.PushAsync(new CreateBorrow());
        }
        protected override void OnAppearing()
        {

           lentList.ItemsSource = App.LentDatabase.GetItems();
            BorrowList.ItemsSource = App.BorrowDatabase.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LentClass selectedExp = (LentClass)e.SelectedItem;

            

            await DisplayAlert("WWW", "WWW", "WWW");

        }



        private  async void SwipeItem_OnInvoked(object sender, EventArgs e)
        {
           bool a = await DisplayAlert("Delete item", "Are you sure you want to delete ? ","Yes" ,"Cancel");
            if (a == true)
            {
                var curLent = sender as SwipeItem;
                var lent = curLent.CommandParameter as LentClass;
                App.LentDatabase.DeleteItem(lent.Id);
                Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) + Convert.ToDecimal(lent.Amount);
             await DisplayAlert("Succesfully", "Item is Deleted", "Ok");
               
            }


        }
        
        private async void SwipeBorrow_OnInvoked(object sender, EventArgs e)
        {
            bool a = await DisplayAlert("Delete item", "Are you sure you want to delete ? ", "Yes", "Cancel");
            if (a == true)
            {
                var curBorr = sender as SwipeItem;
                var borrow = curBorr.CommandParameter as Borrow;
                App.BorrowDatabase.DeleteItem(borrow.Id);
                Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) - Convert.ToDecimal(borrow.Amount);
                await DisplayAlert("Succesfully", "Item is Deleted", "Ok");
               
            }

        }

       
    }
}