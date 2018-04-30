///Fájl neve: RemoveLoginViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.ManageViewModels
{
    /// <summary>
    /// A RemoveLoginViewModel osztály
    /// </summary>
    public class RemoveLoginViewModel
    {
        /// <summary>
        /// A "LoginProvider" adattag (GETTER, SETTER)
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// A "ProviderKey" adattag (GETTER, SETTER)
        /// </summary>
        public string ProviderKey { get; set; }
    }
}
