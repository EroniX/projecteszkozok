///Fájl neve: ITimeTableUnitOfWork.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.UnitOfWork
{
    using EroniX.Core.DataAccess;
    using System.Runtime.Remoting.Contexts;
    using TimeTableDesigner.Shared.Access.Repository;

    /// <summary>
    /// Az ITimeTableUnitOfWork interfész
    /// </summary>
    public interface ITimeTableUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// A "UserRepository" adattag (GETTER)
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// A "TimeTableRepository" adattag (GETTER)
        /// </summary>
        ITimeTableRepository TimeTableRepository { get; }

        /// <summary>
        /// A "CourseRepository" adattag (GETTER)
        /// </summary>
        ICourseRepository CourseRepository { get; }
    }
}
