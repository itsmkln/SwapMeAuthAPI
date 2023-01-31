using System.Security.Cryptography;

namespace SwapMeAngularAuthAPI.Helpers
{
    public class PwHasher
    {
        //replacing RNGCrypto to RNG
        //private static RNGCryptoServiceProvider rng = new();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;
        public static string HashPw(string pw)
        {
            using (var rng = RandomNumberGenerator.Create())
            {

                byte[] salt;

                rng.GetBytes(salt = new byte[SaltSize]);
                var key = new Rfc2898DeriveBytes(pw, salt, Iterations);
                var hash = key.GetBytes(HashSize);

                var hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                var b64hash = Convert.ToBase64String(hashBytes);
                return b64hash;
            }
        }

        public static bool VerifyPassword(string pw, string b64hash)
        {
            var hashBytes = Convert.FromBase64String(b64hash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var key = new Rfc2898DeriveBytes(pw, salt, Iterations);
            byte[] hash = key.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }
            return true;
        }
    }
}
