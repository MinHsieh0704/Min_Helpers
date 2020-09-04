using Min_Helpers;
using Min_Helpers.LogHelper;
using Min_Helpers.PrintHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_ConsoleApp
{
    class Program
    {
        static Print PrintService { get; set; } = null;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            PrintService = new Print();

            try
            {
                
            }
            catch (Exception ex)
            {
                ex = ExceptionHelper.GetReal(ex);
                PrintService.WriteLine($"{ex.Message}", Print.EMode.error);
            }
            finally
            {
                Console.ReadKey();

                Environment.Exit(0);
            }
        }
    }
}
