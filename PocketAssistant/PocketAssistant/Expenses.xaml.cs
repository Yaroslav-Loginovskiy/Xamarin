using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace PocketAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Expenses : ContentPage
    {
       
        public Expenses()
        {
            InitializeComponent();
           
        }
        private  void SaveExp_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(AmountEntry.Text  ))
            {
                DisplayAlert("Warning", "Enter your expence.", "Ok");
                
            }
            else
            {
                if (picker.SelectedIndex < 0)
                {
                    Expences expence = new Expences()
                    {
                        AmountExp = AmountEntry.Text,
                        Description = DescEntry.Text,
                        Date = Date_Picker.Date.ToString(),

                    };
                    App.Database.SaveItem(expence);
                    Convert.ToDecimal(Application.Current.Properties["AMOUNT"]);
                    Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) - Convert.ToDecimal(expence.AmountExp);

                    string a = "-" + AmountEntry.Text + " BLR";
                    DisplayAlert("Succesfully , your expence is:", a, "Ok");
                    AmountEntry.Text = null;
                    DescEntry.Text = null;
                   
                }
                else
                {
                    Expences expence = new Expences()
                    {
                        AmountExp = AmountEntry.Text,
                        Description = DescEntry.Text,
                        Date = Date_Picker.Date.ToString(),
                        Category = picker.Items[picker.SelectedIndex]


                    };
                    string userPicker = picker.Items[picker.SelectedIndex];
                    switch (userPicker)
                    {
                        case "Food/Dining":
                            App.Current.Properties["Food/Dining"] = Convert.ToDecimal(App.Current.Properties["Food/Dining"]) + Convert.ToDecimal(expence.AmountExp);
                            break;
                        case "Clothing":
                            App.Current.Properties["Clothing"] = Convert.ToDecimal(App.Current.Properties["Clothing"]) + Convert.ToDecimal(expence.AmountExp);
                            break;
                        case "Transportation":
                            App.Current.Properties["Transportation"] = Convert.ToDecimal(App.Current.Properties["Transportation"]) + Convert.ToDecimal(expence.AmountExp);
                            break;
                        case "Other":
                            App.Current.Properties["Other"] = Convert.ToDecimal(App.Current.Properties["Other"]) + Convert.ToDecimal(expence.AmountExp);
                            break;
                    }
                    App.Database.SaveItem(expence);
                    Convert.ToDecimal(Application.Current.Properties["AMOUNT"]);
                    Application.Current.Properties["AMOUNT"] = Convert.ToDecimal(Application.Current.Properties["AMOUNT"]) - Convert.ToDecimal(expence.AmountExp);

                    string a = "-" + AmountEntry.Text + " BLR";
                    DisplayAlert("Succesfully , your expence is:", a, "Ok");
                    AmountEntry.Text = null;
                    DescEntry.Text = null;
                  
                }
            }
           
                
           
        }
        private async void OverView_Click(object sender , EventArgs e)
        {
            await Navigation.PushAsync(new ExpencesList());
        }
       
        //  private void  picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        
        //}
       
    }
}