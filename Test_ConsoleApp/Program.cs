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
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            Log LogService = new Log();

            Print PrintService = new Print(LogService);

            try
            {
                PrintService.MessageLine(new List<Print.IWriteMessage>() {
                    new Print.IWriteMessage(){ message = "title", background = ConsoleColor.Red },
                    new Print.IWriteMessage(){ message = "body", font = ConsoleColor.Red },
                    new Print.IWriteMessage(){ message = "foot", background = ConsoleColor.Red, font = ConsoleColor.Blue }
                });

                PrintService.NewLine();

                PrintService.WriteLine("error", Print.EMode.error);
                PrintService.WriteLine("info", Print.EMode.info);
                PrintService.WriteLine("message", Print.EMode.message);
                PrintService.WriteLine("question", Print.EMode.question);
                PrintService.WriteLine("success", Print.EMode.success);
                PrintService.WriteLine("warning", Print.EMode.warning);

                PrintService.NewLine();

                PrintService.WriteLine("Title", "error", Print.EMode.error);
                PrintService.WriteLine("Title", "info", Print.EMode.info);
                PrintService.WriteLine("Title", "message", Print.EMode.message);
                PrintService.WriteLine("Title", "question", Print.EMode.question);
                PrintService.WriteLine("Title", "success", Print.EMode.success);
                PrintService.WriteLine("Title", "warning", Print.EMode.warning);

                PrintService.NewLine();

                PrintService.Log("error", Print.EMode.error);
                PrintService.Log("info", Print.EMode.info);
                PrintService.Log("message", Print.EMode.message);
                PrintService.Log("question", Print.EMode.question);
                PrintService.Log("success", Print.EMode.success);
                PrintService.Log("warning", Print.EMode.warning);

                PrintService.Log("warning", Print.EMode.warning);
                PrintService.Log("warning", Print.EMode.warning, "test");
                PrintService.Log("warning", "test", Print.EMode.warning);
                PrintService.Log("warning", "test", Print.EMode.warning, "test");
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
