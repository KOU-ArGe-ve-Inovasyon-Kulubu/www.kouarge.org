using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minute,List<string> roles);

    }
}
