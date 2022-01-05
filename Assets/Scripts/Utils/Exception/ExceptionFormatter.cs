using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolRunes.Utils.Exceprion
{
    public class ExceptionFormatter
    {
        public static readonly string separator = "@#$";

        public static ExceptionMessageData GetExceptionMessageData(Exception exception)
        {
            string[] texts = exception.Message.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            ExceptionMessageData message = new ExceptionMessageData();

            if (texts.Length == 2)
            {
                message.Title = texts[0].Trim();
                message.Message = texts[1].Trim();
            }
            else
            {
                message.Title = "Warning";
                message.Message = texts[0].Trim();
            }

            return message;
        }
    }
}
