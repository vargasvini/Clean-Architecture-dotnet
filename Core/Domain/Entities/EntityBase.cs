using System;

namespace CleanArchitecture.Core.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            CreatedBy = "Vini";
            ModifiedBy = "Vini";
        }

        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime ModifiedAt { get; protected set; }
        public string CreatedBy { get; protected set; }
        public string ModifiedBy { get; protected set; }
    }
}
