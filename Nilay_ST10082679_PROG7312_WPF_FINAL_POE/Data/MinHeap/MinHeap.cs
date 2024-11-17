using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    using System;
    using System.Collections.Generic;

    public class MinHeap
    {
        private List<ServiceRequest> heap;
        //--------------------------------------------------------------------------------------//
        // Constructor
        public MinHeap()
        {
            heap = new List<ServiceRequest>();
        }
        //--------------------------------------------------------------------------------------//
        // Insert a new ServiceRequest into the heap
        public void Insert(ServiceRequest request)
        {
            heap.Add(request);
            HeapifyUp(heap.Count - 1);
        }
        //--------------------------------------------------------------------------------------//
        // Returns the highest priority request without removing it
        public ServiceRequest Peek()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            return heap[0];
        }
        //--------------------------------------------------------------------------------------//
        // Removes and returns the highest priority request
        public ServiceRequest ExtractMin()
        {
            // If the heap is empty, throw an exception
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            ServiceRequest minRequest = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            // Return the highest-priority request
            return minRequest;
        }
        //--------------------------------------------------------------------------------------//
        // Traverses the heap in priority order and processes each request using the given action
        public void GetRequestsInPriorityOrder(Action<ServiceRequest> action)
        {
            MinHeap tempHeap = new MinHeap();

            // Copy all elements from the current heap to the temporary heap
            foreach (var request in heap)
                tempHeap.Insert(request);

            // Extract all elements in priority order
            while (tempHeap.heap.Count > 0)
            {
                action(tempHeap.ExtractMin());
            }
        }
        //--------------------------------------------------------------------------------------//
        // Heapify up to maintain the min-heap property
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                // calculate the parent index
                int parentIndex = (index - 1) / 2;
                // check if the current node has a smaller priority than the parent node
                if (heap[index].Priority < heap[parentIndex].Priority)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }
        //--------------------------------------------------------------------------------------//
        // Restores the min-heap property by moving an element down the heap
        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;
            while (index < lastIndex)
            {
                // calculate the child indices
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int smallestIndex = index;
                // check is left child has a smaller priority than the current node
                if (leftChildIndex <= lastIndex && heap[leftChildIndex].Priority < heap[smallestIndex].Priority)
                    smallestIndex = leftChildIndex;
                // check if right child has a smaller priority than the current node
                if (rightChildIndex <= lastIndex && heap[rightChildIndex].Priority < heap[smallestIndex].Priority)
                    smallestIndex = rightChildIndex;

                if (smallestIndex != index)
                {
                    Swap(index, smallestIndex);
                    index = smallestIndex;
                }
                else
                {
                    break;
                }
            }
        }
        //--------------------------------------------------------------------------------------//
        // Swaps two elements in the heap
        private void Swap(int indexA, int indexB)
        {
            var temp = heap[indexA];
            heap[indexA] = heap[indexB];
            heap[indexB] = temp;
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//