namespace Common.Entities
{
    /// <summary>
    /// Базовый класс сущностей
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseEntity<TKey>
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public TKey Id { get; set; }
    }
}
