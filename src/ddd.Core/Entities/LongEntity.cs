using System.ComponentModel.DataAnnotations;

namespace ddd.Core.Entities
{
    public abstract class LongEntity : Entity
    {
        /// <summary>
        /// Database generated identifier 
        /// </summary>
        [Required]
        public new long Id
        {
            get { return (long) base.Id; }
            set { base.Id = value; }
        }
    }
}