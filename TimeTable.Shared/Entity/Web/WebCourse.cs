using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TimeTableDesigner.Shared.Entity.Domain;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Utility;

namespace TimeTableDesigner.Shared.Entity.Web
{
    public class WebCourse : IWebEntity
    {
        /// <summary>
        /// Kurzusnev
        /// </summary>
        [DisplayName("Kurzusnév")]
        public string Name { get; set; }

        /// <summary>
        /// Kurzuskod
        /// </summary>
        [DisplayName("Kurzuskód")]
        public string Id { get; set; }

        /// <summary>
        /// Idopont
        /// </summary>
        [DisplayName("Időpont")]
        public CourseTime Time { get; set; }

        /// <summary>
        /// Helyszin
        /// </summary>
        [DisplayName("Helyszín")]
        public string Room { get; set; }

        /// <summary>
        /// Hetek
        /// </summary>
        [DisplayName("Hetek")]
        public IEnumerable<int> Weeks { get; set; }

        /// <summary>
        /// Megj.
        /// </summary>
        [DisplayName("Megjegyzés")]
        public string Description { get; set; }

        /// <summary>
        /// Oratipus
        /// </summary>
        [DisplayName("Óratípus")]
        public CourseType Type { get; set; }

        /// <summary>
        /// Csop.
        /// </summary>
        [DisplayName("Csoport")]
        public int Group { get; set; }

        /// <summary>
        /// Letszam
        /// </summary>
        [DisplayName("Létszám")]
        public int HeadCount { get; set; }

        /// <summary>
        /// Ea, Gyak
        /// </summary>
        [DisplayName("Ea, Gyak")]
        public int Number { get; set; }

        /// <summary>
        /// Oktato
        /// </summary>
        [DisplayName("Oktató(k)")]
        public IEnumerable<string> Teachers { get; set; }

        public static WebCourse Create(string[] values)
        {
            var course = new WebCourse();
            course.Initialize(values);
            return course;
        }

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
