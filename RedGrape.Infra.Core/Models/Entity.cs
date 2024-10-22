namespace RedGrape.Infra.Core.Models
{
    public class Entity<TEntity, TKeyType> : IEntity<TEntity>
        where TEntity : Entity<TEntity, TKeyType>
        where TKeyType : Id
    {
        public TKeyType Id { get; }
        protected Entity(TKeyType id)
        {
            Id = id;
        }

        #region Equality
        public static bool operator ==(Entity<TEntity, TKeyType> left, Entity<TEntity, TKeyType> right)
        {
            return left?.Id == right?.Id;
        }

        public static bool operator !=(Entity<TEntity, TKeyType> left, Entity<TEntity, TKeyType> right)
        {
            return !(left == right);
        }

        public bool Equals(Entity<TEntity, TKeyType> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Entity<TEntity, TKeyType>;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        #endregion
    }

    public class Entity<T> where T : Entity<T>
    {

        public Id<T> Id { get; }

        protected Entity(Id<T> id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Entity must have an id.");
        }

        #region Equality

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            return left?.Id == right?.Id;
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }

        public bool Equals(Entity<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Entity<T>;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        #endregion
    }
}
