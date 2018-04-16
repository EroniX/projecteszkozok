using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTableDesigner.Web.Helpers
{
    public static class DropDownListHelper
    {
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
