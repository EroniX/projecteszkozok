using System.ComponentModel;

namespace TimeTableDesigner.Shared.Enum
{
    public enum CourseDay
    {
        [Description("Hétfo")]
        Monday = 0,
        [Description("Kedd")]
        Tuesday = 1,
        [Description("Szerda")]
        Wednesday = 2,
        [Description("Csütörtök")]
        Thursday = 3,
        [Description("Péntek")]
        Friday = 4, 
        [Description("Szombat")]
        Saturday = 5,
        [Description("Vasárnap")]
        Sunday = 6
    }
}
