using System;

namespace Neemo.Tax
{
    public class TaxNotTheSameException : Exception
    {
        public TaxNotTheSameException(string msg)
            : base(msg)
        {

        }

        public TaxNotTheSameException()
        {

        }
    }
}