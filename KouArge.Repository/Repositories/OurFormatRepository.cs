using KouArge.Core.Models;
using KouArge.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class OurFormatRepository : GenericRepository<OurFormat>, IOurFormatRepository
    {
        public OurFormatRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
