using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Utils
{
    public static class Helper
    {
        public static byte[] CalculateHash(string input)
        {
            //Convert the input to a byte array using specified encoding
            var InputBuffer = Encoding.Unicode.GetBytes(input);
            //Hash the input
            byte[] HashedBytes = new byte[500];
            using (var Hasher = new SHA256Managed())
            {
                HashedBytes = Hasher.ComputeHash(InputBuffer);
            }

            return HashedBytes;
        }
    }
}
