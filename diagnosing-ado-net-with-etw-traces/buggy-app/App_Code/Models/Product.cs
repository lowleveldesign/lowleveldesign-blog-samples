using System;
using System.ComponentModel.DataAnnotations;

namespace LowLevelDesign.DiagnosingAdoNet
{
    public sealed class Product 
    {
        [Required]
        public String ProductKey { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}