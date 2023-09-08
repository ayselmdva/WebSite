using FinalWebsite.Data.Entities.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Data.Entities
{
    public class ShoppingCart:BaseEntity
    {
        public int MovieId { get; set; }
        [ValidateNever]
        public Movie Movie { get; set; }
        [Range(1, 100, ErrorMessage ="Please enter a value between 1 and 100")]
        public int Count { get; set; }
        public string AppUserId { get; set; }
        [ValidateNever]
        public AppUser AppUser { get; set; }
        [NotMapped]
        public double Price { get; set; }

    }
}
