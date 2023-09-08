using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.DataAccess.Repositories.Concrete
{
    public class OderDetailtRepository : Repository<OderDetail>, IOderDetailtRepository
    {
        public OderDetailtRepository(AppDbContext context) : base(context)
        {
        }
    }
}
