using GraphAlgorithmVisualizer.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithmVisualizer
{
    internal class PriorityHeap<T>
    {
        private readonly List<T> heap;
        public int HeapSize => heap.Count;
        public bool IsEmpty => heap.Count == 0;

        public PriorityHeap() {
            heap = new List<T>();
        }

        /// <summary>
        /// Appends a new item at the end of the heap.
        /// </summary>
        /// <param name="item">The object to add to the heap.</param>
        /// <exception cref="GraphException">Thrown if the heap already contains a similair object.</exception>
        public void Insert(T item)
        {
            if (heap.Contains(item))
                throw new GraphException("Attempted to add a duplicate item into PriorityHeap.");
            heap.Add(item);
        }
        /// <summary>
        /// Adds the specified item on the specified index. If the index points outside of the heap, method appends the item at the end of the heaps.
        /// </summary>
        /// <param name="index">The index to add the object at.</param>
        /// <param name="item">The object to add to the heap.</param>
        /// <exception cref="GraphException">Thrown if the heap already contains a similair object.</exception>
        public void InsertAt(int index, T item)
        {
            if (heap.Contains(item))
                throw new GraphException("Attempted to add a duplicate item into PriorityHeap.");
            heap.Insert(index, item);
        }
/// <summary>
/// If the specified item has an index of N, then method swaps the item's position with the element from N - 1 index.
/// </summary>
/// <param name="item">The object to swap down in the heap.</param>
/// <exception cref="GraphException">Thrown if method attempts to decrease the key of a non-existent element or if the element to decrease the key of is at index of 0.</exception>
        public void DecreaseKey(T item)
        {
            if (!heap.Contains(item))
                throw new GraphException("Attempted to decrease a key of a non-existent element.");
            if (heap.IndexOf(item) == 0)
                throw new GraphException("Attempted to decrease a key of the element which was at index of 0.");
            int itemIndex = heap.IndexOf(item);
            (heap[itemIndex - 1], heap[itemIndex]) = (heap[itemIndex], heap[itemIndex - 1]);
        }
        /// <summary>
        /// Retrieves the element at heap's index of 0 and removes it.
        /// </summary>
        /// <returns>The element at the heap's index of 0.</returns>
        public T DeleteMin()
        {
            T t = heap[0];
            for (int i = 0; i < heap.Count - 2; i++)
                heap[i] = heap[i + 1];
            heap.RemoveAt(heap.Count - 1);
            return t;
        }
        /// <summary>
        /// Clears the heap of all its contents.
        /// </summary>
        public void Clear() => heap.Clear();
        

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (T item in heap)
                builder.AppendLine($" {heap.IndexOf(item)} | {item}");
            return builder.ToString();
        }
    }
}
