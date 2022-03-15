using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _009_Expressions
{
    public interface ICache : IDisposable
    {
        Func<TSource, TResalt> CreateFunc<TSource, TResalt>(Expression<Func<TSource, TResalt>> expression);
        bool TryGetFunc<TSource, TResalt>(out Func<TSource, TResalt> func);
    }

    internal class InMemoryCache : ICache
    {
        private readonly Dictionary<Type, object> _cache;

        public InMemoryCache()
        {
            _cache = new Dictionary<Type, object>();
        }

        public Func<TSource, TResalt> CreateFunc<TSource, TResalt>(Expression<Func<TSource, TResalt>> expression)
        {
            var func = expression.Compile();
            _cache[func.GetType()] = func;
            return func;
        }

        public bool TryGetFunc<TSource, TResalt>(out Func<TSource, TResalt> func)
        {
            var type = typeof(Func<TSource, TResalt>);
            if (_cache.TryGetValue(type, out var cacheFunc))
            {
                func = (Func<TSource, TResalt>)cacheFunc;
                return true;
            }

            func = null;
            return false;
        }

        #region Dispose
        //https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
        private bool _disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _cache?.Clear();
            }

            _disposed = true;
        }
        #endregion
    }
}
