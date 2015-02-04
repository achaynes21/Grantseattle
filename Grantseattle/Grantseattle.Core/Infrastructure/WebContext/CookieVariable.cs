using System;
using System.Web;
using System.Web.SessionState;
using System.Linq;

namespace InventoryERP.Core.WebContext
{
    public class CookieVariable<T>
    {
        private readonly string _key;

        public CookieVariable(string key)
        {
            Check.Argument.EmptyOrWhiteSpace(key, "key");
            _key = key;
        }

        private HttpCookie Cookie
        {
            get
            {
                return CurrentContext.Request.Cookies.AllKeys.Contains(_key) ? CurrentContext.Request.Cookies[_key] : new HttpCookie(_key);
            }
        }

        private static HttpContext CurrentContext
        {
            get
            {
                var current = HttpContext.Current;
                Check.Argument.Null(current, "httpcontext", "No httpcontext is available");

                return current;
            }
        }

        private object GetInternalValue()
        {
            string value = Cookie.Value;

            if (value.IsNullOrWhiteSpace()) return null;

            try
            {
                if (typeof(T).Equals(typeof(int))) return int.Parse(value);
                if (typeof(T).Equals(typeof(long))) return long.Parse(value);
                if (typeof(T).Equals(typeof(double))) return double.Parse(value);
                if (typeof(T).Equals(typeof(string))) return value;

                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception("Cookie key:{0} was expected to be of type {1} but was not.".FormatWith(_key, typeof(T)), ex);
            }
        }

        public bool HasValue
        {
            get { return GetInternalValue() != null; }
        }

        public T Value
        {
            get
            {
                var v = GetInternalValue();
                Check.Argument.Null(v, "key", "The cookie does not contain any value for '{0}'.".FormatWith(_key));

                return (T)v;
            }
            set
            {
                Cookie.Value = Convert.ToString(value);
                Cookie.Expires = DateTime.Now.AddYears(1);
                CurrentContext.Response.Cookies.Add(Cookie);
            }
        }

        public T ValueOrDefault
        {
            get
            {
                var v = GetInternalValue();
                if (v == null) return default(T);

                return (T)v;
            }
        }

        public void Clear()
        {
            Cookie.Expires = DateTime.Now.AddDays(-1);
            CurrentContext.Response.Cookies.Add(Cookie);
        }
    }
}
