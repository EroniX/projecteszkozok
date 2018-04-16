using System;

namespace EroniX.Core.Audit
{
    internal class LoggerCallSite
    {
        internal string ClassName { get; }
        internal string MethodName { get; }

        internal LoggerCallSite(string className, string methodName)
        {
            ClassName = className;
            MethodName = methodName;
        }
    }
}
