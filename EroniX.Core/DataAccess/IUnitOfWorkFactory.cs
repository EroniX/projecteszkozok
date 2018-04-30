namespace EroniX.Core.DataAccess
{
    public interface IUnitOfWorkFactory<out UoW> 
        where UoW: IUnitOfWork
    {
        UoW Create();

        UoW CreateTransactional();
    }
}
