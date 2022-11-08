using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolRunes.Domain.Core.Exceptions
{
    public class BusinessLogicException : BaseException
    {
        public BusinessLogicException() { }

        public BusinessLogicException(string message, bool displayErrorMessage = false) : base(message, displayErrorMessage) { }

        public BusinessLogicException(string message, Exception inner, bool displayErrorMessage = false) : base(message, inner, displayErrorMessage) { }

        public BusinessLogicException(string title, string message) : base(title, message) { }
    }
}
