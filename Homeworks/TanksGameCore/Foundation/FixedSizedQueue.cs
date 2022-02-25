using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Tanks_Game_Core
{
    public class FixedSizedQueue<T>
    {
        ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        private object lockObject = new object();
        private int size;
        
        public FixedSizedQueue(int size) =>
            this.size = size;
        
        public void Enqueue(T obj)
        {
            queue.Enqueue(obj);
            lock (lockObject)
            {
                T overflow;
                while (queue.Count > size && queue.TryDequeue(out overflow));
            }
        }

        public T[] ToArray() => queue.ToArray();
        public void Clear() => queue.Clear();
    }
}