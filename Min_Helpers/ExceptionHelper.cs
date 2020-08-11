using System;
using System.Collections.Generic;

namespace Min_Helpers
{
    /// <summary>
    /// Exception Helper
    /// </summary>
    public class ExceptionHelper
    {
        /// <summary>
        /// Get Real
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static T GetReal<T>(Exception exception) where T : Exception
        {
            try
            {
                while (true)
                {
                    if (exception?.InnerException == null)
                        break;

                    exception = exception.InnerException;

                    Type type = exception.GetType();
                    if (type == typeof(T))
                        break;
                }

                return exception as T;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Real
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Exception GetReal(Exception exception)
        {
            try
            {
                while (true)
                {
                    if (exception?.InnerException == null)
                        break;

                    exception = exception.InnerException;
                }

                return exception;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Real List
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static List<Exception> GetReals(Exception exception)
        {
            try
            {
                List<Exception> exceptions = new List<Exception>();

                while (true)
                {
                    if (exception == null)
                        break;

                    exceptions.Add(exception);

                    if (exception.InnerException == null)
                        break;

                    exception = exception.InnerException;
                }

                return exceptions;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
