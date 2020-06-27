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
    public partial class CreateLend : ContentPage
    {
       
        public CreateLend()
        {
            InitializeComponent();
        }
       

        private async void AddLent_Click (object sender , EventArgs e)
        {

            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(LentAmount.Text))
            {
                DisplayAlert("Warning", "Enter Amount and Name", "Ok");
            }
            else
            {
                bool userAnswer = await DisplayAlert("Warning", "Do you want to subtract from the current balance?", "Yes", "No");
                if (userAnswer == true)
                {
                    LentClass lent = new LentClass()
                    {
                        Name = UserName.Text,
                        Amount = Convert.ToInt32(LentAmount.Text),
                        Description = LentDescription.Text,
                        Date = Date_Picker.Date.ToString("dd/MM/yyyy")


                    };

                    App.LentDatabase.SaveItem(lent);
                    UserName.Text = null;
                    LentAmount = null;
                    LentDescription = null;

                    Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) - Convert.ToDecimal(lent.Amount);
                   await DisplayAlert("Succesfully", "Debt is created", "Ok");
                    await Navigation.PushAsync(new DebtsList());
                }
                else
                {
                    LentClass lent = new LentClass()
                    {
                        Name = UserName.Text,
                        Amount = Convert.ToInt32(LentAmount.Text),
                        Description = LentDescription.Text,
                        Date = Date_Picker.Date.ToString("dd/MM/yyyy")


                    };

                    App.LentDatabase.SaveItem(lent);
                    UserName.Text = null;
                    LentAmount = null;
                    LentDescription = null;
                    await DisplayAlert("Succesfully", "Debt is created", "Ok");
                    await Navigation.PushAsync(new DebtsList());
                }
               
            }
        }
       


    }
}