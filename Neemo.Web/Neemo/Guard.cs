using System;

namespace Neemo
{
    public static class Guard
    {
        public static void NotNull<T>(T target)
        {
            if(Equals(target, default(T)))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
