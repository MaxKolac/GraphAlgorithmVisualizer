using System;
using System.Collections.Generic;

namespace GraphAlgorithmVisualizer
{
    internal class SpecialQueue<T>
    {
        private readonly List<T> queue;

        public T this[int i] => queue[i % Size];
        /// <summary>
        /// Points towards the first element of the <c>SpecialQueue</c>, which will be ejected when using <c>Eject()</c> method.
        /// </summary>
        public T Head => this[0];
        /// <summary>
        /// Points towards the last element of the <c>SpecialQueue</c>.
        /// </summary>
        public T Tail => this[Size - 1];
        public int Size { private set; get; }
        public readonly int MaxSize;

        public SpecialQueue(int size)
        {
            queue = new List<T>(size);
            Size = 0;
            MaxSize = size;
        }

        public void Inject(T x)
        {
            if (MaxSize == Size)
                throw new Exception("Attempted to overflow the SpecialQueue. SpecialQueue already at MaxSize.");
            queue[Size] = x;
            Size++;
        }

        public T Eject()
        {
            if (Size == 0)
                throw new Exception("SpecialQueue is empty, nothing to eject.");
            T ejectedValue = queue[0];
            for (int i = 0; i < Size - 1; i++)
                queue[i] = queue[i + 1];
            queue[Size - 1] = default;
            Size--;
            return ejectedValue;
        }
    }
}
