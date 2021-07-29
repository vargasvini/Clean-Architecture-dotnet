using CleanArchitecture.Core.Domain.Validation;

namespace CleanArchitecture.Core.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            if(!ValidateDomain(Id = 0, name, description, price, stock, image))
            {
                Name = name;
                Description = description;
                Price = price;
                Stock = stock;
                Image = image;
            }
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            if(!ValidateDomain(Id = id, name, description, price, stock, image))
            {
                Id = id;
                Name = name;
                Description = description;
                Price = price;
                Stock = stock;
                Image = image;
            }
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            if (!ValidateDomain(Id = 0, name, description, price, stock, image))
            {
                Name = name;
                Description = description;
                Price = price;
                Stock = stock;
                Image = image;
                CategoryId = categoryId;
            }
        }

        private bool ValidateDomain(int? id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid Id: Value cannot be null or less than zero!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name: Property name is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name: Too short, name must have 3 characters minimum!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid Description: Property description is required!");
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid Description: Too short, description must have 5 characters minimum!");
            DomainExceptionValidation.When(price < 0,
                "Invalid Price: Value cannot be less than zero!");
            DomainExceptionValidation.When(stock < 0,
                "Invalid Stock: Value cannot be less than zero!");
            DomainExceptionValidation.When(image?.Length > 255,
                "Invalid Image: Too long, image name can be a maximum of 255 characters!");
            return false;
        }
    }
}
