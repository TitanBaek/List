using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230420
{
    public class Sort 
    {
        public delegate int G_Compare<T>(T x, T y); 

        public static void Generic_Sort<T>(IList<T> iArray,G_Compare<T> comapre) where T : IComparable<T>
        {
            for (int i = 0; i < iArray.Count; i++)
            {
                for (int j = i; j < iArray.Count; j++)
                {
                    if (comapre(iArray[i], iArray[j]) > 0)
                    {   
                        T temp = iArray[i];
                        iArray[i] = iArray[j];
                        iArray[j] = temp;
                    }
                }
            }

            foreach(T i in iArray)
            {
                Console.WriteLine(i);
            }
            
        }


        public static int G_AsendCompare<T>(T x, T y) where T : IComparable<T>     
                                                                                    
        {
            return x.CompareTo(y);
        }
        public static int G_DescendCompare<T>(T x, T y) where T : IComparable<T>    
        {
            return x.CompareTo(y) * -1;
        }

    }
}
