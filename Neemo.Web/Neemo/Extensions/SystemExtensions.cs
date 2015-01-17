namespace Neemo
{
    public static class SystemExtensions
    {
        public static void CopyPropertiesIfNotSet(this object source, object target)
        {
            var propertiesToSet = source.GetType().GetProperties();

            foreach (var propertyInfo in propertiesToSet)
            {
                var value = propertyInfo.GetValue(target);
                if (value == null)
                {
                    propertyInfo.SetValue(target, propertyInfo.GetValue(source));
                }
            }
        }
    }
}