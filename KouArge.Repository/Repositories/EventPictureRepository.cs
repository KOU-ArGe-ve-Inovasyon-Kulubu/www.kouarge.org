using KouArge.Core.Models;
using KouArge.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class EventPictureRepository : GenericRepository<EventPicture>, IEventPictureRepository
    {
        public EventPictureRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
