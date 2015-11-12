using System;

namespace Assets.Extension
{
    public static class MyExtensions
    {
        public static T ThrowIfNull<T>(this T o, string name)
        {
            if (o == null)
                throw new ArgumentNullException(name);
            return o;
        }
    }
}