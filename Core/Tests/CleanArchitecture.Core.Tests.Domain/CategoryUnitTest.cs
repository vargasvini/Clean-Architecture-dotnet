using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Core.Tests.Domain
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName ="Create Valid Category")]
        public void InsertCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "CategoryName");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }
    }
}
