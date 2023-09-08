using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.DataAccess.Repositories.Concrete
{
    public class OderHeaderRepository : Repository<OderHeader>, IOderHeaderRepository
    {
        public OderHeaderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
