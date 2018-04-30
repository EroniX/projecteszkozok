///Fájl neve: HtmlTableToListConverter.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Helper.Converter.StringToList
{
    using EroniX.Core.Audit;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TimeTableDesigner.Shared.Entity.Web;

    /// <summary>
    /// A HtmlTableToListConverter osztály
    /// </summary>
    public class HtmlTableToListConverter : IStringToListConverter
    {
        /// <summary>
        /// Az ILogger privát adattag
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// A konstruktor ami létrehoz egy HtmlTableToListConverter objektumot
        /// </summary>
        /// <param name="logger">A logger</param>
        public HtmlTableToListConverter(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// A konvertálást végző függvény
        /// </summary>
        /// <typeparam name="T">Tetszőleges osztály</typeparam>
        /// <param name="source">A szöveg</param>
        /// <returns>A lista</returns>
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
