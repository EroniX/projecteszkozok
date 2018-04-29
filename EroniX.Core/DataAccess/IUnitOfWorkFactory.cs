namespace EroniX.Core.DataAccess
{
    public interface IUnitOfWorkFactory<out TUoW> 
        where TUoW: IUnitOfWork
    {
        TUoW Create();

        TUoW CreateTransactional();
    }
}
