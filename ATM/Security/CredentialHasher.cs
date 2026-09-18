using System;
using System.Security.Cryptography;

namespace ATM
{
    internal static class CredentialHasher
    {
        private const string Prefix = "pbkdf2-sha256";
        private const int Iterations = 100000;
        private const int SaltSize = 16;
        private const int KeySize = 32;

        public static string Hash(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            byte[] salt = new byte[SaltSize];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            byte[] key;
            using (Rfc2898DeriveBytes derive = new Rfc2898DeriveBytes(value, salt, Iterations, HashAlgorithmName.SHA256))
            {
                key = derive.GetBytes(KeySize);
            }

            return string.Join("$",
                Prefix,
                Iterations.ToString(),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(key));
        }

        public static bool Verify(string value, string storedValue, out bool legacyPlaintext)
        {
            legacyPlaintext = false;

            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(storedValue))
            {
                return false;
            }

            if (!storedValue.StartsWith(Prefix + "$", StringComparison.Ordinal))
            {
                legacyPlaintext = true;
                return string.Equals(value, storedValue, StringComparison.Ordinal);
            }

            string[] parts = storedValue.Split('$');
            if (parts.Length != 4 || !int.TryParse(parts[1], out int iterations))
            {
                return false;
            }

            try
            {
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expected = Convert.FromBase64String(parts[3]);
                byte[] actual;

                using (Rfc2898DeriveBytes derive = new Rfc2898DeriveBytes(value, salt, iterations, HashAlgorithmName.SHA256))
                {
                    actual = derive.GetBytes(expected.Length);
                }

                return FixedTimeEquals(actual, expected);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left == null || right == null || left.Length != right.Length)
            {
                return false;
            }

            int difference = 0;
            for (int i = 0; i < left.Length; i++)
            {
                difference |= left[i] ^ right[i];
            }

            return difference == 0;
        }
    }
}
