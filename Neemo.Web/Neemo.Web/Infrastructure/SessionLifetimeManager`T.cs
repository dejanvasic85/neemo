using System.Web;

namespace Neemo.Web.Infrastructure
{
    public class SessionLifetimeManager<T> : Microsoft.Practices.Unity.LifetimeManager
    {
        private readonly string _key;

        public SessionLifetimeManager()
        {
            this._key = typeof(T).Name;
        }

        /// <summary>
        /// Retrieve a value from the backing store associated with this Lifetime policy.
        /// </summary>
        /// <returns>
        /// the object desired, or null if no such object is currently stored.
        /// </returns>
        public override object GetValue()
        {
            return HttpContext.Current.Session[this._key];
        }

        /// <summary>
        /// Stores the given value into backing store for retrieval later.
        /// </summary>
        /// <param name="newValue">The object being stored.</param>
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Session[this._key] = newValue;
        }

        /// <summary>
        /// Remove the given object from backing store.
        /// </summary>
        public override void RemoveValue()
        {
        }
    }
}