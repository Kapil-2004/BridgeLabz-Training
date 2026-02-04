using System;

public class InvalidWordException : Exception
{
    public InvalidWordException(string message) : base(message) { }
}

