using System.ComponentModel.DataAnnotations;

namespace ddd.Core.Entities
{
    /// <summary>
    /// Entities have 
    ///     Identity - to implement this we are using a object in the base entity. 
    ///                Additionally we have added and equality check.
    ///     Soft Delete - an entity is not removed from the datastore, 
    ///                   simply marked as deleted.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Database generated identifier 
        /// </summary>
        [Required]
        public virtual object Id { get; set; }

        /// <summary>
        /// IsDeleted is true when the entity has been deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        #region Equality Checks
        public override bool Equals(object entity)
        {
            if (!(entity is Entity))
            {
                return false;
            }

            return (this == (Entity)entity);
        }

        public static bool operator ==(Entity e1, Entity e2)
        {
            if ((object)e1 == null && (object)e2 == null)
            {
                return true;
            }

            if ((object)e1 == null || (object)e2 == null)
            {
                return false;
            }

            return e1.Id == e2.Id;
        }

        public static bool operator !=(Entity e1, Entity e2)
        {
            return (!(e1 == e2));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}