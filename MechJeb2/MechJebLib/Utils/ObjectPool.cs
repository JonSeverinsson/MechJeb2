/*
 * Copyright Lamont Granquist (lamont@scriptkiddie.org)
 * Dual licensed under the MIT (MIT-LICENSE) license
 * and GPLv2 (GPLv2-LICENSE) license or any later version.
 */

using System;
using System.Collections.Concurrent;

#nullable enable

namespace MechJebLib.Utils
{
    // TODO: min and max object levels
    public class ObjectPool<T>
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly Func<T>          _newfun;

        public ObjectPool(Func<T> newfun)
        {
            _objects = new ConcurrentBag<T>();
            _newfun  = newfun;
        }

        public T Get()
        {
            return _objects.TryTake(out T item) ? item : _newfun();
        }

        public void Return(T item)
        {
            _objects.Add(item);
        }
    }
}
