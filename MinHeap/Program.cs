using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHeap
{
    class Program
    {
        class Heap
        {
            private List<int> heap;

            public Heap()
            {
                heap = new List<int>
                {
                    -1//The unused element
                };
            }

            //left child index = i * 2
            //right child index = i * + 1
            //parent index = i / 2;
            public void Add(int el)
            {
                //Add a new element
                heap.Add(el);
                if(heap.Count > 2) //In this case we need to check if the rule of heaps is correct
                {
                    int indexLast = heap.Count - 1; //The index of last added element
                    while(heap[indexLast] < heap[indexLast / 2]) //child < parent
                    {
                        //swap the child and parent elements
                        int tmp = heap[indexLast];
                        heap[indexLast] = heap[indexLast / 2];
                        heap[indexLast / 2] = tmp;

                        //move index
                        indexLast = indexLast / 2;
                        if (indexLast == 1) break; //we reach the last element
                    }
                }
            }//End of Add()
        
            //Print heap
            public void PrintHeap()
            {
                for (int i = 1; i < heap.Count; i++) //The very first element is not used
                    Console.WriteLine(heap[i]);
            }

            public int GetMin()
            {
                if (heap.Count > 1) return heap[1];
                return -1;
            }

            public int RemoveMin()
            {
                if (heap.Count == 1) return -1;

                int min = heap[1];
              
                //It's the lastest element in the heap
                if(heap.Count == 2)
                {
                    heap.RemoveAt(heap.Count - 1);
                    return min;
                }

                //There are two elements in the heap
                if(heap.Count == 3)
                {
                    heap[1] = heap[2];
                    heap.RemoveAt(2);
                    return min;
                }

                if (heap.Count > 5)//There're a lot of elements
                {
                    int lastElement = heap[heap.Count - 1];
                    heap[1] = lastElement;
                    heap.RemoveAt(heap.Count - 1);

                    //Check if the heap is right
                    int parent = 1;
                    int left = 2;
                    int right = 3;
                    while(heap[parent] > heap[left] || heap[parent] > heap[right])
                    {
                        if(heap[left] > heap[right])//right is the smallest element
                        {
                            int tmp = heap[right];
                            heap[right] = heap[parent];
                            heap[parent] = tmp;
                            parent = right;
                        }
                        else
                        {
                            int tmp = heap[left];
                            heap[left] = heap[parent];
                            heap[parent] = tmp;
                            parent = left;
                         }
                            left = parent * 2;
                            right = parent * 2 + 1;
                        if (left > heap.Count - 1 || right > heap.Count - 1) break; //we reach leaves

                    }

                }
                else//There're four elements
                {
                    heap[1] = heap[3];
                    heap.RemoveAt(3);
                    if (heap[1] > heap[2])
                    {
                        int tmp = heap[1];
                        heap[1] = heap[2];
                        heap[2] = tmp;
                    }
                }
                    return min;
                }

                 public List<int> GetSortedArray()
                {
                    var result = new List<int>();
                    while(heap.Count > 1)
                    {
                        result.Add(this.RemoveMin());
                    }
                    return result;
                }  
            }//End of class Heap

        static void Main(string[] args)
        {
            var heap = new Heap();
            heap.Add(8);
            heap.Add(1);
            heap.Add(5);
            heap.Add(9);
            heap.Add(3);
            heap.Add(13);

          // heap.PrintHeap();

           Console.WriteLine(heap.GetMin());

            //Sorting with heap
            var sorted = heap.GetSortedArray();
            foreach (int el in sorted)
                Console.Write(el + " ");
            Console.WriteLine();
        }
    }
}
