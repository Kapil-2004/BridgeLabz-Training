using System;

namespace TechVille.Exceptions
{
    public class DuplicateCitizenException : Exception
    {
        public DuplicateCitizenException(string message) : base(message) { }
    }
}
