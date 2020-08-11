using System;
using System.Security.Cryptography;
using System.Text;

namespace Min_Helpers.SecurityHelper
{
    /// <summary>
    /// HmacSha256
    /// </summary>
    public class HmacSha256
    {
        /// <summary>
        /// Key
        /// </summary>
        public static string Key { get; private set; } = "Pv0bRHSydU8nxVQNnlQf@2fT$wgpk%LBVX36RsSf5F6gHPc1%9";

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="key"></param>
        public void Initialize(string key)
        {
            try
            {
                Key = key;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Encode(string message)
        {
            try
            {
                byte[] keyByte = Encoding.UTF8.GetBytes(Key);

                message = message.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
                byte[] messageHash = hmacsha256.ComputeHash(messageBytes);

                return Convert.ToBase64String(messageHash);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
