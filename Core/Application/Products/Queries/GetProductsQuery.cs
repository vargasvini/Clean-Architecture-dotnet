﻿using CleanArchitecture.Core.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
