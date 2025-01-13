using System;
using FlavorFusion.Data;
using System.IO;
using FlavorFusion.Data;

namespace FlavorFusion
{
    public partial class App : Application
    {
        static FlavorFusionDatabase database;
        public static FlavorFusionDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   FlavorFusionDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ShoppingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

    }
}
