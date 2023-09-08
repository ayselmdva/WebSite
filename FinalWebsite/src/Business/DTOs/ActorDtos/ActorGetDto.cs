using FinalWebsite.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Business.DTOs.ActorDtos
{
    public class ActorGetDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Image { get; set; } = null!;
        public List<Movie> Movies { get; set; }
    }
}
