using System;

namespace CleanArchitecture.Core.Application.DTOs
{
    public class BaseDTO
    {
        public BaseDTO()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            CreatedBy = "Vini";
            ModifiedBy = "Vini";
        }
        public DateTime CreatedAt { get; protected set; }
        public DateTime ModifiedAt { get; protected set; }
        public string CreatedBy { get; protected set; }
        public string ModifiedBy { get; protected set; }
    }
}
