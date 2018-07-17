using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    public abstract class ServiceLogProxy<TService>
    {
        protected readonly ILogger logger;
        protected readonly TService service;

        protected string serviceName;

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

        protected void LogBegin(object[] arguments = null, [CallerMemberName] string methodName = null)
        {
            string args = BuildArgs(arguments);
            logger.LogTrace($"{serviceName}.{methodName}({args}) Begin ");
        }

        protected void LogEnd(object[] arguments = null, [CallerMemberName] string methodName = null)
        {
            string args = BuildArgs(arguments);
            logger.LogTrace($"{serviceName}.{methodName}({args}) End");
        }

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

            for (int i = 0; i < args.Length; i++)
            {
                arguments.Add(new Argument(parametersNames[i], args[i].ToString()));
            }

            var sb = new StringBuilder();
            foreach (var item in arguments)
            {
                sb.Append($"{item.Name} = {item.Value}");
            }

            return sb.ToString();
        }

        public struct Argument
        {
            public string Name;
            public string Value;

            public Argument(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}