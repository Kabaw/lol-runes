using System;

namespace LolRunes.Domain.Core.Exceptions
{
    public abstract class BaseException : Exception
    {
        public bool displayErrorMessage { get; private set; }
        public string title { get; private set; }

        public BaseException() { }

        public BaseException(string message, bool displayErrorMessage = false) : base(message)
        {
            this.displayErrorMessage = displayErrorMessage;
        }

        public BaseException(string message, Exception inner, bool displayErrorMessage = false) : base(message, inner)
        {
            this.displayErrorMessage = displayErrorMessage;
        }

        public BaseException(string title, string message) : base(message)
        {
            this.displayErrorMessage = true;
            this.title = title;
        }
    }
}
