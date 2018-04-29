namespace EroniX.Core.Domain
{
    public abstract class EntityWithStringId : IEntityWithStringId
    {
        public string Id { get; set; }
    }
}
