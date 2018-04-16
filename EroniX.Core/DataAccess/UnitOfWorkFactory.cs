namespace EroniX.Core.DataAccess
{
    public abstract class UnitOfWorkFactory<TUoW, TUoWc> : IUnitOfWorkFactory<TUoW>
        where TUoW : IUnitOfWork
        where TUoWc: BaseUnitOfWork, TUoW, new()
    {
        private readonly string _connectionString;

        protected UnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TUoW Create()
        {
            var uow = new TUoWc();
            uow.Setup(_connectionString);
            return uow;
        }

        public TUoW CreateTransactional()
        {
            var uow = Create();

            uow.BeginTransaction();

            return uow;
        }
    }
}
