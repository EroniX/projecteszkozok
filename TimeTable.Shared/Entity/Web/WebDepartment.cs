﻿///Fájl neve: WebDepartment.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Web
{
    /// <summary>
    /// A WebDepartment osztály
    /// </summary>
    public class WebDepartment : IWebEntity
    {
        /// <summary>
        /// Az "Id" adattag (GETTER, SETTER)
        /// Az azonosítót tárolja
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A "name" adattag (GETTER, SETTER)
        /// A nevet tárolja
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Az objektum inicializálásáért felelős metódus
        /// </summary>
        /// <param name="values">Az értékek</param>
        public void Initialize(string[] values)
        {
            Id = values[0].Trim();
            Name = values[1].Trim();
        }
    }
}
