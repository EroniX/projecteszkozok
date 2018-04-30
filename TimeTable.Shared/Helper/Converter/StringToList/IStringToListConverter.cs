///Fájl neve: IStringToListConverter.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Helper.Converter.StringToList
{
    using System.Collections.Generic;
    using TimeTableDesigner.Shared.Entity.Web;

    /// <summary>
    /// IStringToListConverter interfész
    /// </summary>
    public interface IStringToListConverter
    {
        /// <summary>
        /// A konvertálást végző függvény
        /// </summary>
        /// <typeparam name="T">Tetszőleges osztály</typeparam>
        /// <param name="source">A szöveg</param>
        /// <returns>A lista</returns>
        IEnumerable<T> Convert<T>(string source)
            where T : class, IWebEntity, new();
    }
}
