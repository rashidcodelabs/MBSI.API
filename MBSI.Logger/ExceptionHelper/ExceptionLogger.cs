using MBSI.Logger.Helpers;
using MBSI.Logger.LogModels;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.Logger.ExceptionHelper
{
    public class ExceptionLogger : Exception
    {
        #region Logger Methods
        public static string WriteLog(Exception exception)
        {
            try
            {
                string message;
                message = exception.GetBaseException() != null ? exception.GetBaseException().Message : string.Empty;


                var routeData = HttpContextHelper.Current;

                if (routeData != null)
                {
                    var action = routeData.GetRouteValue("action").ToString();
                    var controller = routeData.GetRouteValue("controller").ToString();

                    var exceptionLog = new ExceptionLogModel
                    {
                        Action = action,
                        Controller = controller,
                        IPAddress = routeData.Connection.RemoteIpAddress.ToString(),
                        Exception = message + (exception.InnerException != null ? "-" + exception.InnerException.Message : string.Empty),
                        ExceptionTime = DateTime.Now
                    };

                    var jsonExceptionLog = JsonConvert.SerializeObject(exceptionLog);

                    try
                    {
                        var logsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                        if (!Directory.Exists(logsFolderPath))
                        {
                            Directory.CreateDirectory(logsFolderPath);
                        }
                        var logFilePath = Path.Combine(logsFolderPath, $"Exception Log-({DateTime.Now.Date.ToString("dd-MM-yyyy")}).txt");
                        File.AppendAllText(logFilePath, Environment.NewLine + Environment.NewLine + jsonExceptionLog);
                    }
                    catch { }
                }
                return message;
            }
            catch (Exception)
            {
                // Handle the exception appropriately
                throw;
            }
        }

        public static void WriteLog(string message)
        {
            try
            {
                var routeData = HttpContextHelper.Current;

                if (routeData != null)
                {
                    var action = routeData.GetRouteValue("action").ToString();
                    var controller = routeData.GetRouteValue("controller").ToString();

                    var exceptionLog = new ExceptionLogModel
                    {
                        Action = action,
                        Controller = controller,
                        IPAddress = routeData.Connection.RemoteIpAddress.ToString(),
                        Exception = message,
                        ExceptionTime = DateTime.Now
                    };

                    var jsonExceptionLog = JsonConvert.SerializeObject(exceptionLog);

                    ////For DMG.WebAPI Executing Assembly folder location
                    //var contentRootPath = Assembly.GetExecutingAssembly().Location;
                    //contentRootPath = Path.GetDirectoryName(contentRootPath);
                    //logsDirectory = Path.Combine(contentRootPath, "logs");

                    try
                    {
                        ////For DMG.WebAPI Current Directory location
                        string logsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                        if (!Directory.Exists(logsDirectory))
                        {
                            Directory.CreateDirectory(logsDirectory);
                        }

                        string logFilePath = Path.Combine(logsDirectory, $"Exception Log-({DateTime.Now:dd-MM-yyyy}).txt");
                        File.AppendAllText(logFilePath, $"{Environment.NewLine}{Environment.NewLine}{jsonExceptionLog}");
                    }
                    catch
                    {
                    }

                }
            }
            catch (Exception)
            {
                // Handle the exception appropriately
                throw;
            }
        }

        public static void WriteLog(string path, Exception exception)
        {
            try
            {
                var log = new EventLog { Source = exception.Source + " : " + path };
                log.WriteEntry(exception.Message, EventLogEntryType.Error);
            }
            catch (Exception)
            {
                // Handle the exception appropriately
                throw;
            }
        }
        #endregion

    }
}
