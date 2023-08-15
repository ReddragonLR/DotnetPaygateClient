/*
 * Reference: https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
 */

namespace Paygate.Client.Helpers
{
    internal static class ChecksumHelper
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
