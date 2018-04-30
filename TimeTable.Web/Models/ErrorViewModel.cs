///Fájl neve: ErrorViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models
{
    /// <summary>
    /// Az ErrorViewModel osztály
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Az "RequestId" adattag (GETTER, SETTER)
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// A kérés azonosító megjelenítéséért felelõs függvény
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
