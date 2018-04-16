using System.ComponentModel;

namespace TimeTableDesigner.Shared.Enum
{
    public enum Limit
    {
        [Description("50")]
        Fifty = 50,
        [Description("100")]
        Hundred = 100,
        [Description("Összes")]
        All = 1000
    }
}
