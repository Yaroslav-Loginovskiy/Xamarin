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
    public partial class CreateBorrow : ContentPage
    {
        public CreateBorrow()
        {
            InitializeComponent();
        }
        private async void AddBorrow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(BorrowAmount.Text))
            {
                DisplayAlert("Warning", "Enter Amount and Name", "Ok");
            }
            else
            {
                bool userAnswer = await DisplayAlert("Warning","Do you want to add to the current balance?", "Yes", "No");
                if (userAnswer == true)
                {
                    Borrow borrow = new Borrow()
                    {
                        Name = UserName.Text,
                        Amount = Convert.ToInt32(BorrowAmount.Text),
                        Description = BorrowDescription.Text,
                        Date = Date_Picker.Date.ToString("dd/MM/yyyy")
                    };
                    App.BorrowDatabase.SaveItem(borrow);
                    UserName.Text = null;
                    BorrowAmount.Text = null;
                    BorrowDescription.Text = null;
                    await DisplayAlert("Succesfully", "Debt is created", "Ok");
                    Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) + Convert.ToDecimal(borrow.Amount);
                    await Navigation.PushAsync(new DebtsList());

                }
                else
                {
                    Borrow borrow = new Borrow()
                    {
                        Name = UserName.Text,
                        Amount = Convert.ToInt32(BorrowAmount.Text),
                        Description = BorrowDescription.Text,
                        Date = Date_Picker.Date.ToString("dd/MM/yyyy")
                    };
                    App.BorrowDatabase.SaveItem(borrow);
                    UserName.Text = null;
                    BorrowAmount.Text = null;
                    BorrowDescription.Text = null;
                    await DisplayAlert("Succesfully", "Debt is created", "Ok");
                    await Navigation.PushAsync(new DebtsList());
                }
                
            }

        }
    }
}