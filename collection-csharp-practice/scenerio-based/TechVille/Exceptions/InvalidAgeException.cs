namespace TechVille.Exceptions
{
    public class InvalidAgeException : TechVilleCustomException
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }
}
