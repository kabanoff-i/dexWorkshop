namespace Application.Interfaces;

public interface IRepository<TEntity>
{
    public TEntity GetById(Guid id);
    
    public TEntity Get();
    
    public TEntity Update(TEntity person);
    public TEntity Create(TEntity person);
    
    public TEntity Delete(Guid id);
}