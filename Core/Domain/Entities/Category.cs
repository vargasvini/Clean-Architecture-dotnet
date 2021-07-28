using CleanArchitecture.Core.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            if (!ValidateDomain(id, name))
            {
                Id = id;
                Name = name;
            }
     
        }

        public Category(string name)
        {
            if (!ValidateDomain(Id = 0, name))
            {
                Name = name;
            }
        }

        public void Update(string name)
        {
            if (!ValidateDomain(Id = 0, name))
            {
                Name = name;
            }
        }

        private bool ValidateDomain(int? id, string name)
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid Id: Value cannot be null or less than zero!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid Name: Property name is required!");
            DomainExceptionValidation.When(name.Length < 3, 
                "Invalid Name: Too short, name must have 3 characters minimum!");

            return false;
        }
    }
}
