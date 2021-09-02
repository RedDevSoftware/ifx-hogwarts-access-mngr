namespace Ifx.Services.hogwartsAccess.Application.Exceptions
{
    using System;

    public class GeneralException : Exception
    {
        public GeneralException(string message)
            : base($"\"{message}\"")
        {
        }
    }
}
