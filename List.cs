using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    class List
    {
        // Capacity is used to initailize the myMemory array.
        static int capacity = 5;
        int[] myMemory = new int[capacity];

        // Tracks how may item are in the myMemory array.
        int items = 0;

        public List()
        {

        }
        
        /// <summary>
        /// The add method adds an item to the end of the array. If the array is full, the method will double the size of the array, copy the contents of the array to the tempMemory array, point the memory location to the newly sized array, and then adds the new item.
        /// </summary>
        /// <param name="i">'i' is the integer type to add to myMemory array.</param>
        public void Add(int i)
        {
            // This tracks the first open index of the myMemory array.
            int firstopen = items;

            // Check if the array is maxed out. If so create a new array doubling the size of the current array and copy the contents to the new array.
            ResizeList();

            // Add the new item to the newly sized array.
            myMemory[firstopen] = i;

            // Track the current number of items in the array.
            items++;
        }


        /// <summary>
        /// Print the contents of the list.
        /// </summary>
        public void print()
        {
            for(int i = 0; i < items; i++)
            {
                {
                    Console.WriteLine(myMemory[i]);
                }
            }
        }

        private void ResizeList()
        {
            if (items == capacity)
            {
                // Double the capacity for the array
                capacity *= 2;

                //Temp array to hold the contents of the old array.
                int[] tempMemory = new int[capacity];

                // Used to place the contents of the old array in the proper place in the newly sized array.
                int trackIndex = 0;

                foreach (int j in myMemory)
                {
                    tempMemory[trackIndex] = j;
                    trackIndex++;
                }

                // Point the old array to the newly sized array.
                myMemory = tempMemory;

            }
        }

        /// <summary>
        /// Removes the first occurance of 'item'.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(int item)
        {
            // What if the entry to delete was a zero?
            for(int i = 0; i < items; i++)
            {
                // If the item is found, set the index of the item to the default value of 0.
                if(myMemory[i] == item)
                {
                    myMemory[i] = 0;
                    break;
                }
            }
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">An integer that corresponds to the index.</param>
        public void RemoveAt(int index)
        {
            myMemory[index] = 0;
        }

        public void Insert(int index, int item)
        {
            // Check if the array is maxed out. If so create a new array doubling the size of the current array and copy the contents to the new array.
            ResizeList();

            // Number of items to shift right to allow insert at the specified index.
            int shiftRight = items - (index - 1);
            int decrement = items;

            //*** What if the insert is > # of items in the list? What to do? ***

            for (int i = 0; i < shiftRight; i++, decrement--)
            {
                myMemory[decrement] = myMemory[decrement - 1];
            }
            myMemory[index - 1] = item;
            items++;
        }


    }
}
