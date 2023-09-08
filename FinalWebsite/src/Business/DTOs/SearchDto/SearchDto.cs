using FinalWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Business.DTOs.SearchDto
{
	public class SearchDto
	{
		public List<Movie>? Movies { get; set; }
		public List<Genre>? Genres { get; set; }
		public string? Name { get; set; }
		public int? GenreId { get; set; }
		public Movie? Movie { get; set; }
	}
}
