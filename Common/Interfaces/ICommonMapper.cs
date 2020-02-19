namespace Common.Interfaces
{
    /// <summary>
    /// Маппер сущности в вью-модель и обратно
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public interface ICommonMapper<TEntity, TModel>
    {
        TModel MapEntityToModel(TEntity entity);
        TModel MapEntityToModel(TEntity entity, TModel model);
        TEntity MapModelToEntity(TModel model);
        TEntity MapModelToEntity(TModel model, TEntity entity);
    }
}
