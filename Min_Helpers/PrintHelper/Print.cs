using Min_Helpers.LogHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Min_Helpers.PrintHelper
{
    /// <summary>
    /// Console Helper
    /// </summary>
    public class Print
    {
        #region EMode
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
        #endregion

        /// <summary>
        /// IWriteMessage
        /// </summary>
        public class IWriteMessage
        {
            /// <summary>
            /// message
            /// </summary>
            public object message { get; set; }

            /// <summary>
            /// font
            /// </summary>
            public ConsoleColor? font { get; set; }

            /// <summary>
            /// background
            /// </summary>
            public ConsoleColor? background { get; set; }
        }

        private Log log { get; set; }

        private static object @lock { get; set; } = new object();

        /// <summary>
        /// ConsoleHelper
        /// </summary>
        public Print()
        {
            this.log = new Log();
        }

        /// <summary>
        /// ConsoleHelper
        /// </summary>
        /// <param name="log"></param>
        public Print(Log log)
        {
            this.log = log;
        }

        /// <summary>
        /// Console Write
        /// </summary>
        /// <param name="messages"></param>
        private void Base(List<IWriteMessage> messages)
        {
            lock (Print.@lock)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    var message = messages[i];

                    if (message.font != null) Console.ForegroundColor = (ConsoleColor)message.font;
                    if (message.background != null) Console.BackgroundColor = (ConsoleColor)message.background;
                    Console.Write(message.message);
                    Console.ResetColor();

                    if (i != messages.Count - 1) Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Console Write Message
        /// </summary>
        /// <param name="messages"></param>
        public void Message(List<IWriteMessage> messages)
        {
            this.Base(messages);
        }

        /// <summary>
        /// Console Write Message Line
        /// </summary>
        /// <param name="messages"></param>
        public void MessageLine(List<IWriteMessage> messages)
        {
            messages.Add(new IWriteMessage() { message = "\n" });
            this.Base(messages);
        }

        /// <summary>
        /// Console Write
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void Write(object message, ConsoleColor color)
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = message, font = color }
            });
        }

        /// <summary>
        /// Console Write
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public void Write(object message, EMode mode)
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = message, font = (ConsoleColor)mode }
            });
        }

        /// <summary>
        /// Console Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void WriteLine(object message, ConsoleColor color)
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = $"{message}\n", font = color }
            });
        }

        /// <summary>
        /// Console Write Line with Title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void WriteLine(string title, object message, ConsoleColor color)
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = $"{title}", font = color },
                new IWriteMessage() { message = $"--->", font = color },
                new IWriteMessage() { message = $"{message}\n" }
            });
        }

        /// <summary>
        /// Console Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public void WriteLine(object message, EMode mode)
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = $"{message}\n", font = (ConsoleColor)mode }
            });
        }

        /// <summary>
        /// Console Write Line with Title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public void WriteLine(string title, object message, EMode mode)
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = $"{title}", font = (ConsoleColor)mode },
                new IWriteMessage() { message = $"--->", font = (ConsoleColor)mode },
                new IWriteMessage() { message = $"{message}\n" }
            });
        }

        /// <summary>
        /// Console New Line
        /// </summary>
        public void NewLine()
        {
            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = "" }
            });
        }

        /// <summary>
        /// Console DateTime and Mode and Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public void Log(object message, EMode mode)
        {
            StackTrace trace = new StackTrace(true);
            StackFrame frame = trace.GetFrames().Where((n) => n.GetFileName() != null).FirstOrDefault();

            string path = "";
            if (frame != null)
            {
                Type declaringType = frame.GetMethod().DeclaringType;
                while (true)
                {
                    if (declaringType.DeclaringType == null) break;
                    declaringType = declaringType.DeclaringType;
                }

                path = $"{declaringType.FullName}:line {frame.GetFileLineNumber()}";
            }

            this.Log(message, path, mode, null);
        }

        /// <summary>
        /// Console DateTime and Mode and Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        public void Log(object message, EMode mode, string type)
        {
            StackTrace trace = new StackTrace(true);
            StackFrame frame = trace.GetFrame(trace.FrameCount - 1);

            string path = $"{frame.GetMethod().DeclaringType.FullName}:line {frame.GetFileLineNumber()}";

            this.Log(message, path, mode, type);
        }

        /// <summary>
        /// Console DateTime and Mode and Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        public void Log(object message, string path, EMode mode)
        {
            this.Log(message, path, mode, null);
        }

        /// <summary>
        /// Console DateTime and Mode and Write Line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        public void Log(object message, string path, EMode mode, string type)
        {
            ConsoleColor color = (ConsoleColor)mode;

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

            this.Base(new List<IWriteMessage>()
            {
                new IWriteMessage() { message = $"{date}", font = color },
                new IWriteMessage() { message = $"{title}", font = color },
                new IWriteMessage() { message = $"--->", font = color },
                new IWriteMessage() { message = $"[{Thread.CurrentThread.ManagedThreadId}]", font = color },
                new IWriteMessage() { message = $"{message}" },
                new IWriteMessage() { message = $"({path})\n" }
            });

            if (type == null)
            {
                this.log.Write($"{date} {title} ---> [{Thread.CurrentThread.ManagedThreadId}] {message} ({path})");
            }
            else
            {
                this.log.Write($"{date} {title} ---> [{Thread.CurrentThread.ManagedThreadId}] {message} ({path})", type);
            }
        }
    }
}
