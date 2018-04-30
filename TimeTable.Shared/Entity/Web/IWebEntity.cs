///Fájl neve: IWebEntity.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Web
{
    /// <summary>
    /// Az IWebEntity intefész
    /// </summary>
    public interface IWebEntity
    {
        /// <summary>
        /// Az inicializálásért felelős függvény
        /// </summary>
        /// <param name="values">Az értékek</param>
        void Initialize(string[] values);
    }
}
