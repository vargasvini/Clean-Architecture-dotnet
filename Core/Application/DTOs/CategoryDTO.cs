using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Core.Application.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
