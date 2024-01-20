using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PokerWinForms
{
    internal class ImageNotFoundException : Exception
    {
        public ImageNotFoundException()
        {
        }

        public ImageNotFoundException(string? message) : base(message)
        {
        }

        public ImageNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
