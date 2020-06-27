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
    public partial class CreateSavings : ContentPage
    {
        public CreateSavings()
        {
            InitializeComponent();
            CurrentBalance.Text = Application.Current.Properties["AMOUNT"].ToString() + " BLR";
            CurrSavings.Text = Application.Current.Properties["SAVINGS"].ToString() + " BLR";
        }
        private async void AddSav_Click(object sender ,EventArgs e)
        {
            bool userAnswer = await DisplayAlert("Warning", "Do you want to increase from current balance?", "Yes","No");
            if (userAnswer == true)
            {
                Convert.ToDecimal(Application.Current.Properties["SAVINGS"]);
              Application.Current.Properties["SAVINGS"] = Convert.ToDecimal(Application.Current.Properties["SAVINGS"]) + Convert.ToDecimal(UserSavings.Text);
                Application.Current.Properties["AMOUNT"] =  Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) - Convert.ToDecimal(UserSavings.Text);
                Navigation.PushAsync(new CreateSavings());
            }
            else
            {

                Application.Current.Properties["SAVINGS"] =Convert.ToDecimal(Application.Current.Properties["SAVINGS"]) +Convert.ToDecimal(UserSavings.Text);
                Navigation.PushAsync(new CreateSavings());
            }
            
        }
        private void Transfer_Click(object sender ,EventArgs e)
        {
            if (Convert.ToDecimal(TransfAmount.Text) < Convert.ToDecimal(Application.Current.Properties["SAVINGS"]) && Convert.ToDecimal(TransfAmount.Text) >= 0)
            {
                Application.Current.Properties["SAVINGS"] = Convert.ToDecimal(Application.Current.Properties["SAVINGS"]) - Convert.ToDecimal(TransfAmount.Text);
                Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) + Convert.ToDecimal(TransfAmount.Text);
                Navigation.PushAsync(new CreateSavings());
                
            }
            else
            {
                DisplayAlert("Warning", "Entered amount is bigger than savings or less than null", "Ok");
            }
           
        }
    }
}