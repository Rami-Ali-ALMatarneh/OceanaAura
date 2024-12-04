using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Contracts.OTP
{
    public interface IOTPGenerator
    {
        string GenerateOTP(int length = 10);
    }
}
