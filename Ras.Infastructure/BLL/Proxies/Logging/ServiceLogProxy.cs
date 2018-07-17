using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    /// <summary>
    ///     Base for logging proxies. Contains logger and real service. Provides LogBegin and LogEnd methods.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public abstract class ServiceLogProxy<TService>
    {
        protected readonly ILogger logger;
        protected readonly TService service;

        protected string serviceName;

        /// <summary>
        /// </summary>
        /// <param name="service">Another service, methods of that will be wraped with logging.</param>
        /// <param name="logger">Logger will be used to log.</param>
        public ServiceLogProxy(TService service, ILogger logger)
        {
            if (service is ServiceLogProxy<TService>)
            {
                throw new ArgumentException();
            }

            this.service = service;
            this.logger = logger;
            serviceName = GetType().Name.Replace("LogProxy", "");
        }

        /// <summary>
        ///     Writes message to log with name of service, name of method, arguments in format {parameterName} = {argumentValue}.
        ///     Adds to log message "Begin".
        /// </summary>
        /// <param name="arguments">Array with given argument to method. Must contain all arguments given to method.</param>
        /// <param name="methodName">Method namme will be getted in compile time. It should not be specified in method call. </param>
        protected void LogBegin(object[] arguments = null, [CallerMemberName] string methodName = null)
        {
            string args = BuildArgs(arguments);
            logger.LogTrace($"{serviceName}.{methodName}({args}) Begin ");
        }

        /// <summary>
        ///     Writes message to log with name of service, name of method, arguments in format {parameterName} = {argumentValue}.
        ///     Adds to log message "End".
        /// </summary>
        /// <param name="arguments">Array with given argument to method. Must contain all arguments given to method.</param>
        /// <param name="methodName">Method namme will be getted in compile time. It should not be specified in method call. </param>
        protected void LogEnd(object[] arguments = null, [CallerMemberName] string methodName = null)
        {
            string args = BuildArgs(arguments);
            logger.LogTrace($"{serviceName}.{methodName}({args}) End");
        }

        /// <summary>
        ///     Returns string in format {parameterName} = {argumentValue}. Gets parameters names by getting stack frame.
        /// </summary>
        /// <param name="args">Arguments values.</param>
        /// <returns></returns>
        private string BuildArgs(params object[] args)
        {
            if (args == null)
            {
                return string.Empty;
            }

            var parametersNames = new StackFrame(2).GetMethod().GetParameters().Select(p => p.Name).ToList();

            if (args.Length != parametersNames.Count)
            {
                throw new ArgumentException("Length of args does not match original parameters count");
            }

            var arguments = new List<Argument>(args.Length);

            // fill arguments with data from parametersNames and args
            for (int i = 0; i < args.Length; i++)
            {
                string stringValue;
                if (args[i] != null)
                {
                    stringValue = args[i].ToString();
                }
                else
                {
                    stringValue = "null";
                }

                arguments.Add(new Argument(parametersNames[i], stringValue));
            }

            var sb = new StringBuilder();
            foreach (var item in arguments)
            {
                sb.Append($"{item.Name} = {item.Value}");
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Represents name of method parameter and given value.
        /// </summary>
        public struct Argument
        {
            /// <summary>
            ///     Parameter name.
            /// </summary>
            public string Name;

            /// <summary>
            ///     Argument value.
            /// </summary>
            public string Value;

            public Argument(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}