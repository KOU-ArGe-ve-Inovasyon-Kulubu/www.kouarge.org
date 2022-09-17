using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IRedirectService
    {
        public Task<string> AddAsync(string id);
    }
}
