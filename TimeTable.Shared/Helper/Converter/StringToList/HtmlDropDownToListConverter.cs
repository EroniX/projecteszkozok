using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EroniX.Core.Audit;
using HtmlAgilityPack;
using TimeTableDesigner.Shared.Entity.Web;

namespace TimeTableDesigner.Shared.Helper.Converter.StringToList
{
    public class HtmlDropDownToListConverter : IStringToListConverter
    {
        private readonly ILogger _logger;

        public HtmlDropDownToListConverter(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<T> Convert<T>(string source)
            where T : class, IWebEntity, new()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(source);

            var childNodes = htmlDocument.DocumentNode.ChildNodes;

            for (var i = 2; i < childNodes.Count; i += 2)
            {
                var model = new T();
                try
                {
                    model.Initialize(new[]
                    {
                        childNodes[i - 1].OuterHtml.Split('\"')[1],
                        childNodes[i].OuterHtml
                    });
                }
                catch (Exception e)
                {
                    _logger.LogTraceEvent(
                        TraceType.Exception,
                        e.Message,
                        e,
                        LogLevel.Warning);

                    continue;
                }

                yield return model;
            }
        }
    }
}