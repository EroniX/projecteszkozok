using System;
using System.Collections.Generic;
using System.Linq;
using EroniX.Core.Audit;
using HtmlAgilityPack;
using TimeTableDesigner.Shared.Entity.Web;

namespace TimeTableDesigner.Shared.Helper.Converter.StringToList
{
    public class HtmlTableToListConverter : IStringToListConverter
    {
        private readonly ILogger _logger;

        public HtmlTableToListConverter(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<T> Convert<T>(string source)
            where T : class, IWebEntity, new()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(source);

            foreach (var row in htmlDocument.DocumentNode.FirstChild.ChildNodes.Skip(1))
            {
                var model = new T();
                try
                {
                    model.Initialize(
                        row.ChildNodes.Select(column => column.InnerHtml).ToArray());
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
