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
    public partial class UserNameLastName : ContentPage
    {
        string userNameEntered;
        
        
        public UserNameLastName()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }
        private async  void  UserNameSurnm_Click(object sender , EventArgs e)
        {
         
            string nameUser = userName.Text;
            if (string.IsNullOrEmpty(nameUser))
            {
                DisplayAlert("Warning", "Please,enter your name.", "Ok");
            }
            else
            {
                Application.Current.Properties["USERNAME"] = userName.Text;
                await Navigation.PushAsync(new StartSum(userNameEntered));
            }

        

        }

        
        
        
    }
}