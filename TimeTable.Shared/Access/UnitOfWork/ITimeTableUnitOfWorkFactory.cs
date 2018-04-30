///Fájl neve: ITimeTableUnitOfWorkFactory.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.UnitOfWork
{
    using EroniX.Core.DataAccess;

    /// <summary>
    /// Az ITimeTableUnitOfWorkFactory interfész
    /// </summary>
    public interface ITimeTableUnitOfWorkFactory : IUnitOfWorkFactory<ITimeTableUnitOfWork>
    {
    }
}
