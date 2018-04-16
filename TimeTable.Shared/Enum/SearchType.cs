using System.ComponentModel;

namespace TimeTableDesigner.Shared.Enum
{
    public enum SearchType
    {
        [Description("Név")]
        Name = 0,
        [Description("Azonosító")]
        Id = 1,
        [Description("Tanár")]
        Teacher = 2,
        [Description("Szakirány")]
        Department = 3
    }
}
