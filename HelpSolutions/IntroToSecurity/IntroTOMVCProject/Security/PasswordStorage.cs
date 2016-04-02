
using System;
using System.Text;
using System.Security.Cryptography;

namespace PasswordSecurity
{
    class InvalidHashException : Exception
    {
        public InvalidHashException() { }
        public InvalidHashException(string message)
            : base(message)
        { }
        public InvalidHashException(string message, Exception inner)
            : base(message, inner)
        { }
    }

    class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException() { }
        public CannotPerformOperationException(string message)
            : base(message)
        { }
        public CannotPerformOperationException(string message, Exception inner)
            : base(message, inner)
        { }
    }

    public class SecuredPassword // 2. Add this class
    {
        public int Iterations { get; set; }
        public int HashLength { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }

    public class PasswordStorage  // 1. Make public
    {
        // These constants may be changed without breaking existing hashes.
        public const int SALT_BYTES = 24;
        public const int HASH_BYTES = 18;
        public const int PBKDF2_ITERATIONS = 64000;

        // These constants define the encoding and may not be changed.
        public const int HASH_SECTIONS = 5;
        public const int HASH_ALGORITHM_INDEX = 0;
        public const int ITERATION_INDEX = 1;
        public const int HASH_SIZE_INDEX = 2;
        public const int SALT_INDEX = 3;
        public const int PBKDF2_INDEX = 4;

        public static SecuredPassword CreateHash(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[SALT_BYTES];
            try
            {
                using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }
            }
            catch (CryptographicException ex)
            {
                throw new CannotPerformOperationException(
                    "Random number generator not available.",
                    ex
                );
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to random number generator.",
                    ex
                );
            }

            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);

            // format: algorithm:iterations:hashSize:salt:hash
            //String parts = "sha1:" +
            //    PBKDF2_ITERATIONS +
            //    ":" +
            //    hash.Length +
            //    ":" +
            //    Convert.ToBase64String(salt) +
            //    ":" +
            //    Convert.ToBase64String(hash);

            return new SecuredPassword  /// 3. Add 
            {
                Iterations = PBKDF2_ITERATIONS,
                HashLength = hash.Length,
                Salt = Convert.ToBase64String(salt),
                Hash = Convert.ToBase64String(hash) //Overall encrypted password
        };
        }

        public static bool VerifyPassword(string password, string goodHash, string goodSalt)
        {


            byte[] salt = null;
            try
            {
                salt = Convert.FromBase64String(goodSalt);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Convert.FromBase64String",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Base64 decoding of salt failed.",
                    ex
                );
            }

            byte[] hash = null;
            try
            {
                hash = Convert.FromBase64String(goodHash);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Convert.FromBase64String",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Base64 decoding of pbkdf2 output failed.",
                    ex
                );
            }


            byte[] testHash = PBKDF2(password, salt, PBKDF2_ITERATIONS, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt))
            {
                pbkdf2.IterationCount = iterations;
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }
}
