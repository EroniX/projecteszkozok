///Fájl neve: TimeTableAppContextProvider.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web
{
    using TimeTableDesigner.Shared.Access;

    /// <summary>
    /// A TimeTableAppContextProvider osztály
    /// </summary>
    public class TimeTableAppContextProvider : ITimeTableAppContextProvider
    {
        /// <summary>
        /// Az "UserName" adattag (GETTER, SETTER)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// A "RequestCorrelationToken" adattag (GETTER, SETTER)
        /// </summary>
        public string RequestCorrelationToken { get; set; }
    }
}
