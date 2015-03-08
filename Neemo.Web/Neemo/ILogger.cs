using System;

namespace Neemo
{
    public interface ILogger
    {
        void Error(string message);
        void Error(string message, Exception exception);
        void Info(string message);
    }
}