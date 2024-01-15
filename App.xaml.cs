using System;
using HolidayPlanner.Data;
using System.IO;
namespace HolidayPlanner
{
    public partial class App : Application
    {

        static NotesDatabase database;
        public static NotesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                    NotesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        static PlannerListDatabase databasee;
        public static PlannerListDatabase Databasee
        {
            get
            {
                if (databasee == null)
                {
                    databasee = new
                    PlannerListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "PlannerList.db3"));
                }
                return databasee;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
