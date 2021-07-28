using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Core.Tests.Domain
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create a Valid Product")]
        public void InsertProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 20, "ImageUrl");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Invalid Product with negative ID")]
        public void InsertProduct_WithNegativeIdValue_ResultDomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id: Value cannot be null or less than zero!");
        }

        [Fact(DisplayName = "Invalid Product with empty name")]
        public void InsertProduct_WithEmptyName_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name: Property name is required!");
        }

        [Fact(DisplayName = "Invalid Product with too short name")]
        public void InsertProduct_WithTooShortName_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name: Too short, name must have 3 characters minimum!");
        }

        [Fact(DisplayName = "Invalid Product with empty description")]
        public void InsertProduct_WithEmptyDescription_ResultDomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description: Property description is required!");
        }

        [Fact(DisplayName = "Invalid Product with too short description")]
        public void InsertProduct_WithTooShortDescription_ResultDomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 9.99m, 20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description: Too short, description must have 5 characters minimum!");
        }

        [Fact(DisplayName = "Invalid Product with negative price")]
        public void InsertProduct_WithNegativePrice_ResultDomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -10.00m, 20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price: Value cannot be less than zero!");
        }

        [Fact(DisplayName = "Invalid Product with negative stock")]
        public void InsertProduct_WithNegativeStock_ResultDomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.00m, -20, "ImageUrl");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock: Value cannot be less than zero!");
        }
    }
}
