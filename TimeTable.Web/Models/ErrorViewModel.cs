///F�jl neve: ErrorViewModel.cs
///D�tum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models
{
    /// <summary>
    /// Az ErrorViewModel oszt�ly
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Az "RequestId" adattag (GETTER, SETTER)
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// A k�r�s azonos�t� megjelen�t�s��rt felel�s f�ggv�ny
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
