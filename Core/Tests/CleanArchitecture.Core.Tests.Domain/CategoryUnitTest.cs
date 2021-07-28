using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Core.Tests.Domain
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create a Valid Category")]
        public void InsertCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "CategoryName");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Invalid Category with negative ID")]
        public void InsertCategory_WithNegativeIdValue_ResultDomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "CategoryName");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id: Value cannot be null or less than zero!");
        }

        [Fact(DisplayName = "Invalid Category with too short name")]
        public void InsertCategory_WithEmptyName_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name: Property name is required!");
        }

        [Fact(DisplayName = "Invalid Category with empty name")]
        public void InsertCategory_WithTooShortName_ResultDomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name: Too short, name must have 3 characters minimum!");
        }
    }
}
