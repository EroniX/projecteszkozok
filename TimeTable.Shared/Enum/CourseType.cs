using System.ComponentModel;

namespace TimeTableDesigner.Shared.Enum
{
    public enum CourseType
    {
        [Description("elõadás")]
        Lecture,
        [Description("gyakorlat")]
        Practise,
        [Description("virtuális")]
        Virtual,
        [Description("konzultáció")]
        Constultation,
        [Description("elfoglaltság")]
        Activity,
        [Description("szakdolgozat")]
        Thesis,
        [Description("teremfoglalás")]
        RoomReservation,
        [Description("otthoni munka")]
        HomeWork
    }
}
