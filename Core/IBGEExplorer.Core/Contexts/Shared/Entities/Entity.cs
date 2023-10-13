namespace IBGEExplorer.Core.Contexts.Shared.Entities;

public abstract class Entity<T> where T : new()
{
    public T Id { get; set; }

    protected Entity() => Id = new T();
    protected Entity(T id) => Id = id;
}

public abstract class Entity : Entity<Guid>
{
    protected Entity() => Id = Guid.NewGuid();
}