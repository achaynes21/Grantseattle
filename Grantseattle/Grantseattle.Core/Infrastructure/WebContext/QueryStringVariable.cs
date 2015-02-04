using System;
using System.Web;

namespace InventoryERP.Core.WebContext
{
    public class QueryStringVariable<T>
    {
        private readonly string _key;

        public string Key
        {
            get { return _key;  }
        }

        public QueryStringVariable(string key)
        {
            Check.Argument.EmptyOrWhiteSpace(key, "key");
            _key = key;
        }

        private static HttpRequest CurrentRequest
        {
            get
            {
                var current = HttpContext.Current;
                Check.Argument.Null(current, "httpcontext", "No httpcontext is available");

                var request = current.Request;
                Check.Argument.Null(request, "request", "No request available on current httpcontext.");

                return request;
            }
        }

        private object GetInternalValue()
        {
            string value = CurrentRequest.QueryString.Get(_key);

            if (value == null) return null;
            else if (value == String.Empty) return typeof(T).Equals(typeof(string)) ? value : null;

            try
            {
                if (typeof(T).Equals(typeof(int))) return int.Parse(value);
                if (typeof(T).Equals(typeof(long))) return long.Parse(value);
                if (typeof(T).Equals(typeof(double))) return double.Parse(value);
                if (typeof(T).Equals(typeof(string))) return value;
                if (typeof(T).Equals(typeof(bool))) return Convert.ToBoolean(value);

                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception("QueryString key:{0} was expected to be of type {1} but was not.".FormatWith(_key, typeof(T)), ex);
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
                Check.Argument.Null(v, "key", "The querystring does not contain any value for '{0}'.".FormatWith(_key));

                return (T)v;
            }
            set
            {
                CurrentRequest.QueryString[_key] = value.ToString();
            }
        }
        public T ValueOrDefault
        {
            get
            {
                var v = GetInternalValue();

                if (v == null) return default(T);
                if (v.ToString().IsNullOrWhiteSpace()) return default(T);

                return (T)v;
            }
        }
    }
}
