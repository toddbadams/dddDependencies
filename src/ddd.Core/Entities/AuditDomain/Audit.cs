using System;
using System.ComponentModel.DataAnnotations;
using ddd.Core.Providers;

namespace ddd.Core.Entities
{
    public class Audit
    {
        /// <summary>
        /// Database generated identifier 
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// The user making the change (aka the action)
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the entity that is changing (aka the action)
        /// </summary>
        [Required]
        public object EntityId { get; set; }

        /// <summary>
        /// A unix timestamp capturing the date/time of the action
        /// </summary>
        [Required]
        public long Timestamp { get; set; }

        /// <summary>
        /// The type of action 
        /// </summary>
        [Required]
        public AuditActionType Action { get; set; }

        /// <summary>
        /// A serialized representation of the entity at the time of the change.
        /// </summary>
        public string SerializedEntity { get; set; }


        /// <summary>
        /// Create an Audit entity to store the current state of this entity
        /// This happens during a change (aka action)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="user">the user requesting the action</param>
        /// <param name="timestamp">date/time of action</param>
        /// <param name="action">the type of action</param>
        /// <param name="serializationProvider"></param>
        /// <returns>an Audit entity</returns>
        public static Audit Create<T>(T entity, IUser user, long timestamp, AuditActionType action, ISerializationProvider serializationProvider)
            where T : Entity
        {
            string s;
            try
            {
                s = serializationProvider.Serialize(entity);
            }
            catch (Exception)
            {
                s = string.Empty;
            }
            return new Audit
            {
                UserId = user.Id,
                EntityId = entity.Id,
                Action = action,
                Timestamp = timestamp,
                SerializedEntity = s
            };
        }
    }
}