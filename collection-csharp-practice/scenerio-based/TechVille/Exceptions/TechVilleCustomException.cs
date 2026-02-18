using System;

namespace TechVille.Exceptions
{
    public class TechVilleCustomException : Exception
    {
        public TechVilleCustomException(string message) : base(message)
        {
        }
    }
}
