using System;
using System.Security.Cryptography;
using System.Text;
using DotnetKoeln.STS.Settings;

namespace DotnetKoeln.STS.Services
{
    public sealed class Hashing : IHashing
    {
        private readonly IHashingSettings settings;

        public Hashing(IHashingSettings settings) {
            this.settings = settings;
        }

        public string CreateHash(string password, DateTime addionalSalt) {
            return CreateHash(password, addionalSalt.Second * addionalSalt.DayOfYear);
        }

        private string CreateHash(string password, long additionalSalt) {
            var sha1Provider = new SHA1CryptoServiceProvider();

            byte[] data = Encoding.Default.GetBytes(password + settings.Salt + additionalSalt);

            return ConvertToString(sha1Provider.ComputeHash(data));
        }

        private static string ConvertToString(byte[] hash) {
            var result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++) {
                string temp = Convert.ToString(hash[i], 16).ToUpperInvariant();
                if (temp.Length == 1) {
                    temp = @"0" + temp;
                }
                result.Append(temp);
            }
            return result.ToString();
        }
    }
}