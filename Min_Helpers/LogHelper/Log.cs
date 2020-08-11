using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Min_Helpers.LogHelper
{
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
        private ILog log { get; set; }

        /// <summary>
        /// Log
        /// </summary>
        public Log()
        {
            this.log = LogManager.GetLogger(typeof(Log));
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="fileInfo"></param>
        public void Initialize(FileInfo fileInfo)
        {
            try
            {
                ILoggerRepository repository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy));
                XmlConfigurator.Configure(repository, fileInfo);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            try
            {
                this.log.Debug(message);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        /// <param name="trace"></param>
        public void Debug(object message, StackTrace trace)
        {
            try
            {
                if (trace == null)
                {
                    throw new Exception("trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Debug($"{message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        public void Debug(Exception message)
        {
            try
            {
                StackTrace trace = new StackTrace(message, true);
                if (trace == null)
                {
                    throw new Exception("exception trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Debug($"{message.Message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            try
            {
                this.log.Info(message);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        /// <param name="trace"></param>
        public void Info(object message, StackTrace trace)
        {
            try
            {
                if (trace == null)
                {
                    throw new Exception("trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Info($"{message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        public void Info(Exception message)
        {
            try
            {
                StackTrace trace = new StackTrace(message, true);
                if (trace == null)
                {
                    throw new Exception("exception trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Info($"{message.Message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            try
            {
                this.log.Warn(message);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message"></param>
        /// <param name="trace"></param>
        public void Warn(object message, StackTrace trace)
        {
            try
            {
                if (trace == null)
                {
                    throw new Exception("trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Warn($"{message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message"></param>
        public void Warn(Exception message)
        {
            try
            {
                StackTrace trace = new StackTrace(message, true);
                if (trace == null)
                {
                    throw new Exception("exception trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Warn($"{message.Message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            try
            {
                this.log.Error(message);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="trace"></param>
        public void Error(object message, StackTrace trace)
        {
            try
            {
                if (trace == null)
                {
                    throw new Exception("trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Error($"{message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        public void Error(Exception message)
        {
            try
            {
                StackTrace trace = new StackTrace(message, true);
                if (trace == null)
                {
                    throw new Exception("exception trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Error($"{message.Message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            try
            {
                this.log.Fatal(message);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message"></param>
        /// <param name="trace"></param>
        public void Fatal(object message, StackTrace trace)
        {
            try
            {
                if (trace == null)
                {
                    throw new Exception("trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Fatal($"{message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(Exception message)
        {
            try
            {
                StackTrace trace = new StackTrace(message, true);
                if (trace == null)
                {
                    throw new Exception("exception trace can not null");
                }

                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string path = $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";

                this.log.Fatal($"{message.Message} ({path})");
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"log helper: {ex.Message}", ex);

                throw exception;
            }
        }
    }
}
