using SmoothieTruckApp.Front_End;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Services;
using System.Diagnostics;

namespace SmoothieTruckApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Contains(SmokeTest.Argument))
            {
                return SmokeTest.Run(DefaultDatabaseContext.Engine);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Home());
            return 0;


           
        }
    }
} 
