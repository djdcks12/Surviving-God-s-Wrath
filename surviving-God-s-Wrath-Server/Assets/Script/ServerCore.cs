using System;
using System.Collections.Generic;
using Google.Protobuf.Protocol;
using Server.Game;

namespace ServerCore
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> _data;

        public PriorityQueue()
        {
            _data = new List<T>();
        }

        public void Enqueue(T item)
        {
            _data.Add(item);
            int ci = _data.Count - 1; // child index; start at end
            while (ci > 0)
            {
                int pi = (ci - 1) / 2; // parent index
                if (_data[ci].CompareTo(_data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
                T tmp = _data[ci]; _data[ci] = _data[pi]; _data[pi] = tmp;
                ci = pi;
            }
        }

        
        public T Pop()
        {
            // assumes pq is not empty; up to calling code
            int li = _data.Count - 1; // last index (before removal)
            T frontItem = _data[0];   // fetch the front
            _data[0] = _data[li];
            _data.RemoveAt(li);

            --li; // last index (after removal)
            int pi = 0; // parent index. start at front of pq
            while (true)
            {
                int ci = pi * 2 + 1; // left child index of parent
                if (ci > li) break;  // no children so done
                int rc = ci + 1;     // right child
                if (rc <= li && _data[rc].CompareTo(_data[ci]) < 0) // if there is a right child (rc <= li) and it is smaller
                    ci = rc; // use the right child instead

                if (_data[pi].CompareTo(_data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                T tmp = _data[pi]; _data[pi] = _data[ci]; _data[ci] = tmp; // swap parent and child
                pi = ci;
            }
            return frontItem;
        }

        public T Peek()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("The priority queue is empty.");
            return _data[0];
        }

        public int Count()
        {
            return _data.Count;
        }
    }
}
