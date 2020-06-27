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
    public partial class StartSum : ContentPage
    {
      
        public StartSum(string a)
        {
           
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Label1.Text = "Hello, " + Application.Current.Properties["USERNAME"];

            //Инициализация свойств приложения,которые будут использоваться в построение диаграмм.
            App.Current.Properties["Food/Dining"] = 0;
            App.Current.Properties["Clothing"] = 0;
            App.Current.Properties["Transportation"] = 0;
            App.Current.Properties["Other"] = 0;

            App.Current.Properties["Wage"] = 0;
            App.Current.Properties["Gifts"] = 0;
            App.Current.Properties["Business"] = 0;
            App.Current.Properties["OtherIncome"] = 0;
            App.Current.Properties["SAVINGS"] = 0;


        }

        private async void WeAreStart_Click(object sender , EventArgs e)
        {
            string startSuma = StartSuma.Text;
            if (string.IsNullOrEmpty(startSuma))
            {
                DisplayAlert("WARNING", "Enter your start amount", "Ok");
            }
            else
            {
                Application.Current.Properties["AMOUNT"] = StartSuma.Text;
                await Navigation.PushAsync(new UserAccount());
            }
           
                
            
            

            
        }







    }
    
}