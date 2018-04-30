///Fájl neve: EnumUtility.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Helper.Utility
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Az EnumUtility statikus osztály
    /// </summary>
    public static class EnumUtility
    {
        /// <summary>
        /// Leírás lekérdezése egy enum értékből
        /// </summary>
        /// <param name="value">Az enum érték</param>
        /// <returns>A leírás ha létezik, null egyébként</returns>
        public static string GetDescriptionFromEnumValue(System.Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Érték lekérdezése egy leírás alapján
        /// </summary>
        /// <typeparam name="T">A típus (enum)</typeparam>
        /// <param name="description">A leírás</param>
        /// <returns>A mező, ha létezik ilyen leírással rendelkező</returns>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
