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
    public partial class Income : ContentPage
    {
        public Income()
        {
            InitializeComponent();
            
        }

        private void SaveInc_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(AmountEntry.Text))
            {
                DisplayAlert("Warning", "Enter your income.", "Ok");

            }
            else
            {
                
               
                if (picker.SelectedIndex<0)
                {
                    Incomes income = new Incomes()
                    {
                        AmountInc = AmountEntry.Text,
                        Description = DescEntry.Text,
                        Date = Date_Picker.Date.ToString(),
                    };
                    App.IncDatabase.SaveItem(income);


                    Convert.ToDecimal(Application.Current.Properties["AMOUNT"]);
                    Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) + Convert.ToDecimal(AmountEntry.Text);

                    string a = "+" + AmountEntry.Text + " BLR";
                    DisplayAlert("Succesfully , your income is:", a, "Ok");
                    AmountEntry.Text = null;
                    DescEntry.Text = null;
                   
                }
                else
                {
                    Incomes income = new Incomes()
                    {
                        AmountInc = AmountEntry.Text,
                        Description = DescEntry.Text,
                        Date = Date_Picker.Date.ToString(),
                        Category = picker.Items[picker.SelectedIndex]
                    };
                    string userPicker = picker.Items[picker.SelectedIndex];
                    switch (userPicker)
                    {
                        case "Wage":
                            App.Current.Properties["Wage"] = Convert.ToDecimal(App.Current.Properties["Wage"]) + Convert.ToDecimal(income.AmountInc) ;
                            break;
                        case "Gifts":
                            App.Current.Properties["Gifts"] = Convert.ToDecimal(App.Current.Properties["Gifts"]) + Convert.ToDecimal(income.AmountInc);
                            break;
                        case "Business":
                            App.Current.Properties["Business"] = Convert.ToDecimal(App.Current.Properties["Business"]) + Convert.ToDecimal(income.AmountInc);
                            break;
                        case "Other":
                            App.Current.Properties["OtherIncome"] = Convert.ToDecimal(App.Current.Properties["OtherIncome"]) + Convert.ToDecimal(income.AmountInc);
                            break;
                    }
                    App.IncDatabase.SaveItem(income);


                    Convert.ToDecimal(Application.Current.Properties["AMOUNT"]);
                    Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) + Convert.ToDecimal(AmountEntry.Text);

                    string a = "+" + AmountEntry.Text + " BLR";
                    DisplayAlert("Succesfully , your income is:", a, "Ok");
                    AmountEntry.Text = null;
                    DescEntry.Text = null;
                    
                }
            }



        }
        private async void OverView_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IncomesListxaml());
        }
        
        private void picker_SelectedIndexChanged(object sender , EventArgs e)
        {

        }



    }
}