using FinalWebsite.Business.DTOs.QualtyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Business.DTOs.MovieDtos
{
	public class MovieListDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Image { get; set; }
		public string Video { get; set; }
		public int? Year { get; set; }
		public double? Price { get; set; }
		public float Raiting { get; set; }
		public List<QualityListDto>? Qualities { get; set; }
		public string? Genre { get; set; }
		public int? GenreId { get; set; }
	}
}
