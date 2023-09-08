using JwtExample.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Business.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

      /*  public Dictionary<string, string> GetService()
        {
            return _context.Settings.ToList().ToDictionary(x => x.Key, x => x.Value);
        }*/
    }
}
