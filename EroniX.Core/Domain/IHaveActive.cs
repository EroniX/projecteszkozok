namespace EroniX.Core.Domain
{
    public interface IHaveActive : IEntity
    {
        bool Active { get; set; }
    }
}
