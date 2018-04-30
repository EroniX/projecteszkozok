///Fájl neve: HtmlDropDownToListConverter.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Helper.Converter.StringToList
{
    using EroniX.Core.Audit;
    using System;
    using System.Collections.Generic;
    using TimeTableDesigner.Shared.Entity.Web;

    /// <summary>
    /// A HtmlDropDownToListConverter osztály
    /// </summary>
    public class HtmlDropDownToListConverter : IStringToListConverter
    {
        /// <summary>
        /// Az ILogger privát adattag
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// A konstruktor ami létrehoz egy HtmlDropDownToListConverter objektumot
        /// </summary>
        /// <param name="logger">A logger</param>
        public HtmlDropDownToListConverter(ILogger logger)
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
