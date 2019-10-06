using System;


using System.Collections.Generic;
using System.Linq;
using System.Collections;
namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1, 3 };
            int[] nums2 = { 2, 2 , 3};
            int[] intersect = Intersect(nums1, nums2);
            DisplayArray(intersect);
            Console.WriteLine("\n");


            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }
        //function to display elements of 1D array
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        //function to display elements of 2D array
        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }


        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int index;
                index = gettargetindex(nums, target);
                Console.WriteLine("The index of the array where input can be stored is :" + index);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        //function that gets the index of the element
        public static int gettargetindex(Array array1, object target)
        {
            //search for the BinarySearch function, that gets the index of the element
            //if element is found, index is returned
            //else target index is returned
            int position = Array.BinarySearch(array1, target);
            if (position < 0)
            {
                return (~position);
            }
            else
            {
                return (position);
            }
        }

        //
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
 
                ArrayList myList = new ArrayList();
                int i = 0;
                int j = 0;
                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] == nums2[j])
                    {
                        myList.Add(nums1[i]);
                        i++;
                        j++;

                    }
                    else if (nums1[i] > nums2[j])
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                    }
                }
                Console.Write("The intersection of two arrays are :");
                foreach (var item in myList)
                {
                    Console.Write(item + ",");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }
        
        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
               
                var d = new Dictionary<int, int>();
                var countofnumbers = new List<int>();
                //iterate through the array and add each element as a key to dictionary and value as 1 if the key is not present in dictionary
                //if the element is already present in dictionary, then increment its corresponding value
                foreach (var number in A)
                {
                    if (d.ContainsKey(number))
                        d[number]++;
                    else
                        d.Add(number, 1);
                }

                //if the value of any key is 1, then add it to list.
                foreach (var val in d)
                {
                    if (val.Value == 1)
                    {
                        countofnumbers.Add(val.Key);
                    }
                }
                //get the largest value of the list, which is the largest unique value
                int max = countofnumbers.Max();
                return(max);

            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                int k = 0;
                //for each character in string asssigning the key values
                foreach (char x in keyboard)
                {
                    dict[x] = k;
                    k++;
                }
                int inital = 0;
                int Value = 0;
                int total = 0;
                //traverse trough given word for each character
                foreach (char item in word)
                {
                    //finding the difference of therir assigned values 
                    Value = Math.Abs(dict[item] - inital);
                    //storing difference every time in variable diff
                    int diff = Value;
                    //changing the initial values every time to new shifted spot index
                    inital = dict[item];
                    //adding the difference and saving in the variable total
                    total = total + diff;
                }
                Console.WriteLine("Time taken to type with one finger is: " + total);

            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        //
      


        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {

                int row = A.GetLength(0);
                int col = A.GetLength(1);
                int b, c, d;
                int[,] B = new int[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        //Flip the array
                        b = A[i, j];
                        c = A[i, col - j - 1];
                        d = b;
                        b = 0;
                        b = c;
                        c = d;
                        B[i, j] = b;
                        //Invert the array
                        if (B[i, j] == 0)
                            B[i, j] = 1;
                        else if (B[i, j] == 1)
                            B[i, j] = 0;
                    }
                }
                return B;
               // return new int[,] { };

                // Display2DArray(valuesRowAdded);
            //}
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

        return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
               // int[,] intervals = { { 20, 30 }, { 5, 10 }, { 15, 20 } };

                int[] start = new int[intervals.Length / 2];
                int[] end = new int[intervals.Length / 2];
                //extract the start and end times
                for (int k = 0; k < intervals.Length / 2; k++)
                {
                    start[k] = intervals[k, 0];
                    end[k] = intervals[k, 1];
                }

                //sorting the start and end dates.
                Array.Sort(start);
                Array.Sort(end);
                int i = 0;
                int j = 0;
                int room = 0;

                while (i < start.Length && j < start.Length) // traverse through loop until i,j < array length
                {
                    if (start[i] < end[j])
                    { // if condition is true room will be alloted 
                        room++;
                        i++;
                    }
                    else // room count will not increase and i,j increments
                    {
                        i++;
                        j++;
                    }
                }
                Console.WriteLine("required number of rooms are : " + room);
                return room;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        // referenced from https://www.geeksforgeeks.org/sort-array-converting-elements-squares/ on 10/05/2019
        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int n = A.Length;
                //k will store the number of negative numbers in the array.
                int k;
                //iterate through each element of the check and check if it is lesser than 0, if it is less increment k by 1, ekse break the loop without incrementing k
                for (k = 0; k < A.Length; k++)
                {
                    if (A[k] >= 0)
                        break;
                }  

                //Since the array is already sorted, all the negative numbers will b within the k-1 of the original array
                //initialising the index for the array with negative values and positive values
                int negindex = k - 1;  
                int posindex = k; 
                int index = 0; // Initialising the index of temp array  
                //initialise empty array to store the elements after squaring and sorting.
                int[] temparray = new int[A.Length];
                //iterate from right to left from the negative index
                //iterate from the positive index to the right in array
                //square each negative element and positive element
                //Compare the squared value and add the greater value to the temporary array
                while (negindex >= 0 && posindex < A.Length)
                {
                    if (A[negindex] * A[negindex] < A[posindex] * A[posindex])
                    {
                        temparray[index] = A[negindex] * A[negindex];
                        negindex--;
                    }
                    else
                    {
                        temparray[index] = A[posindex] * A[posindex];
                        posindex++;
                    }
                    index++;
                }
                for (int j = negindex; j >= 0; j--)
                {
                    temparray[index++] = A[negindex] * A[negindex];

                }
                      

                for (int i = posindex; i < A.Length; i++)
                {
                    temparray[index++] = A[posindex] * A[posindex];
                    
                }

                // copy contents of temparray to A 
                for (int x = 0; x < A.Length; x++)
                    A[x] = temparray[x];
                return A;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {

                string str = s;
                int len = 0;
                int length = str.Length - 1;
                bool res = checkPalindrome(str);
                if (res == true)
                {

                    return res;
                }
                else
                {
                    while (len <= length)
                    {

                        var x = str.Remove(len++, 1);
                        if (checkPalindrome(x) == true)
                        {

                            Console.WriteLine("Remove:" + str.Substring(len - 1, 1));
                            return (true);

                        }

                    }

                }
                return (res);


                static bool checkPalindrome(string t)
                {
                    //converts the string to character array
                    char[] cArray = t.ToCharArray();
                    //initialise an empty string
                    string reverse = String.Empty;
                    //iterate through the array from the end and add each element to the reverse string
                    for (int i = cArray.Length - 1; i > -1; i--)
                    {
                        reverse += cArray[i];
                    }
                    
                    if (reverse == t)
                        return true;
                    else
                        return false;

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}