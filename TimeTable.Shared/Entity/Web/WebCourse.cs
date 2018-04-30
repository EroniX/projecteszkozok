///Fájl neve: WebCourse.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Web
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using TimeTableDesigner.Shared.Entity.Domain;
    using TimeTableDesigner.Shared.Enum;
    using TimeTableDesigner.Shared.Helper.Utility;

    /// <summary>
    /// A WebCourse osztály
    /// </summary>
    public class WebCourse : IWebEntity
    {
        /// <summary>
        /// A "Name" adattag (GETTER, SETTER)
        /// A kurzus nevét tárolja
        /// </summary>
        [DisplayName("Kurzusnév")]
        public string Name { get; set; }

        /// <summary>
        /// Az "Id" adattag (GETTER, SETTER)
        /// A kurzuskódot tárolja
        /// </summary>
        [DisplayName("Kurzuskód")]
        public string Id { get; set; }

        /// <summary>
        /// A "Time" adattag (GETTER, SETTER)
        /// Az időpontot tárolja
        /// </summary>
        [DisplayName("Időpont")]
        public CourseTime Time { get; set; }

        /// <summary>
        /// A "Room" adattag (GETTER, SETTER)
        /// A helyszínt tárolja
        /// </summary>
        [DisplayName("Helyszín")]
        public string Room { get; set; }

        /// <summary>
        /// A "Weeks" adattag (GETTER, SETTER)
        /// A heteket tárolja
        /// </summary>
        [DisplayName("Hetek")]
        public IEnumerable<int> Weeks { get; set; }

        /// <summary>
        /// A "Description" adattag (GETTER, SETTER)
        /// A megjegyzést tárolja
        /// </summary>
        [DisplayName("Megjegyzés")]
        public string Description { get; set; }

        /// <summary>
        /// A "Type" adattag (GETTER, SETTER)
        /// Az óratípust tárolja
        /// </summary>
        [DisplayName("Óratípus")]
        public CourseType Type { get; set; }

        /// <summary>
        /// A "Group" adattag (GETTER, SETTER)
        /// A csoportot tárolja
        /// </summary>
        [DisplayName("Csoport")]
        public int Group { get; set; }

        /// <summary>
        /// A "HeadCount" adattag (GETTER, SETTER)
        /// A létszámot tárolja
        /// </summary>
        [DisplayName("Létszám")]
        public int HeadCount { get; set; }

        /// <summary>
        /// A "Number" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Ea, Gyak")]
        public int Number { get; set; }

        /// <summary>
        /// A "Teachers" adattag (GETTER, SETTER)
        /// Az oktatót/oktatókat tárolja
        /// </summary>
        [DisplayName("Oktató(k)")]
        public IEnumerable<string> Teachers { get; set; }

        /// <summary>
        /// A függvény, ami létrehoz egy WebCourse objektumot
        /// </summary>
        /// <param name="values">Az értékek</param>
        /// <returns>Az inicializált WebCourse objektum</returns>
        public static WebCourse Create(string[] values)
        {
            var course = new WebCourse();
            course.Initialize(values);
            return course;
        }

        /// <summary>
        /// Az objektum inicializálásáért felelős metódus
        /// </summary>
        /// <param name="values">Az értékek</param>
        public void Initialize(string[] values)
        {
            Name = values[0];
            Id = values[1];
            Time = CourseTime.ToCourseTime(values[2]);
            Room = values[3];
            Weeks = string.IsNullOrEmpty(values[4])
                ? Enumerable.Empty<int>()
                : values[4].Split(',').Select(int.Parse);
            Description = values[5];
            Type = EnumUtility.GetValueFromDescription<CourseType>(values[6]);
            Group = int.Parse(values[7]);
            HeadCount = int.Parse(values[8]);
            Number = int.Parse(values[9]) + int.Parse(values[10]);
            Teachers = values[11].Split(',');
        }
    }
}
