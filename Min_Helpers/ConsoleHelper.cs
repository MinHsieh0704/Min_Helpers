using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Min_Helpers
{
    /// <summary>
    /// Console Helper
    /// </summary>
    public class ConsoleHelper
    {
        private class IWriteQueue
        {
            public object message { get; set; }

            public ConsoleColor color { get; set; }
        }

        private static Subject<IWriteQueue> WriteQueue = new Subject<IWriteQueue>();

        /// <summary>
        /// Mode
        /// </summary>
        public enum EMode
        {
            /// <summary>
            /// error
            /// </summary>
            error = ConsoleColor.Red,

            /// <summary>
            /// info
            /// </summary>
            info = ConsoleColor.Cyan,

            /// <summary>
            /// warning
            /// </summary>
            warning = ConsoleColor.Yellow,

            /// <summary>
            /// success
            /// </summary>
            success = ConsoleColor.Green,

            /// <summary>
            /// question
            /// </summary>
            question = ConsoleColor.Magenta,

            /// <summary>
            /// message
            /// </summary>
            message = ConsoleColor.White,
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public static void Initialize()
        {
            WriteQueue = new Subject<IWriteQueue>();

            WriteQueue
                .ObserveOn(NewThreadScheduler.Default)
                .Subscribe((x) => {
                    Console.ForegroundColor = x.color;
                    Console.Write(x.message);
                    Console.ResetColor();
                });
        }

        /// <summary>
        /// Console Write
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Write(object message, ConsoleColor color)
        {
            WriteQueue.OnNext(new IWriteQueue()
            {
                message = message,
                color = color
            });
        }

        /// <summary>
        /// Console Write
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public static void Write(object message, EMode mode)
        {
            Write(message, (ConsoleColor)mode);
        }

        /// <summary>
        /// Console Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void WriteLine(object message, ConsoleColor color)
        {
            Write($"{message}\n", color);
        }

        /// <summary>
        /// Console Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public static void WriteLine(object message, EMode mode)
        {
            Write($"{message}\n", (ConsoleColor)mode);
        }

        /// <summary>
        /// Console DateTime and Mode and Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public static void Log(object message, EMode mode = EMode.message)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string title = "";
            switch (mode)
            {
                case EMode.error:
                    title = "   Error";
                    break;
                case EMode.info:
                    title = "    Info";
                    break;
                case EMode.question:
                    title = "Question";
                    break;
                case EMode.success:
                    title = " Success";
                    break;
                case EMode.warning:
                    title = " Warning";
                    break;
                default:
                    title = " Message";
                    break;
            }

            WriteLine($"{date} {title} ---> {message}", mode);
        }

        /// <summary>
        /// Console New Line
        /// </summary>
        public static void NewLine()
        {
            WriteLine("", ConsoleColor.White);
        }
    }
}
