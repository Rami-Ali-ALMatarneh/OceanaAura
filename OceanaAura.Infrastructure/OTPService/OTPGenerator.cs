using OceanaAura.Application.Contracts.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Infrastructure.OTPService
{
    public class OTPGenerator : IOTPGenerator
    {
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public string GenerateOTP(int length = 10)
        {
            // Ensure a cryptographically secure random number generator
            using (var rng = RandomNumberGenerator.Create())
            {
                var otp = new StringBuilder();
                var data = new byte[4]; // 4 bytes for each random integer

                for (int i = 0; i < length; i++)
                {
                    // Fill the array with a random number
                    rng.GetBytes(data);

                    // Convert the 4 bytes into a uint and get the index of the character
                    uint randomValue = BitConverter.ToUInt32(data, 0);
                    var index = randomValue % Characters.Length;

                    otp.Append(Characters[(int)index]);
                }

                return otp.ToString();
            }
        }
    }
}
