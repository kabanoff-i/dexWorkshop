namespace Application.Interfaces;

public interface IRepository<TEntity>
{
    public TEntity? GetById(Guid id);
    
    public List<TEntity> GetAll();
    
    public TEntity Update(TEntity person);
    public TEntity Create(TEntity person);
    
    public bool Delete(Guid id);
}