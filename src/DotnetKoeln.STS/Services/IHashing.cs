using System;

namespace DotnetKoeln.STS.Services
{
    public interface IHashing
    {
        string CreateHash(string textToHash, DateTime addionalSalt);
    }
}