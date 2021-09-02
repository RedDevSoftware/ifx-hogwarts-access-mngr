namespace Ifx.Services.hogwartsAccess.Application.Exceptions
{
    using System;

    public class AlreadyException : Exception
    {
        public AlreadyException(string name, object key)
            : base($"Failed, the \"{name}\" of entity ({key}) already exists failed with status PENDING.")
        {
        }
    }
}
