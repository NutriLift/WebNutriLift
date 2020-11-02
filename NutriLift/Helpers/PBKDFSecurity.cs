using System.Security.Cryptography;

namespace NutriLift.Helpers
{
    public class PBKDFSecurity
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 20;
        private const int Pbkdf2Iterations = 1000;
        public static byte[] GenerateSalt()
        {
            var bytes = new byte[SaltByteSize];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }

        public static byte[] GenerateHash(string password, byte[] salt)
        {

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Pbkdf2Iterations))
            {
                return deriveBytes.GetBytes(HashByteSize);
            }
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        public static bool ValidatePassword(byte[] passwordHash, byte[] salt, string userPassword)
        {
            var userPasswordHash = GenerateHash(userPassword, salt);
            return SlowEquals(passwordHash, userPasswordHash);
        }
    }
}
