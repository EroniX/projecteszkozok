using System.ComponentModel;

namespace TimeTableDesigner.Shared.Enum
{
    public enum CourseDay
    {
        [Description("Hétfo")]
        Monday,
        [Description("Kedd")]
        Tuesday,
        [Description("Szerda")]
        Wednesday,
        [Description("Csütörtök")]
        Thursday,
        [Description("Péntek")]
        Friday, 
        [Description("Szombat")]
        Saturday,
        [Description("Vasárnap")]
        Sunday
    }
}
