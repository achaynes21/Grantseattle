using System;
using System.Web;
using System.Web.SessionState;

namespace InventoryERP.Core.WebContext
{
    public class SessionVariable<T>
    {
        private readonly string _key;
        private readonly Func<T> _initializer;

        public SessionVariable(string key)
        {
            Check.Argument.EmptyOrWhiteSpace(key, "key");
            _key = GetType() + key;
        }
        public SessionVariable(string key, Func<T> initializer)
            : this(key)
        {
            Check.Argument.Null(initializer, "initializer");
            _initializer = initializer;
        }

        private static HttpSessionState CurrentSession
        {
            get
            {
                var current = HttpContext.Current;
                Check.Argument.Null(current, "httpcontext", "No httpcontext is available");

                var session = current.Session;
                Check.Argument.Null(session, "session", "No session available on current httpcontext.");

                return session;
            }
        }
        private object GetInternalValue(bool initializeIfNessesary)
        {
            object value = CurrentSession[_key];

            if (value == null && initializeIfNessesary && _initializer != null)
                CurrentSession[_key] = value = _initializer();

            return value;
        }
        
        public bool HasValue
        {
            get { return GetInternalValue(false) != null; }
        }
        public T Value
        {
            get
            {
                var v = GetInternalValue(true);
                Check.Argument.Null(v, "key", "The session does not contain any value for '{0}'.".FormatWith(_key));

                return (T)v;
            }
            set
            {
                CurrentSession[_key] = value;
            }
        }
        public T ValueOrDefault
        {
            get
            {
                var v = GetInternalValue(true);
                if (v == null) return default(T);

                return (T)v;
            }
        }
        public void Clear()
        {
            CurrentSession.Remove(_key);
        }        
    }
}
