using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Repositories
{
    public interface ITitleRepository:IGenericRepository<Title>
    {
        Task<bool> DuplicateDataAsync(string titleName);
    }
}
