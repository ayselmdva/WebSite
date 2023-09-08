using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.DataAccess.Repositories.Concrete
{
	public class ShoppingRepository:Repository<ShoppingCart>,IShoppingRepository
	{
		private readonly AppDbContext _context;

		public ShoppingRepository(AppDbContext context):base(context) 
		{
			_context = context;
		}
	}
}
