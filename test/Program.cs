using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace KJ
{

    class Program
    {
        static void Main(string[] args)  //========= Main Method=========//
        {
            double[] valuesArray = importData();
            Console.WriteLine("Imported Data Original Values: ");
            printarray(valuesArray);
            Console.WriteLine();
            Console.WriteLine();
            double[] maximumValues = findmaximum(importData());
            Console.WriteLine("Maximum Values Printed");
            printarray(maximumValues);
            Console.WriteLine();
            Console.WriteLine();
            SelectionSort(valuesArray);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Linear Search: ");
            linearSearch(importData());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Compare Arrays Method Below: ");
            compareArrays(importData());
            Console.ReadKey();
          
        }
//-------------------------------------------Print Array---------------------------------------------------------------------------------------------//

        public static void printarray(double[] arr) // Print Array
        {
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

//--------------------------------------------Import Data--------------------------------------------------------------------------------------------//

        public static double[] importData() 
        {
            string[] input = File.ReadLines(@"c:/Moisture_Data.txt").ToArray();
            double[] temp = new double[input.Length]; //Creates a new temporary array to hold the new values within. 
            for (int i = 0; i < input.Length; i++)
            {
                temp[i] = Convert.ToDouble(input[i]); //Converting and adding the new values to the newly created array
            }
            return temp; //Returning the array of imported double values. 
        }

        public static String[] importDataTimes() // Import Data
        {
            string[] input = File.ReadLines(@"c:/DateTime_Data.txt").ToArray();
            //double[] temp = new double[input.Length]; //Creates a new temporary array to hold the new values within. 
            //for (int i = 0; i < input.Length; i++)
            //{
            //    temp[i] = Convert.ToDouble(input[i]); //Converting and adding the new values to the newly created array
            //}
            return input; //Returning the array of imported double values. 
        }

//--------------------------------------------Find Maximum--------------------------------------------------------------------------------------------//

        public static double[] findmaximum(double[] arr) 
        {
            try //Valid input
            {
                Console.WriteLine("Please enter the number of maximum number(s) you would like to find");
                int maxNumberToFind = Convert.ToInt32(Console.ReadLine());
                double[] toReturn = new double[maxNumberToFind];
                int index = 0;
                //For the number of maximums to find
                for (int i = 0; i < maxNumberToFind; i++)
                {
                    double max = arr[0];
                    index = 0;
                    //Traverse through the array to find the max and the index it is stored at
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] > max)
                        {
                            max = arr[j];
                            index = j;
                        }
                    }
                    toReturn[i] = max;
                    arr[index] = Double.MinValue;
                    //index++;
                }

                return toReturn;

            }
            catch (Exception e)
            {
                Console.WriteLine("IO Error");
                return null;
            }



        }

//--------------------------------------------SelectionSort--------------------------------------------------------------------------------------------//

        public static double[] SelectionSort(double[] arr) 
        {
            double[] toReturn = new double[arr.Length];
            double max = Double.MinValue;
            double min = Double.MaxValue;
            double sum = 0;
            int numberOfElements = arr.Length;
            for (int i = 0; i < numberOfElements; i++)
            {
                int min_index = i;
                for (int y = i; y < numberOfElements; y++)
                {
                    if (arr[min_index] > arr[y])
                    {
                        min_index = y;
                    }
                }
                double temp = arr[i];
                arr[i] = arr[min_index];
                arr[min_index] = temp;
            }

            Console.WriteLine("Sort array in ascending order by using Selection Sort");

            for (int j = 0; j < numberOfElements; j++)
            {
                Console.Write(arr[j] + " ");
                if (arr[j] > max)
                {
                    max = arr[j];
                }
                if (arr[j] < min)
                {
                    min = arr[j];
                }
                sum = sum + arr[j];
                toReturn[j] = arr[j];

            }
            Console.WriteLine("");
            Console.WriteLine("Max Value: " + max);
            Console.WriteLine("Min Value: " + min);
            Console.WriteLine("Average Value: " + (sum / numberOfElements));
            return toReturn;
        }

//--------------------------------------------Linear Search--------------------------------------------------------------------------------------------//

        public static double[] linearSearch(double[] arr) 
        {
            
            double[] sortedArray = SelectionSort(arr);
            double max = Double.MinValue;
            double min = Double.MaxValue;
            double sum = 0;
            double average = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] > max)
                {
                    max = arr[j];
                }
                if (arr[j] < min)
                {
                    min = arr[j];
                }
                sum = sum + arr[j];
            }

            average = sum / arr.Length;
            average = Math.Round(average, 2);
            double[] toReturn = new double[3];

            for (int i = 0; i < arr.Length; i++)
            {
                if (max == arr[i])
                {
                    Console.WriteLine("Maximum is at index: " + i);
                    toReturn[0] = i;
                }
                if (min == arr[i])
                {
                    Console.WriteLine("Minimum is at index: " + i);
                    toReturn[1] = i;
                }
                if (average == arr[i])
                {
                    Console.WriteLine("Average is at index: " + i);
                    toReturn[2] = i;
                }
            }

            return toReturn;

        }

//--------------------------------------------Compare Arrays--------------------------------------------------------------------------------------------//

        public static void compareArrays(double[] arr) 
        {
            String[] times = importDataTimes();
            double[] indexes = linearSearch(arr);

            Console.WriteLine("Maximum occurred at: " + times[(int)indexes[0]]);
            Console.WriteLine("Minimum occurred at: " + times[(int)indexes[1]]);
            Console.WriteLine("Average occurred at: " + times[(int)indexes[2]]);
        }


//--------------------------------------------Bubble Sort Timing-------------------------------------------------------------------------------------------//
        class BubbleSortTiming
        {

            public static void BubbleSort(double[] arr) 
            {

                double temp;
                Console.WriteLine("--Original Contents--");
                Program.printarray(arr);
                Console.WriteLine("--Sorted Bubble --");

                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }

                Program.printarray(arr);
                Console.WriteLine("\n");
            }
//------------------------------------------Improve Bubble Sort----------------------------------------------------------------------------------------------//

            public static void ImproveBubbleSort(double[] arr)  
            {

                for (int i = 1; i < arr.Length; ++i)
                {
                    bool swapped = false;

                    for (int j = 0; j < arr.Length - i; ++j)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            swapped = true;
                            double temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }

                    if (!swapped)
                    {
                        break;
                    }
                }


            }
        }
    }

}