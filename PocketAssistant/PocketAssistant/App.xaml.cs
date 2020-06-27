using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PocketAssistant.DataRepositories;

namespace PocketAssistant
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "Expences.db";
        public static ExpenceRepository database;
        public static BorrowRepository Borrowdatabase;
        public static LentRepository Lentdatabase;
        public static IncomeRepository Incdatabase;
       
        public static string FilePath;
        public static BorrowRepository BorrowDatabase
        {
            get
            {
                if (Borrowdatabase == null)
                {
                    Borrowdatabase = new BorrowRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return Borrowdatabase;
            }
        }
        public static LentRepository LentDatabase
        {
            get
            {
                if (Lentdatabase == null)
                {
                    Lentdatabase = new LentRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return Lentdatabase;
            }
        }
        public static IncomeRepository IncDatabase
        {
            get
            {
                if (Incdatabase == null)
                {
                    Incdatabase = new IncomeRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return Incdatabase;
            }
        }
        public static ExpenceRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ExpenceRepository(Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            
            // MainPage = new NavigationPage(new PocketAssistant.MainPage());

            FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
            Device.SetFlags(new[] {
                "SwipeView_Experimental"
            });

        }


        protected override void OnStart()
        {
            Debug.WriteLine("On debug");
            if (Application.Current.Properties.ContainsKey("AMOUNT"))
            {
                MainPage = new UserAccount();
            }
            else
            {
                
                MainPage = new NavigationPage(new MainPage());
            }
            
        }

        protected override void OnSleep()
        {
            

        }

        protected override void OnResume()
        {
            
        }
    }
}
