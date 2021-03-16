using System;
using System.Collections.Generic;
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


    }
}
