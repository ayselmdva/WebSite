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
    public class OderDetail:BaseEntity
    {
        [Required]
        public int OderId { get; set; }
        [ForeignKey(nameof(OderId))]
        [ValidateNever]
        public OderHeader OderHeader { get; set; }
        [Required]
        public int MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        [ValidateNever]
        public Movie Movie { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
