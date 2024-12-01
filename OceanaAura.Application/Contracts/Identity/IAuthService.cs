using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Contracts.Identity
{
    public interface IAuthService
    {

        Task Logout();
    }
}
