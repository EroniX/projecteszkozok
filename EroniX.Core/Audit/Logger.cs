using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace EroniX.Core.Audit
{
    public abstract class Logger : ILogger
    {
        protected readonly IAppContextProvider ContextProvider;
        private static readonly string CurrentAssemblyCodeBase;

        static Logger()
        {
            CurrentAssemblyCodeBase = typeof(Logger).Assembly.CodeBase;
        }

        protected Logger(IAppContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

        public abstract void LogBusinessEvent(bool success, int code, string msg, object contextObject, IDictionary<string, object> parameters, LogLevel logLevel);

        public abstract void LogTraceEvent(TraceType traceType, string message, Exception exception, LogLevel logLevel);

        internal LoggerCallSite GetCallingMethod(StackTrace stackTrace)
        {
            MethodBase method = null;
            for(int frm = 0;frm < stackTrace.FrameCount;frm++)
            {
                var stackFrame = stackTrace.GetFrame(frm);
                method = stackFrame.GetMethod();

                if (method?.ReflectedType?.Assembly?.CodeBase != CurrentAssemblyCodeBase)
                    break;
            }

            return method != null 
                ? new LoggerCallSite(method?.ReflectedType?.FullName, method.Name) 
                : new LoggerCallSite("_UnresolvedClassName_", "_UnresolvedMethodName_");
        }

        protected string ToXml(object input)
        {
            if (input == null)
                return null;

            var ret = new XElement("Details");

            var type = input.GetType();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (!IsSimpleType(prop.PropertyType))
                    continue;

                var value = prop.GetValue(input, null);
                ret.Add(new XElement(prop.Name, value));
            }

            return ret.ToString();
        }

        private static readonly Type[] SimpleTypes = 
        {
            typeof(string),
            typeof(DateTime),
            typeof(Enum),
            typeof(decimal),
            typeof(Guid),
        };

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || SimpleTypes.Contains(type);
        }
    }
}
