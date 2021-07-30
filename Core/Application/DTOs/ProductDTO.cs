using CleanArchitecture.Core.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Core.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
