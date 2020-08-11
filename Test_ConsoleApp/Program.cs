using Min_Helpers;
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
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            ConsoleHelper.Initialize();

            try
            {
                ConsoleHelper.WriteLine("error", ConsoleHelper.EMode.error);
                ConsoleHelper.WriteLine("info", ConsoleHelper.EMode.info);
                ConsoleHelper.WriteLine("message", ConsoleHelper.EMode.message);
                ConsoleHelper.WriteLine("question", ConsoleHelper.EMode.question);
                ConsoleHelper.WriteLine("success", ConsoleHelper.EMode.success);
                ConsoleHelper.WriteLine("warning", ConsoleHelper.EMode.warning);
            }
            catch (Exception ex)
            {
                ex = ExceptionHelper.GetReal(ex);
                ConsoleHelper.WriteLine($"{ex.Message}", ConsoleHelper.EMode.error);
            }
            finally
            {
                Console.ReadKey();

                Environment.Exit(0);
            }
        }
    }
}
