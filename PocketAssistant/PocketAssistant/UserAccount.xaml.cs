using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
namespace PocketAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAccount : MasterDetailPage
    {

        List<Entry> expEntries = new List<Entry>
        {
            //Заполнение диаграмм данными из свойств проекта.
            new Entry( float.Parse(App.Current.Properties["Food/Dining"].ToString()))
            {

                Color = SkiaSharp.SKColor.Parse("#FFFF8C00"),
                Label = "Food/Dining",
                ValueLabel = App.Current.Properties["Food/Dining"].ToString()  +" BLR"

            },
            new Entry(float.Parse(App.Current.Properties["Other"].ToString()))
            {
               Color = SKColor.Parse("#FF4682B4"),
               Label = "Other",
               ValueLabel = App.Current.Properties["Other"].ToString()  +" BLR"
            },
            new Entry (float.Parse(App.Current.Properties["Clothing"].ToString()))
            {
                Color = SKColor.Parse("#FFDA70D6"),
                Label = "Clothing",
                ValueLabel  = App.Current.Properties["Clothing"].ToString()  +" BLR"
            },
            new Entry(float.Parse(App.Current.Properties["Transportation"].ToString()))
            {
                Color = SKColor.Parse(" #FF7CFC00"),
                Label = "Transport",
                ValueLabel = App.Current.Properties["Transportation"].ToString() +" BLR"
            }
         };
        List<Entry> incEntries = new List<Entry>
        {
            new Entry(float.Parse(App.Current.Properties["Wage"].ToString()))
            {
                Color =SKColor.Parse("#FFFF8C00"),
                Label = "Wage",
                ValueLabel = App.Current.Properties["Wage"].ToString() + " BLR"
            },
             new Entry(float.Parse(App.Current.Properties["Gifts"].ToString()))
            {
                Color =SKColor.Parse("#FF4682B4"),
                Label = "Gifts",
                ValueLabel = App.Current.Properties["Gifts"].ToString() + " BLR"
            },
              new Entry(float.Parse(App.Current.Properties["Business"].ToString()))
            {
                Color =SKColor.Parse("#FFDA70D6"),
                Label = "Business",
                ValueLabel = App.Current.Properties["Business"].ToString() + " BLR"
            },
               new Entry(float.Parse(App.Current.Properties["OtherIncome"].ToString()))
            {
                Color =SKColor.Parse("#FF7CFC00"),
                Label = "Other",
                ValueLabel = App.Current.Properties["OtherIncome"].ToString() + " BLR"
            },
        };
        decimal userAmount;
        public UserAccount()
        {
            InitializeComponent();
           
           
            NavigationPage.SetHasNavigationBar(this, false);
            Amount.Text = Application.Current.Properties["AMOUNT"].ToString() + " BLR";
     
            WelcomeText.Text = "Welcome, " + Application.Current.Properties["USERNAME"].ToString();
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Device.BeginInvokeOnMainThread(() => DateTimeNow.Text = DateTime.Now.ToString());
                return true;
            });
            //Создание диаграмм.
            ExpChart1.Chart = new RadialGaugeChart { Entries = expEntries, LabelTextSize = 35 ,};
            ExpChart2.Chart = new PointChart { Entries = expEntries, LabelTextSize = 35 };
            IncChart1.Chart = new RadialGaugeChart { Entries = incEntries, LabelTextSize = 35, };
            IncChart2.Chart = new PointChart { Entries = incEntries, LabelTextSize = 35, };

        }
        private  void Expenses_Click(object sender, EventArgs e)
        {

            Detail = new NavigationPage(new Expenses());
        }
       
        private  void MasterMainPage_Click(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new UserAccount());
        }
        private void ExpensesMaster_Click(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new Expenses());
        }
       
        private void Income_Click(object sender , EventArgs e)
        {
            Detail = new NavigationPage(new Income());
        }
        private void IncomesMaster_Click(object sender , EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new Income());
        }
        private  void Journal_Click(object sender, EventArgs e)
        {
            
            Detail = new NavigationPage(new JournalLog());
        }
        private void MasterJournal_Click (object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new JournalLog());
        }

        private void MasterDebts_Click( object sender , EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new DebtsList());
        }

        private async void Savings_Click(object sender , EventArgs e)
        {
            Detail = new NavigationPage(new CreateSavings());
        }
    }
}