// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NLog.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Vishal Garg"/>
// --------------------------------------------------------------------------------------------------------------------

namespace EmployeePayrollSystemThreading
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using global::NLog;

    /// <summary>
    /// NLog class to make a Log file
    /// </summary>
    public class NLog
    {
        /// <summary>
        /// Logger is a class name inside NLog
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// log debug message
        /// </summary>
        /// <param name="message">message to be printed in NLog file</param>
        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        /// <summary>
        /// log error message
        /// </summary>
        /// <param name="message"> message to be printed in NLog file</param>
        public void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <summary>
        /// log info message
        /// </summary>
        /// <param name="message">message to be printed in NLog file</param>
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// log warning message
        /// </summary>
        /// <param name="message"> message to be printed in NLog file</param>
        public void LogWarn(string message)
        {
            Logger.Warn(message);
        }
    }
}
