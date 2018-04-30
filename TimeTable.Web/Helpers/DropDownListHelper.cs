///Fájl neve: DropDownListHelper.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A DropDownListHelper osztály
    /// </summary>
    public static class DropDownListHelper
    {
        /// <summary>
        /// A konvertálást végző függvény
        /// </summary>
        /// <typeparam name="T">A típus/osztály</typeparam>
        /// <param name="list">A lista</param>
        /// <param name="value">Az érték</param>
        /// <param name="text">A szöveg</param>
        /// <returns>A SelectListItem objektumokat tartalmazó lista</returns>
        public static IEnumerable<SelectListItem> Convert<T>(IEnumerable<T> list, Func<T, string> value,
            Func<T, string> text)
        {
            return list.Select(element => new SelectListItem
            {
                Value = value(element),
                Text = text(element)
            });
        }
    }
}
